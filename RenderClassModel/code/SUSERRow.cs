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
                            if (row.Table.Columns.Contains("ID")) ID = row["ID"].ToString();
if (row.Table.Columns.Contains("USERNAME")) USERNAME = row["USERNAME"].ToString();
if (row.Table.Columns.Contains("PASSWORD")) PASSWORD = row["PASSWORD"].ToString();
if (row.Table.Columns.Contains("DNHANVIENID")) DNHANVIENID = row["DNHANVIENID"].ToString();
if (row.Table.Columns.Contains("ISADMIN")) ISADMIN = Convert.ToInt32(row["ISADMIN"]);

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
                                dic.Add("ID", ID);
dic.Add("USERNAME", USERNAME);
dic.Add("PASSWORD", PASSWORD);
dic.Add("DNHANVIENID", DNHANVIENID);
dic.Add("ISADMIN", ISADMIN);

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
                            if (ID == null || ID.Length == 0)
                            {
                                ID = Guid.NewGuid().ToString();
                                return db.ExSql("insert into SUSER(ID, USERNAME, PASSWORD, DNHANVIENID, ISADMIN) values(@ID, @USERNAME, @PASSWORD, @DNHANVIENID, @ISADMIN)", attrs) > 0;
                            }
                            else
                            {
                                return db.ExSql("update set ID=@ID, USERNAME=@USERNAME, PASSWORD=@PASSWORD, DNHANVIENID=@DNHANVIENID, ISADMIN=@ISADMIN where id = @id", attrs) > 0;
                                }
                            }

                        public void Delete()
                        {
                            db.ExSql("delete SUSER from id = @id", attrs);
                        }
                    }
                }