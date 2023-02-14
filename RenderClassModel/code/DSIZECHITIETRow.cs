using System;
                using System.Collections.Generic;
                using System.Data;
                using DuongNn.Db;

                namespace DuongNn.Mapping
                {
                    public class DSIZECHITIETRow
                    {
                        Database db = new Database(DbConfig.server, DbConfig.user, DbConfig.password, DbConfig.database);
                        
                        public string ID { set; get; }
public string DMATHANGID { set; get; }
public string DSIZEID { set; get; }


                        public DSIZECHITIETRow()
                        {
                            InitWithoutParam();
                        }

                        private void InitWithoutParam()
                        {
                            ID = "";
DMATHANGID = "";
DSIZEID = "";

                        }

                        public DSIZECHITIETRow(DataRow row)
                        {
                            InitWithDataRow(row);
                        }

                        private void InitWithDataRow(DataRow row)
                        {
                            if (row.Table.Columns.Contains("ID")) ID = row["ID"].ToString();
if (row.Table.Columns.Contains("DMATHANGID")) DMATHANGID = row["DMATHANGID"].ToString();
if (row.Table.Columns.Contains("DSIZEID")) DSIZEID = row["DSIZEID"].ToString();

                        }

                        public DSIZECHITIETRow(string ID)
                        {
                            this.ID = ID;
                            if (ID == null || ID.Length == 0) InitWithoutParam();
                            else
                            {
                                DataRow row = db.GetFirstRow("select * from DSIZECHITIET where id = @id", attrs);
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
dic.Add("DMATHANGID", DMATHANGID);
dic.Add("DSIZEID", DSIZEID);

                                return dic;
                            }
                        }

                        public DataRow ToRow(DataTable dt)
                        {
                            DataRow row = dt.NewRow();
                            row["ID"] = ID;
row["DMATHANGID"] = DMATHANGID;
row["DSIZEID"] = DSIZEID;

                            return row;
                        }

                        public bool Update()
                        {
                            if (ID == null || ID.Length == 0)
                            {
                                ID = Guid.NewGuid().ToString();
                                return db.ExSql("insert into DSIZECHITIET(ID, DMATHANGID, DSIZEID) values(@ID, @DMATHANGID, @DSIZEID)", attrs) > 0;
                            }
                            else
                            {
                                return db.ExSql("update set ID=@ID, DMATHANGID=@DMATHANGID, DSIZEID=@DSIZEID where id = @id", attrs) > 0;
                                }
                            }

                        public void Delete()
                        {
                            db.ExSql("delete DSIZECHITIET from id = @id", attrs);
                        }
                    }
                }