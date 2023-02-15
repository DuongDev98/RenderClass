using System;
                using System.Collections.Generic;
                using System.Data;
                using DuongNn.Db;

                namespace DuongNn.Mapping
                {
                    public class TGIAOHANGRow
                    {
                        Database db = new Database(DbConfig.server, DbConfig.user, DbConfig.password, DbConfig.database);
                        
                        public string ID { set; get; }
public DateTime TIMECREATED { set; get; }
public string NAME { set; get; }
public DateTime NGAY { set; get; }
public string DKHACHHANGID { set; get; }
public string DNHANVIENID { set; get; }
public string TINHTHANH { set; get; }
public string QUANHUYEN { set; get; }
public string PHUONGXA { set; get; }
public string DIACHI { set; get; }
public int LOAIVANCHUYEN { set; get; }
public string DNHAXEID { set; get; }
public string LABEL_GHTK { set; get; }
public string NOTE { set; get; }
public long PHIVANCHUYEN { set; get; }


                        public TGIAOHANGRow()
                        {
                            InitWithoutParam();
                        }

                        private void InitWithoutParam()
                        {
                            ID = "";
TIMECREATED = DateTime.Now;
NAME = "";
NGAY = DateTime.Now.Date;
DKHACHHANGID = "";
DNHANVIENID = "";
TINHTHANH = "";
QUANHUYEN = "";
PHUONGXA = "";
DIACHI = "";
LOAIVANCHUYEN = 0;
DNHAXEID = "";
LABEL_GHTK = "";
NOTE = "";
PHIVANCHUYEN = 0;

                        }

                        public TGIAOHANGRow(DataRow row)
                        {
                            InitWithDataRow(row);
                        }

                        private void InitWithDataRow(DataRow row)
                        {
                            if (row.Table.Columns.Contains("ID") && row["ID"] != DBNull.Value) ID = row["ID"].ToString();
if (row.Table.Columns.Contains("TIMECREATED") && row["TIMECREATED"] != DBNull.Value) TIMECREATED = Convert.ToDateTime(row["TIMECREATED"]);
if (row.Table.Columns.Contains("NAME") && row["NAME"] != DBNull.Value) NAME = row["NAME"].ToString();
if (row.Table.Columns.Contains("NGAY") && row["NGAY"] != DBNull.Value) NGAY = Convert.ToDateTime(row["NGAY"]);
if (row.Table.Columns.Contains("DKHACHHANGID") && row["DKHACHHANGID"] != DBNull.Value) DKHACHHANGID = row["DKHACHHANGID"].ToString();
if (row.Table.Columns.Contains("DNHANVIENID") && row["DNHANVIENID"] != DBNull.Value) DNHANVIENID = row["DNHANVIENID"].ToString();
if (row.Table.Columns.Contains("TINHTHANH") && row["TINHTHANH"] != DBNull.Value) TINHTHANH = row["TINHTHANH"].ToString();
if (row.Table.Columns.Contains("QUANHUYEN") && row["QUANHUYEN"] != DBNull.Value) QUANHUYEN = row["QUANHUYEN"].ToString();
if (row.Table.Columns.Contains("PHUONGXA") && row["PHUONGXA"] != DBNull.Value) PHUONGXA = row["PHUONGXA"].ToString();
if (row.Table.Columns.Contains("DIACHI") && row["DIACHI"] != DBNull.Value) DIACHI = row["DIACHI"].ToString();
if (row.Table.Columns.Contains("LOAIVANCHUYEN") && row["LOAIVANCHUYEN"] != DBNull.Value) LOAIVANCHUYEN = Convert.ToInt32(row["LOAIVANCHUYEN"]);
if (row.Table.Columns.Contains("DNHAXEID") && row["DNHAXEID"] != DBNull.Value) DNHAXEID = row["DNHAXEID"].ToString();
if (row.Table.Columns.Contains("LABEL_GHTK") && row["LABEL_GHTK"] != DBNull.Value) LABEL_GHTK = row["LABEL_GHTK"].ToString();
if (row.Table.Columns.Contains("NOTE") && row["NOTE"] != DBNull.Value) NOTE = row["NOTE"].ToString();
if (row.Table.Columns.Contains("PHIVANCHUYEN") && row["PHIVANCHUYEN"] != DBNull.Value) PHIVANCHUYEN = Convert.ToInt64(row["PHIVANCHUYEN"]);

                        }

                        public TGIAOHANGRow(string ID)
                {
                    this.ID = ID;
                    if (ID == null || ID.Length == 0) InitWithoutParam();
                    else
                    {
                        DataRow row = db.GetFirstRow("select * from TGIAOHANG where id = @id", attrs);
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
dic.Add("@NAME", NAME);
dic.Add("@NGAY", NGAY);
dic.Add("@DKHACHHANGID", DKHACHHANGID);
dic.Add("@DNHANVIENID", DNHANVIENID);
dic.Add("@TINHTHANH", TINHTHANH);
dic.Add("@QUANHUYEN", QUANHUYEN);
dic.Add("@PHUONGXA", PHUONGXA);
dic.Add("@DIACHI", DIACHI);
dic.Add("@LOAIVANCHUYEN", LOAIVANCHUYEN);
dic.Add("@DNHAXEID", DNHAXEID);
dic.Add("@LABEL_GHTK", LABEL_GHTK);
dic.Add("@NOTE", NOTE);
dic.Add("@PHIVANCHUYEN", PHIVANCHUYEN);

                                return dic;
                            }
                        }

                        public DataRow ToRow(DataTable dt)
                        {
                            DataRow row = dt.NewRow();
                            row["ID"] = ID;
row["TIMECREATED"] = TIMECREATED;
row["NAME"] = NAME;
row["NGAY"] = NGAY;
row["DKHACHHANGID"] = DKHACHHANGID;
row["DNHANVIENID"] = DNHANVIENID;
row["TINHTHANH"] = TINHTHANH;
row["QUANHUYEN"] = QUANHUYEN;
row["PHUONGXA"] = PHUONGXA;
row["DIACHI"] = DIACHI;
row["LOAIVANCHUYEN"] = LOAIVANCHUYEN;
row["DNHAXEID"] = DNHAXEID;
row["LABEL_GHTK"] = LABEL_GHTK;
row["NOTE"] = NOTE;
row["PHIVANCHUYEN"] = PHIVANCHUYEN;

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
                        querySql = "insert into TGIAOHANG(" + p1 + ") values(" + p2 + ")";
                    }
                    else
                    {
                        querySql = "update TGIAOHANG set " + querySql + @" where ID = @ID";
                    }
                    return db.ExSql(querySql, attrs) > 0;
                }

                        
                public void Delete()
                {
                    db.ExSql("delete TGIAOHANG from id = @id", attrs);
                }
                    }
                }