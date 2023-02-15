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

                bool hasId = false;
                foreach (DataRow rowColumn in rowColums)
                {
                    string tmp = "", rowValue = "";
                    string dataType = rowColumn["DATA_TYPE"].ToString().ToLower(), columnName = rowColumn["COLUMN_NAME"].ToString();
                    if (columnName.ToLower() == "id") hasId = true;
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
                    if (dataType == "int" || dataType == "numeric")
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
                    if (dataType == "int" || dataType == "numeric" || dataType == "bigint" || dataType == "decimal") tmp = "0";
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
                    sbInitWithDataRow.AppendLine("if (row.Table.Columns.Contains(\"" + columnName + "\") && row[\""+columnName+"\"] != DBNull.Value) " + columnName + " = " + rowValue);

                    //4
                    sbDicAttrs.AppendLine("dic.Add(\"@" + columnName + "\", " + columnName + ");");

                    //5
                    sbToRow.AppendLine("row[\"" + columnName + "\"] = " + columnName + ";");
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

                        @contructorWithId

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

                        @updateFunc

                        @deleteFunc
                    }
                }";
                contentFile = contentFile.Replace("@contructorWithId", !hasId ? "" :
                @"public @Tmp(string ID)
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
                }").Replace("@updateFunc", !hasId ? "" :
                @"
                public bool Update()
                {
                    bool insert = false;
                    string querySql = string.Empty, p1 = string.Empty, p2 = string.Empty;
                    if (ID == null || ID.Length == 0)
                    {
                        ID = Guid.NewGuid().ToString();
                        insert = true;
                    }
                    foreach (string key in attrs.Keys)
                    {
                        if (insert)
                        {
                            if (p1.Length > 0)
                            {
                                p1 += "","";
                                p2 += "","";
                            }
                            p1 += key.Replace(""@"", """");
                            p2 += key;
                        }
                        else
                        {
                            if (querySql.Length > 0) querySql += "","";
                            querySql += key.Replace(""@"", """") + ""="" + key;
                        }
                    }
                    if (insert)
                    {
                        querySql = ""insert into "+TABLE_NAME+ @"("" + p1 + "") values("" + p2 + "")"";
                    }
                    else
                    {
                        querySql = ""update "+TABLE_NAME+ @" set "" + querySql + @"" where ID = @ID"";
                    }
                    return db.ExSql(querySql, attrs) > 0;
                }")
                .Replace("@deleteFunc", !hasId ? "" :
                @"
                public void Delete()
                {
                    db.ExSql(@sqlDelete, attrs);
                }");
                contentFile = contentFile
                    .Replace("@Tmp", TABLE_NAME + "Row")
                    .Replace("@sbInitVar", sbInitVar.ToString())
                    .Replace("@InitWithoutParam", sbInitWithoutParam.ToString())
                    .Replace("@InitWithDataRow", sbInitWithDataRow.ToString())
                    .Replace("@selectrow", "\"select * from " + TABLE_NAME + " where id = @id\"")
                    .Replace("@DicAttrs", sbDicAttrs.ToString())
                    .Replace("@sbToRow", sbToRow.ToString())
                    //.Replace("@sqlInsert", "\"insert into " + TABLE_NAME + "(" + sqlInsertTitle + ") values(" + sqlInsertValue + ")\"")
                    //.Replace("@sqlUpdate", "\"update set " + sqlUpdate + " where id = @id\"")
                    .Replace("@sqlDelete", "\"delete " + TABLE_NAME + " from id = @id\"")
                    ;
                File.WriteAllText(folder + "/" + TABLE_NAME + "Row.cs", contentFile);
            }
        }
    }
}
