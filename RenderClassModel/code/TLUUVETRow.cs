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
                            if (row.Table.Columns.Contains("ID")) ID = row["ID"].ToString();
if (row.Table.Columns.Contains("TIMECREATED")) TIMECREATED = Convert.ToDateTime(row["TIMECREATED"]);
if (row.Table.Columns.Contains("TDONHANGID")) TDONHANGID = row["TDONHANGID"].ToString();
if (row.Table.Columns.Contains("TDONHANGCHITIETID")) TDONHANGCHITIETID = row["TDONHANGCHITIETID"].ToString();
if (row.Table.Columns.Contains("NOTE")) NOTE = row["NOTE"].ToString();

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
                                dic.Add("ID", ID);
dic.Add("TIMECREATED", TIMECREATED);
dic.Add("TDONHANGID", TDONHANGID);
dic.Add("TDONHANGCHITIETID", TDONHANGCHITIETID);
dic.Add("NOTE", NOTE);

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
                            if (ID == null || ID.Length == 0)
                            {
                                ID = Guid.NewGuid().ToString();
                                return db.ExSql("insert into TLUUVET(ID, TIMECREATED, TDONHANGID, TDONHANGCHITIETID, NOTE) values(@ID, @TIMECREATED, @TDONHANGID, @TDONHANGCHITIETID, @NOTE)", attrs) > 0;
                            }
                            else
                            {
                                return db.ExSql("update set ID=@ID, TIMECREATED=@TIMECREATED, TDONHANGID=@TDONHANGID, TDONHANGCHITIETID=@TDONHANGCHITIETID, NOTE=@NOTE where id = @id", attrs) > 0;
                                }
                            }

                        public void Delete()
                        {
                            db.ExSql("delete TLUUVET from id = @id", attrs);
                        }
                    }
                }