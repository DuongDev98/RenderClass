using System;
                using System.Collections.Generic;
                using System.Data;
                using DuongNn.Db;

                namespace DuongNn.Mapping
                {
                    public class TDONHANGRow
                    {
                        Database db = new Database(DbConfig.server, DbConfig.user, DbConfig.password, DbConfig.database);
                        
                        public string ID { set; get; }
public DateTime TIMECREATED { set; get; }
public int LOAI { set; get; }
public DateTime NGAY { set; get; }
public string NAME { set; get; }
public long TIENHANG { set; get; }
public long PHIVANCHUYEN { set; get; }
public long TONGCONG { set; get; }
public long TIENTHANHTOAN { set; get; }
public int DATHANHTOAN { set; get; }
public string TINHTHANH { set; get; }
public string QUANHUYEN { set; get; }
public string PHUONGXA { set; get; }
public string DIACHI { set; get; }
public string DKHACHHANGID { set; get; }
public int LOAIGIA { set; get; }
public int LOAIVANCHUYEN { set; get; }
public string DNHAXEID { set; get; }
public string DNHANVIENID { set; get; }
public string TMPCODE { set; get; }
public string NOTE { set; get; }


                        public TDONHANGRow()
                        {
                            InitWithoutParam();
                        }

                        private void InitWithoutParam()
                        {
                            ID = "";
TIMECREATED = DateTime.Now;
LOAI = 0;
NGAY = DateTime.Now.Date;
NAME = "";
TIENHANG = 0;
PHIVANCHUYEN = 0;
TONGCONG = 0;
TIENTHANHTOAN = 0;
DATHANHTOAN = 0;
TINHTHANH = "";
QUANHUYEN = "";
PHUONGXA = "";
DIACHI = "";
DKHACHHANGID = "";
LOAIGIA = 0;
LOAIVANCHUYEN = 0;
DNHAXEID = "";
DNHANVIENID = "";
TMPCODE = "";
NOTE = "";

                        }

                        public TDONHANGRow(DataRow row)
                        {
                            InitWithDataRow(row);
                        }

                        private void InitWithDataRow(DataRow row)
                        {
                            if (row.Table.Columns.Contains("ID") && row["ID"] != DBNull.Value) ID = row["ID"].ToString();
if (row.Table.Columns.Contains("TIMECREATED") && row["TIMECREATED"] != DBNull.Value) TIMECREATED = Convert.ToDateTime(row["TIMECREATED"]);
if (row.Table.Columns.Contains("LOAI") && row["LOAI"] != DBNull.Value) LOAI = Convert.ToInt32(row["LOAI"]);
if (row.Table.Columns.Contains("NGAY") && row["NGAY"] != DBNull.Value) NGAY = Convert.ToDateTime(row["NGAY"]);
if (row.Table.Columns.Contains("NAME") && row["NAME"] != DBNull.Value) NAME = row["NAME"].ToString();
if (row.Table.Columns.Contains("TIENHANG") && row["TIENHANG"] != DBNull.Value) TIENHANG = Convert.ToInt64(row["TIENHANG"]);
if (row.Table.Columns.Contains("PHIVANCHUYEN") && row["PHIVANCHUYEN"] != DBNull.Value) PHIVANCHUYEN = Convert.ToInt64(row["PHIVANCHUYEN"]);
if (row.Table.Columns.Contains("TONGCONG") && row["TONGCONG"] != DBNull.Value) TONGCONG = Convert.ToInt64(row["TONGCONG"]);
if (row.Table.Columns.Contains("TIENTHANHTOAN") && row["TIENTHANHTOAN"] != DBNull.Value) TIENTHANHTOAN = Convert.ToInt64(row["TIENTHANHTOAN"]);
if (row.Table.Columns.Contains("DATHANHTOAN") && row["DATHANHTOAN"] != DBNull.Value) DATHANHTOAN = Convert.ToInt32(row["DATHANHTOAN"]);
if (row.Table.Columns.Contains("TINHTHANH") && row["TINHTHANH"] != DBNull.Value) TINHTHANH = row["TINHTHANH"].ToString();
if (row.Table.Columns.Contains("QUANHUYEN") && row["QUANHUYEN"] != DBNull.Value) QUANHUYEN = row["QUANHUYEN"].ToString();
if (row.Table.Columns.Contains("PHUONGXA") && row["PHUONGXA"] != DBNull.Value) PHUONGXA = row["PHUONGXA"].ToString();
if (row.Table.Columns.Contains("DIACHI") && row["DIACHI"] != DBNull.Value) DIACHI = row["DIACHI"].ToString();
if (row.Table.Columns.Contains("DKHACHHANGID") && row["DKHACHHANGID"] != DBNull.Value) DKHACHHANGID = row["DKHACHHANGID"].ToString();
if (row.Table.Columns.Contains("LOAIGIA") && row["LOAIGIA"] != DBNull.Value) LOAIGIA = Convert.ToInt32(row["LOAIGIA"]);
if (row.Table.Columns.Contains("LOAIVANCHUYEN") && row["LOAIVANCHUYEN"] != DBNull.Value) LOAIVANCHUYEN = Convert.ToInt32(row["LOAIVANCHUYEN"]);
if (row.Table.Columns.Contains("DNHAXEID") && row["DNHAXEID"] != DBNull.Value) DNHAXEID = row["DNHAXEID"].ToString();
if (row.Table.Columns.Contains("DNHANVIENID") && row["DNHANVIENID"] != DBNull.Value) DNHANVIENID = row["DNHANVIENID"].ToString();
if (row.Table.Columns.Contains("TMPCODE") && row["TMPCODE"] != DBNull.Value) TMPCODE = row["TMPCODE"].ToString();
if (row.Table.Columns.Contains("NOTE") && row["NOTE"] != DBNull.Value) NOTE = row["NOTE"].ToString();

                        }

                        public TDONHANGRow(string ID)
                {
                    this.ID = ID;
                    if (ID == null || ID.Length == 0) InitWithoutParam();
                    else
                    {
                        DataRow row = db.GetFirstRow("select * from TDONHANG where id = @id", attrs);
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
dic.Add("@LOAI", LOAI);
dic.Add("@NGAY", NGAY);
dic.Add("@NAME", NAME);
dic.Add("@TIENHANG", TIENHANG);
dic.Add("@PHIVANCHUYEN", PHIVANCHUYEN);
dic.Add("@TONGCONG", TONGCONG);
dic.Add("@TIENTHANHTOAN", TIENTHANHTOAN);
dic.Add("@DATHANHTOAN", DATHANHTOAN);
dic.Add("@TINHTHANH", TINHTHANH);
dic.Add("@QUANHUYEN", QUANHUYEN);
dic.Add("@PHUONGXA", PHUONGXA);
dic.Add("@DIACHI", DIACHI);
dic.Add("@DKHACHHANGID", DKHACHHANGID);
dic.Add("@LOAIGIA", LOAIGIA);
dic.Add("@LOAIVANCHUYEN", LOAIVANCHUYEN);
dic.Add("@DNHAXEID", DNHAXEID);
dic.Add("@DNHANVIENID", DNHANVIENID);
dic.Add("@TMPCODE", TMPCODE);
dic.Add("@NOTE", NOTE);

                                return dic;
                            }
                        }

                        public DataRow ToRow(DataTable dt)
                        {
                            DataRow row = dt.NewRow();
                            row["ID"] = ID;
row["TIMECREATED"] = TIMECREATED;
row["LOAI"] = LOAI;
row["NGAY"] = NGAY;
row["NAME"] = NAME;
row["TIENHANG"] = TIENHANG;
row["PHIVANCHUYEN"] = PHIVANCHUYEN;
row["TONGCONG"] = TONGCONG;
row["TIENTHANHTOAN"] = TIENTHANHTOAN;
row["DATHANHTOAN"] = DATHANHTOAN;
row["TINHTHANH"] = TINHTHANH;
row["QUANHUYEN"] = QUANHUYEN;
row["PHUONGXA"] = PHUONGXA;
row["DIACHI"] = DIACHI;
row["DKHACHHANGID"] = DKHACHHANGID;
row["LOAIGIA"] = LOAIGIA;
row["LOAIVANCHUYEN"] = LOAIVANCHUYEN;
row["DNHAXEID"] = DNHAXEID;
row["DNHANVIENID"] = DNHANVIENID;
row["TMPCODE"] = TMPCODE;
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
                        querySql = "insert into TDONHANG(" + p1 + ") values(" + p2 + ")";
                    }
                    else
                    {
                        querySql = "update TDONHANG set " + querySql + @" where ID = @ID";
                    }
                    return db.ExSql(querySql, attrs) > 0;
                }

                        
                public void Delete()
                {
                    db.ExSql("delete TDONHANG from id = @id", attrs);
                }
                    }
                }