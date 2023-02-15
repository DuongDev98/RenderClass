using System;
                using System.Collections.Generic;
                using System.Data;
                using DuongNn.Db;

                namespace DuongNn.Mapping
                {
                    public class SUSERRow
                    {
                        Database db = new Database(DbConfig.server, DbConfig.user, DbConfig.password, DbConfig.database);
                        
                        public string ID { set; get; }
public string USERNAME { set; get; }
public string PASSWORD { set; get; }
public string DNHANVIENID { set; get; }
public int ISADMIN { set; get; }


                        public SUSERRow()
                        {
                            InitWithoutParam();
                        }

                        private void InitWithoutParam()
                        {
                            ID = "";
USERNAME = "";
PASSWORD = "";
DNHANVIENID = "";
ISADMIN = 0;

                        }

                        public SUSERRow(DataRow row)
                        {
                            InitWithDataRow(row);
                        }

                        private void InitWithDataRow(DataRow row)
                        {
                            if (row.Table.Columns.Contains("ID") && row["ID"] != DBNull.Value) ID = row["ID"].ToString();
if (row.Table.Columns.Contains("USERNAME") && row["USERNAME"] != DBNull.Value) USERNAME = row["USERNAME"].ToString();
if (row.Table.Columns.Contains("PASSWORD") && row["PASSWORD"] != DBNull.Value) PASSWORD = row["PASSWORD"].ToString();
if (row.Table.Columns.Contains("DNHANVIENID") && row["DNHANVIENID"] != DBNull.Value) DNHANVIENID = row["DNHANVIENID"].ToString();
if (row.Table.Columns.Contains("ISADMIN") && row["ISADMIN"] != DBNull.Value) ISADMIN = Convert.ToInt32(row["ISADMIN"]);

                        }

                        public SUSERRow(string ID)
                {
                    this.ID = ID;
                    if (ID == null || ID.Length == 0) InitWithoutParam();
                    else
                    {
                        DataRow row = db.GetFirstRow("select * from SUSER where id = @id", attrs);
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
                                dic.Add("@ID", ID);
dic.Add("@USERNAME", USERNAME);
dic.Add("@PASSWORD", PASSWORD);
dic.Add("@DNHANVIENID", DNHANVIENID);
dic.Add("@ISADMIN", ISADMIN);

                                return dic;
                            }
                        }

                        public DataRow ToRow(DataTable dt)
                        {
                            DataRow row = dt.NewRow();
                            row["ID"] = ID;
row["USERNAME"] = USERNAME;
row["PASSWORD"] = PASSWORD;
row["DNHANVIENID"] = DNHANVIENID;
row["ISADMIN"] = ISADMIN;

                            return row;
                        }

                        
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
                                p1 += ",";
                                p2 += ",";
                            }
                            p1 += key.Replace("@", "");
                            p2 += key;
                        }
                        else
                        {
                            if (querySql.Length > 0) querySql += ",";
                            querySql += key.Replace("@", "") + "=" + key;
                        }
                    }
                    if (insert)
                    {
                        querySql = "insert into SUSER(" + p1 + ") values(" + p2 + ")";
                    }
                    else
                    {
                        querySql = "update SUSER set " + querySql + @" where ID = @ID";
                    }
                    return db.ExSql(querySql, attrs) > 0;
                }

                        
                public void Delete()
                {
                    db.ExSql("delete SUSER from id = @id", attrs);
                }
                    }
                }