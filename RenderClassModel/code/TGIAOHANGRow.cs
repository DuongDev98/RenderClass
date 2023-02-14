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
                            if (row.Table.Columns.Contains("ID")) ID = row["ID"].ToString();
if (row.Table.Columns.Contains("TIMECREATED")) TIMECREATED = Convert.ToDateTime(row["TIMECREATED"]);
if (row.Table.Columns.Contains("NAME")) NAME = row["NAME"].ToString();
if (row.Table.Columns.Contains("NGAY")) NGAY = Convert.ToDateTime(row["NGAY"]);
if (row.Table.Columns.Contains("DKHACHHANGID")) DKHACHHANGID = row["DKHACHHANGID"].ToString();
if (row.Table.Columns.Contains("DNHANVIENID")) DNHANVIENID = row["DNHANVIENID"].ToString();
if (row.Table.Columns.Contains("TINHTHANH")) TINHTHANH = row["TINHTHANH"].ToString();
if (row.Table.Columns.Contains("QUANHUYEN")) QUANHUYEN = row["QUANHUYEN"].ToString();
if (row.Table.Columns.Contains("PHUONGXA")) PHUONGXA = row["PHUONGXA"].ToString();
if (row.Table.Columns.Contains("DIACHI")) DIACHI = row["DIACHI"].ToString();
if (row.Table.Columns.Contains("LOAIVANCHUYEN")) LOAIVANCHUYEN = Convert.ToInt32(row["LOAIVANCHUYEN"]);
if (row.Table.Columns.Contains("DNHAXEID")) DNHAXEID = row["DNHAXEID"].ToString();
if (row.Table.Columns.Contains("LABEL_GHTK")) LABEL_GHTK = row["LABEL_GHTK"].ToString();
if (row.Table.Columns.Contains("NOTE")) NOTE = row["NOTE"].ToString();
if (row.Table.Columns.Contains("PHIVANCHUYEN")) PHIVANCHUYEN = Convert.ToInt64(row["PHIVANCHUYEN"]);

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
                                dic.Add("ID", ID);
dic.Add("TIMECREATED", TIMECREATED);
dic.Add("NAME", NAME);
dic.Add("NGAY", NGAY);
dic.Add("DKHACHHANGID", DKHACHHANGID);
dic.Add("DNHANVIENID", DNHANVIENID);
dic.Add("TINHTHANH", TINHTHANH);
dic.Add("QUANHUYEN", QUANHUYEN);
dic.Add("PHUONGXA", PHUONGXA);
dic.Add("DIACHI", DIACHI);
dic.Add("LOAIVANCHUYEN", LOAIVANCHUYEN);
dic.Add("DNHAXEID", DNHAXEID);
dic.Add("LABEL_GHTK", LABEL_GHTK);
dic.Add("NOTE", NOTE);
dic.Add("PHIVANCHUYEN", PHIVANCHUYEN);

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
                            if (ID == null || ID.Length == 0)
                            {
                                ID = Guid.NewGuid().ToString();
                                return db.ExSql("insert into TGIAOHANG(ID, TIMECREATED, NAME, NGAY, DKHACHHANGID, DNHANVIENID, TINHTHANH, QUANHUYEN, PHUONGXA, DIACHI, LOAIVANCHUYEN, DNHAXEID, LABEL_GHTK, NOTE, PHIVANCHUYEN) values(@ID, @TIMECREATED, @NAME, @NGAY, @DKHACHHANGID, @DNHANVIENID, @TINHTHANH, @QUANHUYEN, @PHUONGXA, @DIACHI, @LOAIVANCHUYEN, @DNHAXEID, @LABEL_GHTK, @NOTE, @PHIVANCHUYEN)", attrs) > 0;
                            }
                            else
                            {
                                return db.ExSql("update set ID=@ID, TIMECREATED=@TIMECREATED, NAME=@NAME, NGAY=@NGAY, DKHACHHANGID=@DKHACHHANGID, DNHANVIENID=@DNHANVIENID, TINHTHANH=@TINHTHANH, QUANHUYEN=@QUANHUYEN, PHUONGXA=@PHUONGXA, DIACHI=@DIACHI, LOAIVANCHUYEN=@LOAIVANCHUYEN, DNHAXEID=@DNHAXEID, LABEL_GHTK=@LABEL_GHTK, NOTE=@NOTE, PHIVANCHUYEN=@PHIVANCHUYEN where id = @id", attrs) > 0;
                                }
                            }

                        public void Delete()
                        {
                            db.ExSql("delete TGIAOHANG from id = @id", attrs);
                        }
                    }
                }