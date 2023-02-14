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
                            if (row.Table.Columns.Contains("ID")) ID = row["ID"].ToString();
if (row.Table.Columns.Contains("TIMECREATED")) TIMECREATED = Convert.ToDateTime(row["TIMECREATED"]);
if (row.Table.Columns.Contains("LOAI")) LOAI = Convert.ToInt32(row["LOAI"]);
if (row.Table.Columns.Contains("NGAY")) NGAY = Convert.ToDateTime(row["NGAY"]);
if (row.Table.Columns.Contains("NAME")) NAME = row["NAME"].ToString();
if (row.Table.Columns.Contains("TIENHANG")) TIENHANG = Convert.ToInt64(row["TIENHANG"]);
if (row.Table.Columns.Contains("PHIVANCHUYEN")) PHIVANCHUYEN = Convert.ToInt64(row["PHIVANCHUYEN"]);
if (row.Table.Columns.Contains("TONGCONG")) TONGCONG = Convert.ToInt64(row["TONGCONG"]);
if (row.Table.Columns.Contains("TIENTHANHTOAN")) TIENTHANHTOAN = Convert.ToInt64(row["TIENTHANHTOAN"]);
if (row.Table.Columns.Contains("DATHANHTOAN")) DATHANHTOAN = Convert.ToInt32(row["DATHANHTOAN"]);
if (row.Table.Columns.Contains("TINHTHANH")) TINHTHANH = row["TINHTHANH"].ToString();
if (row.Table.Columns.Contains("QUANHUYEN")) QUANHUYEN = row["QUANHUYEN"].ToString();
if (row.Table.Columns.Contains("PHUONGXA")) PHUONGXA = row["PHUONGXA"].ToString();
if (row.Table.Columns.Contains("DIACHI")) DIACHI = row["DIACHI"].ToString();
if (row.Table.Columns.Contains("DKHACHHANGID")) DKHACHHANGID = row["DKHACHHANGID"].ToString();
if (row.Table.Columns.Contains("LOAIGIA")) LOAIGIA = Convert.ToInt32(row["LOAIGIA"]);
if (row.Table.Columns.Contains("LOAIVANCHUYEN")) LOAIVANCHUYEN = Convert.ToInt32(row["LOAIVANCHUYEN"]);
if (row.Table.Columns.Contains("DNHAXEID")) DNHAXEID = row["DNHAXEID"].ToString();
if (row.Table.Columns.Contains("DNHANVIENID")) DNHANVIENID = row["DNHANVIENID"].ToString();
if (row.Table.Columns.Contains("TMPCODE")) TMPCODE = row["TMPCODE"].ToString();
if (row.Table.Columns.Contains("NOTE")) NOTE = row["NOTE"].ToString();

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
                                dic.Add("ID", ID);
dic.Add("TIMECREATED", TIMECREATED);
dic.Add("LOAI", LOAI);
dic.Add("NGAY", NGAY);
dic.Add("NAME", NAME);
dic.Add("TIENHANG", TIENHANG);
dic.Add("PHIVANCHUYEN", PHIVANCHUYEN);
dic.Add("TONGCONG", TONGCONG);
dic.Add("TIENTHANHTOAN", TIENTHANHTOAN);
dic.Add("DATHANHTOAN", DATHANHTOAN);
dic.Add("TINHTHANH", TINHTHANH);
dic.Add("QUANHUYEN", QUANHUYEN);
dic.Add("PHUONGXA", PHUONGXA);
dic.Add("DIACHI", DIACHI);
dic.Add("DKHACHHANGID", DKHACHHANGID);
dic.Add("LOAIGIA", LOAIGIA);
dic.Add("LOAIVANCHUYEN", LOAIVANCHUYEN);
dic.Add("DNHAXEID", DNHAXEID);
dic.Add("DNHANVIENID", DNHANVIENID);
dic.Add("TMPCODE", TMPCODE);
dic.Add("NOTE", NOTE);

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
                            if (ID == null || ID.Length == 0)
                            {
                                ID = Guid.NewGuid().ToString();
                                return db.ExSql("insert into TDONHANG(ID, TIMECREATED, LOAI, NGAY, NAME, TIENHANG, PHIVANCHUYEN, TONGCONG, TIENTHANHTOAN, DATHANHTOAN, TINHTHANH, QUANHUYEN, PHUONGXA, DIACHI, DKHACHHANGID, LOAIGIA, LOAIVANCHUYEN, DNHAXEID, DNHANVIENID, TMPCODE, NOTE) values(@ID, @TIMECREATED, @LOAI, @NGAY, @NAME, @TIENHANG, @PHIVANCHUYEN, @TONGCONG, @TIENTHANHTOAN, @DATHANHTOAN, @TINHTHANH, @QUANHUYEN, @PHUONGXA, @DIACHI, @DKHACHHANGID, @LOAIGIA, @LOAIVANCHUYEN, @DNHAXEID, @DNHANVIENID, @TMPCODE, @NOTE)", attrs) > 0;
                            }
                            else
                            {
                                return db.ExSql("update set ID=@ID, TIMECREATED=@TIMECREATED, LOAI=@LOAI, NGAY=@NGAY, NAME=@NAME, TIENHANG=@TIENHANG, PHIVANCHUYEN=@PHIVANCHUYEN, TONGCONG=@TONGCONG, TIENTHANHTOAN=@TIENTHANHTOAN, DATHANHTOAN=@DATHANHTOAN, TINHTHANH=@TINHTHANH, QUANHUYEN=@QUANHUYEN, PHUONGXA=@PHUONGXA, DIACHI=@DIACHI, DKHACHHANGID=@DKHACHHANGID, LOAIGIA=@LOAIGIA, LOAIVANCHUYEN=@LOAIVANCHUYEN, DNHAXEID=@DNHAXEID, DNHANVIENID=@DNHANVIENID, TMPCODE=@TMPCODE, NOTE=@NOTE where id = @id", attrs) > 0;
                                }
                            }

                        public void Delete()
                        {
                            db.ExSql("delete TDONHANG from id = @id", attrs);
                        }
                    }
                }