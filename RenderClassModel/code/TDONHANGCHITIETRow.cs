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
                            if (row.Table.Columns.Contains("ID") && row["ID"] != DBNull.Value) ID = row["ID"].ToString();
if (row.Table.Columns.Contains("DMATHANGID") && row["DMATHANGID"] != DBNull.Value) DMATHANGID = row["DMATHANGID"].ToString();
if (row.Table.Columns.Contains("DSIZEID") && row["DSIZEID"] != DBNull.Value) DSIZEID = row["DSIZEID"].ToString();
if (row.Table.Columns.Contains("DMAUID") && row["DMAUID"] != DBNull.Value) DMAUID = row["DMAUID"].ToString();
if (row.Table.Columns.Contains("TDONHANGID") && row["TDONHANGID"] != DBNull.Value) TDONHANGID = row["TDONHANGID"].ToString();
if (row.Table.Columns.Contains("TGIAOHANGID") && row["TGIAOHANGID"] != DBNull.Value) TGIAOHANGID = row["TGIAOHANGID"].ToString();
if (row.Table.Columns.Contains("DKHACHHANGID") && row["DKHACHHANGID"] != DBNull.Value) DKHACHHANGID = row["DKHACHHANGID"].ToString();
if (row.Table.Columns.Contains("DTRANGTHAIDONID") && row["DTRANGTHAIDONID"] != DBNull.Value) DTRANGTHAIDONID = row["DTRANGTHAIDONID"].ToString();
if (row.Table.Columns.Contains("DONGIA") && row["DONGIA"] != DBNull.Value) DONGIA = Convert.ToInt64(row["DONGIA"]);
if (row.Table.Columns.Contains("SOLUONG") && row["SOLUONG"] != DBNull.Value) SOLUONG = Convert.ToInt64(row["SOLUONG"]);
if (row.Table.Columns.Contains("THANHTIEN") && row["THANHTIEN"] != DBNull.Value) THANHTIEN = Convert.ToInt64(row["THANHTIEN"]);
if (row.Table.Columns.Contains("SLNHAN") && row["SLNHAN"] != DBNull.Value) SLNHAN = Convert.ToInt32(row["SLNHAN"]);
if (row.Table.Columns.Contains("NOTE") && row["NOTE"] != DBNull.Value) NOTE = row["NOTE"].ToString();

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
                                dic.Add("@ID", ID);
dic.Add("@DMATHANGID", DMATHANGID);
dic.Add("@DSIZEID", DSIZEID);
dic.Add("@DMAUID", DMAUID);
dic.Add("@TDONHANGID", TDONHANGID);
dic.Add("@TGIAOHANGID", TGIAOHANGID);
dic.Add("@DKHACHHANGID", DKHACHHANGID);
dic.Add("@DTRANGTHAIDONID", DTRANGTHAIDONID);
dic.Add("@DONGIA", DONGIA);
dic.Add("@SOLUONG", SOLUONG);
dic.Add("@THANHTIEN", THANHTIEN);
dic.Add("@SLNHAN", SLNHAN);
dic.Add("@NOTE", NOTE);

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
                        querySql = "insert into TDONHANGCHITIET(" + p1 + ") values(" + p2 + ")";
                    }
                    else
                    {
                        querySql = "update TDONHANGCHITIET set " + querySql + @" where ID = @ID";
                    }
                    return db.ExSql(querySql, attrs) > 0;
                }

                        
                public void Delete()
                {
                    db.ExSql("delete TDONHANGCHITIET from id = @id", attrs);
                }
                    }
                }