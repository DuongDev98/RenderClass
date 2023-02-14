using System;
                using System.Collections.Generic;
                using System.Data;
                using DuongNn.Db;

                namespace DuongNn.Mapping
                {
                    public class TDONHANGCHITIETRow
                    {
                        Database db = new Database(DbConfig.server, DbConfig.user, DbConfig.password, DbConfig.database);
                        
                        public string ID { set; get; }
public string DMATHANGID { set; get; }
public string DSIZEID { set; get; }
public string DMAUID { set; get; }
public string TDONHANGID { set; get; }
public string TGIAOHANGID { set; get; }
public string DKHACHHANGID { set; get; }
public string DTRANGTHAIDONID { set; get; }
public long DONGIA { set; get; }
public long SOLUONG { set; get; }
public long THANHTIEN { set; get; }
public int SLNHAN { set; get; }
public string NOTE { set; get; }


                        public TDONHANGCHITIETRow()
                        {
                            InitWithoutParam();
                        }

                        private void InitWithoutParam()
                        {
                            ID = "";
DMATHANGID = "";
DSIZEID = "";
DMAUID = "";
TDONHANGID = "";
TGIAOHANGID = "";
DKHACHHANGID = "";
DTRANGTHAIDONID = "";
DONGIA = 0;
SOLUONG = 0;
THANHTIEN = 0;
SLNHAN = 0;
NOTE = "";

                        }

                        public TDONHANGCHITIETRow(DataRow row)
                        {
                            InitWithDataRow(row);
                        }

                        private void InitWithDataRow(DataRow row)
                        {
                            if (row.Table.Columns.Contains("ID")) ID = row["ID"].ToString();
if (row.Table.Columns.Contains("DMATHANGID")) DMATHANGID = row["DMATHANGID"].ToString();
if (row.Table.Columns.Contains("DSIZEID")) DSIZEID = row["DSIZEID"].ToString();
if (row.Table.Columns.Contains("DMAUID")) DMAUID = row["DMAUID"].ToString();
if (row.Table.Columns.Contains("TDONHANGID")) TDONHANGID = row["TDONHANGID"].ToString();
if (row.Table.Columns.Contains("TGIAOHANGID")) TGIAOHANGID = row["TGIAOHANGID"].ToString();
if (row.Table.Columns.Contains("DKHACHHANGID")) DKHACHHANGID = row["DKHACHHANGID"].ToString();
if (row.Table.Columns.Contains("DTRANGTHAIDONID")) DTRANGTHAIDONID = row["DTRANGTHAIDONID"].ToString();
if (row.Table.Columns.Contains("DONGIA")) DONGIA = Convert.ToInt64(row["DONGIA"]);
if (row.Table.Columns.Contains("SOLUONG")) SOLUONG = Convert.ToInt64(row["SOLUONG"]);
if (row.Table.Columns.Contains("THANHTIEN")) THANHTIEN = Convert.ToInt64(row["THANHTIEN"]);
if (row.Table.Columns.Contains("SLNHAN")) SLNHAN = Convert.ToInt32(row["SLNHAN"]);
if (row.Table.Columns.Contains("NOTE")) NOTE = row["NOTE"].ToString();

                        }

                        public TDONHANGCHITIETRow(string ID)
                        {
                            this.ID = ID;
                            if (ID == null || ID.Length == 0) InitWithoutParam();
                            else
                            {
                                DataRow row = db.GetFirstRow("select * from TDONHANGCHITIET where id = @id", attrs);
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
dic.Add("DMAUID", DMAUID);
dic.Add("TDONHANGID", TDONHANGID);
dic.Add("TGIAOHANGID", TGIAOHANGID);
dic.Add("DKHACHHANGID", DKHACHHANGID);
dic.Add("DTRANGTHAIDONID", DTRANGTHAIDONID);
dic.Add("DONGIA", DONGIA);
dic.Add("SOLUONG", SOLUONG);
dic.Add("THANHTIEN", THANHTIEN);
dic.Add("SLNHAN", SLNHAN);
dic.Add("NOTE", NOTE);

                                return dic;
                            }
                        }

                        public DataRow ToRow(DataTable dt)
                        {
                            DataRow row = dt.NewRow();
                            row["ID"] = ID;
row["DMATHANGID"] = DMATHANGID;
row["DSIZEID"] = DSIZEID;
row["DMAUID"] = DMAUID;
row["TDONHANGID"] = TDONHANGID;
row["TGIAOHANGID"] = TGIAOHANGID;
row["DKHACHHANGID"] = DKHACHHANGID;
row["DTRANGTHAIDONID"] = DTRANGTHAIDONID;
row["DONGIA"] = DONGIA;
row["SOLUONG"] = SOLUONG;
row["THANHTIEN"] = THANHTIEN;
row["SLNHAN"] = SLNHAN;
row["NOTE"] = NOTE;

                            return row;
                        }

                        public bool Update()
                        {
                            if (ID == null || ID.Length == 0)
                            {
                                ID = Guid.NewGuid().ToString();
                                return db.ExSql("insert into TDONHANGCHITIET(ID, DMATHANGID, DSIZEID, DMAUID, TDONHANGID, TGIAOHANGID, DKHACHHANGID, DTRANGTHAIDONID, DONGIA, SOLUONG, THANHTIEN, SLNHAN, NOTE) values(@ID, @DMATHANGID, @DSIZEID, @DMAUID, @TDONHANGID, @TGIAOHANGID, @DKHACHHANGID, @DTRANGTHAIDONID, @DONGIA, @SOLUONG, @THANHTIEN, @SLNHAN, @NOTE)", attrs) > 0;
                            }
                            else
                            {
                                return db.ExSql("update set ID=@ID, DMATHANGID=@DMATHANGID, DSIZEID=@DSIZEID, DMAUID=@DMAUID, TDONHANGID=@TDONHANGID, TGIAOHANGID=@TGIAOHANGID, DKHACHHANGID=@DKHACHHANGID, DTRANGTHAIDONID=@DTRANGTHAIDONID, DONGIA=@DONGIA, SOLUONG=@SOLUONG, THANHTIEN=@THANHTIEN, SLNHAN=@SLNHAN, NOTE=@NOTE where id = @id", attrs) > 0;
                                }
                            }

                        public void Delete()
                        {
                            db.ExSql("delete TDONHANGCHITIET from id = @id", attrs);
                        }
                    }
                }