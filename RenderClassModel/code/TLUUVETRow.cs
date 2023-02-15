using System;
                using System.Collections.Generic;
                using System.Data;
                using DuongNn.Db;

                namespace DuongNn.Mapping
                {
                    public class TLUUVETRow
                    {
                        Database db = new Database(DbConfig.server, DbConfig.user, DbConfig.password, DbConfig.database);
                        
                        public string ID { set; get; }
public DateTime TIMECREATED { set; get; }
public string TDONHANGID { set; get; }
public string TDONHANGCHITIETID { set; get; }
public string NOTE { set; get; }


                        public TLUUVETRow()
                        {
                            InitWithoutParam();
                        }

                        private void InitWithoutParam()
                        {
                            ID = "";
TIMECREATED = DateTime.Now;
TDONHANGID = "";
TDONHANGCHITIETID = "";
NOTE = "";

                        }

                        public TLUUVETRow(DataRow row)
                        {
                            InitWithDataRow(row);
                        }

                        private void InitWithDataRow(DataRow row)
                        {
                            if (row.Table.Columns.Contains("ID") && row["ID"] != DBNull.Value) ID = row["ID"].ToString();
if (row.Table.Columns.Contains("TIMECREATED") && row["TIMECREATED"] != DBNull.Value) TIMECREATED = Convert.ToDateTime(row["TIMECREATED"]);
if (row.Table.Columns.Contains("TDONHANGID") && row["TDONHANGID"] != DBNull.Value) TDONHANGID = row["TDONHANGID"].ToString();
if (row.Table.Columns.Contains("TDONHANGCHITIETID") && row["TDONHANGCHITIETID"] != DBNull.Value) TDONHANGCHITIETID = row["TDONHANGCHITIETID"].ToString();
if (row.Table.Columns.Contains("NOTE") && row["NOTE"] != DBNull.Value) NOTE = row["NOTE"].ToString();

                        }

                        public TLUUVETRow(string ID)
                {
                    this.ID = ID;
                    if (ID == null || ID.Length == 0) InitWithoutParam();
                    else
                    {
                        DataRow row = db.GetFirstRow("select * from TLUUVET where id = @id", attrs);
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
dic.Add("@TIMECREATED", TIMECREATED);
dic.Add("@TDONHANGID", TDONHANGID);
dic.Add("@TDONHANGCHITIETID", TDONHANGCHITIETID);
dic.Add("@NOTE", NOTE);

                                return dic;
                            }
                        }

                        public DataRow ToRow(DataTable dt)
                        {
                            DataRow row = dt.NewRow();
                            row["ID"] = ID;
row["TIMECREATED"] = TIMECREATED;
row["TDONHANGID"] = TDONHANGID;
row["TDONHANGCHITIETID"] = TDONHANGCHITIETID;
row["NOTE"] = NOTE;

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
                        querySql = "insert into TLUUVET(" + p1 + ") values(" + p2 + ")";
                    }
                    else
                    {
                        querySql = "update TLUUVET set " + querySql + @" where ID = @ID";
                    }
                    return db.ExSql(querySql, attrs) > 0;
                }

                        
                public void Delete()
                {
                    db.ExSql("delete TLUUVET from id = @id", attrs);
                }
                    }
                }