using DuongNn.Db;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenderClassModel.Utils
{
    public class RenderDatabase
    {
        public Database db { set; get; }
        public string folder { set; get; }

        public RenderDatabase(Database db, string folder)
        {
            this.db = db;
            this.folder = folder;
        }

        public void run()
        {
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            //write file dbConfig
            string contentFile =
                @"namespace DuongNn.Db
                    {
                        public class DbConfig
                        {
                            public const string server = @server;
                            public const string user = @user;
                            public const string password = @password;
                            public const string database = @database;
                        }
                    }"
                .Replace("@server", "@\"" + db.server + "\"")
                .Replace("@user", "\"" + db.user + "\"")
                .Replace("@password", "\"" + db.password + "\"")
                .Replace("@database", "\"" + db.database + "\"");

            File.WriteAllText(folder + "/DbConfig.cs", contentFile);

            DataTable dtTables = db.GetTable("SELECT * FROM INFORMATION_SCHEMA.TABLES");
            DataTable dtColumns = db.GetTable("SELECT * FROM INFORMATION_SCHEMA.COLUMNS");
            foreach (DataRow rTable in dtTables.Rows)
            {
                string TABLE_NAME = rTable["TABLE_NAME"].ToString();

                DataRow[] rowColums = dtColumns.Select("TABLE_NAME='" + TABLE_NAME + "'");

                //1.Init Var
                StringBuilder sbInitVar = new StringBuilder();

                //2.Init Without Param
                StringBuilder sbInitWithoutParam = new StringBuilder();

                //3.InitWithDataRow
                StringBuilder sbInitWithDataRow = new StringBuilder();

                //4.Dic attrs
                StringBuilder sbDicAttrs = new StringBuilder();

                //5.To Row
                StringBuilder sbToRow = new StringBuilder();

                //6.Sql insert
                string sqlInsertTitle = "", sqlInsertValue = "";

                //7.Sql update
                string sqlUpdate = "";

                foreach (DataRow rowColumn in rowColums)
                {
                    string tmp = "", rowValue = "";
                    string dataType = rowColumn["DATA_TYPE"].ToString().ToLower(), columnName = rowColumn["COLUMN_NAME"].ToString();

                    //1
                    tmp = dataType;
                    if (dataType == "varchar" || dataType == "nvarchar")
                    {
                        tmp = "string";
                        //3
                        rowValue = "row[\"" + columnName + "\"].ToString();";
                    }
                    if (dataType == "bigint")
                    {
                        tmp = "long";
                        //3
                        rowValue = "Convert.ToInt64(row[\"" + columnName + "\"]);";
                    }
                    if (dataType == "datetime")
                    {
                        tmp = "DateTime";
                        //3
                        rowValue = "Convert.ToDateTime(row[\"" + columnName + "\"]);";
                    }
                    if (dataType == "date")
                    {
                        tmp = "DateTime";
                        //3
                        rowValue = "Convert.ToDateTime(row[\"" + columnName + "\"]);";
                    }
                    if (dataType == "int" || dataType == "numberic")
                    {
                        //3
                        rowValue = "Convert.ToInt32(row[\"" + columnName + "\"]);";
                    }
                    if (dataType == "decimal")
                    {
                        //3
                        rowValue = "Convert.ToDecimal(row[\"" + columnName + "\"]);";
                    }
                    sbInitVar.AppendLine("public " + tmp + " " + columnName + " { set; get; }");

                    //2
                    if (dataType == "varchar" || dataType == "nvarchar") tmp = "\"\"";
                    if (dataType == "int" || dataType == "numberic" || dataType == "bigint" || dataType == "decimal") tmp = "0";
                    if (dataType == "datetime")
                    {
                        tmp = "DateTime.Now";
                    }
                    if (dataType == "date")
                    {
                        tmp = "DateTime.Now.Date";
                    }
                    sbInitWithoutParam.AppendLine(columnName + " = " + tmp + ";");

                    //3
                    sbInitWithDataRow.AppendLine("if (row.Table.Columns.Contains(\"" + columnName + "\")) " + columnName + " = " + rowValue);

                    //4
                    sbDicAttrs.AppendLine("dic.Add(\"" + columnName + "\", " + columnName + ");");

                    //5
                    sbToRow.AppendLine("row[\"" + columnName + "\"] = " + columnName + ";");

                    //6
                    if (sqlInsertTitle.Length > 0) sqlInsertTitle += ", ";
                    sqlInsertTitle += columnName;
                    if (sqlInsertValue.Length > 0) sqlInsertValue += ", ";
                    sqlInsertValue += "@" + columnName;

                    //7
                    if (sqlUpdate.Length > 0) sqlUpdate += ", ";
                    sqlUpdate += columnName + "=@" + columnName;
                }

                contentFile =
                @"using System;
                using System.Collections.Generic;
                using System.Data;
                using DuongNn.Db;

                namespace DuongNn.Mapping
                {
                    public class @Tmp
                    {
                        Database db = new Database(DbConfig.server, DbConfig.user, DbConfig.password, DbConfig.database);
                        
                        @sbInitVar

                        public @Tmp()
                        {
                            InitWithoutParam();
                        }

                        private void InitWithoutParam()
                        {
                            @InitWithoutParam
                        }

                        public @Tmp(DataRow row)
                        {
                            InitWithDataRow(row);
                        }

                        private void InitWithDataRow(DataRow row)
                        {
                            @InitWithDataRow
                        }

                        public @Tmp(string ID)
                        {
                            this.ID = ID;
                            if (ID == null || ID.Length == 0) InitWithoutParam();
                            else
                            {
                                DataRow row = db.GetFirstRow(@selectrow, attrs);
                                if (row != null)
                                {
                                    InitWithDataRow(row);
                                }
                            }
                        }

                        private Dictionary<string, object> attrs
                        {
                            get
                            {
                                Dictionary<string, object> dic = new Dictionary<string, object>();
                                @DicAttrs
                                return dic;
                            }
                        }

                        public DataRow ToRow(DataTable dt)
                        {
                            DataRow row = dt.NewRow();
                            @sbToRow
                            return row;
                        }

                        public bool Update()
                        {
                            if (ID == null || ID.Length == 0)
                            {
                                ID = Guid.NewGuid().ToString();
                                return db.ExSql(@sqlInsert, attrs) > 0;
                            }
                            else
                            {
                                return db.ExSql(@sqlUpdate, attrs) > 0;
                                }
                            }

                        public void Delete()
                        {
                            db.ExSql(@sqlDelete, attrs);
                        }
                    }
                }";
                contentFile = contentFile
                    .Replace("@Tmp", TABLE_NAME + "Row")
                    .Replace("@sbInitVar", sbInitVar.ToString())
                    .Replace("@InitWithoutParam", sbInitWithoutParam.ToString())
                    .Replace("@InitWithDataRow", sbInitWithDataRow.ToString())
                    .Replace("@selectrow", "\"select * from " + TABLE_NAME + " where id = @id\"")
                    .Replace("@DicAttrs", sbDicAttrs.ToString())
                    .Replace("@sbToRow", sbToRow.ToString())
                    .Replace("@sqlInsert", "\"insert into " + TABLE_NAME + "(" + sqlInsertTitle + ") values(" + sqlInsertValue + ")\"")
                    .Replace("@sqlUpdate", "\"update set " + sqlUpdate + " where id = @id\"")
                    .Replace("@sqlDelete", "\"delete " + TABLE_NAME + " from id = @id\"");
                File.WriteAllText(folder + "/" + TABLE_NAME + "Row.cs", contentFile);
            }
        }
    }
}
