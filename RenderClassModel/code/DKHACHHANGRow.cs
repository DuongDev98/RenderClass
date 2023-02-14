using System;
                using System.Collections.Generic;
                using System.Data;
                using DuongNn.Db;

                namespace DuongNn.Mapping
                {
                    public class DKHACHHANGRow
                    {
                        Database db = new Database(DbConfig.server, DbConfig.user, DbConfig.password, DbConfig.database);
                        
                        public string ID { set; get; }
public string NAME { set; get; }
public string DIENTHOAI { set; get; }
public string TINHTHANH { set; get; }
public string QUANHUYEN { set; get; }
public string PHUONGXA { set; get; }
public string DIACHI { set; get; }
public string NOTE { set; get; }
public string USERNAME { set; get; }
public string PASSWORD { set; get; }
public string DNHOMKHACHHANGID { set; get; }
public int LOAIVANCHUYEN { set; get; }
public string DNHAXEID { set; get; }
public string EMAIL { set; get; }


                        public DKHACHHANGRow()
                        {
                            InitWithoutParam();
                        }

                        private void InitWithoutParam()
                        {
                            ID = "";
NAME = "";
DIENTHOAI = "";
TINHTHANH = "";
QUANHUYEN = "";
PHUONGXA = "";
DIACHI = "";
NOTE = "";
USERNAME = "";
PASSWORD = "";
DNHOMKHACHHANGID = "";
LOAIVANCHUYEN = 0;
DNHAXEID = "";
EMAIL = "";

                        }

                        public DKHACHHANGRow(DataRow row)
                        {
                            InitWithDataRow(row);
                        }

                        private void InitWithDataRow(DataRow row)
                        {
                            if (row.Table.Columns.Contains("ID")) ID = row["ID"].ToString();
if (row.Table.Columns.Contains("NAME")) NAME = row["NAME"].ToString();
if (row.Table.Columns.Contains("DIENTHOAI")) DIENTHOAI = row["DIENTHOAI"].ToString();
if (row.Table.Columns.Contains("TINHTHANH")) TINHTHANH = row["TINHTHANH"].ToString();
if (row.Table.Columns.Contains("QUANHUYEN")) QUANHUYEN = row["QUANHUYEN"].ToString();
if (row.Table.Columns.Contains("PHUONGXA")) PHUONGXA = row["PHUONGXA"].ToString();
if (row.Table.Columns.Contains("DIACHI")) DIACHI = row["DIACHI"].ToString();
if (row.Table.Columns.Contains("NOTE")) NOTE = row["NOTE"].ToString();
if (row.Table.Columns.Contains("USERNAME")) USERNAME = row["USERNAME"].ToString();
if (row.Table.Columns.Contains("PASSWORD")) PASSWORD = row["PASSWORD"].ToString();
if (row.Table.Columns.Contains("DNHOMKHACHHANGID")) DNHOMKHACHHANGID = row["DNHOMKHACHHANGID"].ToString();
if (row.Table.Columns.Contains("LOAIVANCHUYEN")) LOAIVANCHUYEN = Convert.ToInt32(row["LOAIVANCHUYEN"]);
if (row.Table.Columns.Contains("DNHAXEID")) DNHAXEID = row["DNHAXEID"].ToString();
if (row.Table.Columns.Contains("EMAIL")) EMAIL = row["EMAIL"].ToString();

                        }

                        public DKHACHHANGRow(string ID)
                        {
                            this.ID = ID;
                            if (ID == null || ID.Length == 0) InitWithoutParam();
                            else
                            {
                                DataRow row = db.GetFirstRow("select * from DKHACHHANG where id = @id", attrs);
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
dic.Add("NAME", NAME);
dic.Add("DIENTHOAI", DIENTHOAI);
dic.Add("TINHTHANH", TINHTHANH);
dic.Add("QUANHUYEN", QUANHUYEN);
dic.Add("PHUONGXA", PHUONGXA);
dic.Add("DIACHI", DIACHI);
dic.Add("NOTE", NOTE);
dic.Add("USERNAME", USERNAME);
dic.Add("PASSWORD", PASSWORD);
dic.Add("DNHOMKHACHHANGID", DNHOMKHACHHANGID);
dic.Add("LOAIVANCHUYEN", LOAIVANCHUYEN);
dic.Add("DNHAXEID", DNHAXEID);
dic.Add("EMAIL", EMAIL);

                                return dic;
                            }
                        }

                        public DataRow ToRow(DataTable dt)
                        {
                            DataRow row = dt.NewRow();
                            row["ID"] = ID;
row["NAME"] = NAME;
row["DIENTHOAI"] = DIENTHOAI;
row["TINHTHANH"] = TINHTHANH;
row["QUANHUYEN"] = QUANHUYEN;
row["PHUONGXA"] = PHUONGXA;
row["DIACHI"] = DIACHI;
row["NOTE"] = NOTE;
row["USERNAME"] = USERNAME;
row["PASSWORD"] = PASSWORD;
row["DNHOMKHACHHANGID"] = DNHOMKHACHHANGID;
row["LOAIVANCHUYEN"] = LOAIVANCHUYEN;
row["DNHAXEID"] = DNHAXEID;
row["EMAIL"] = EMAIL;

                            return row;
                        }

                        public bool Update()
                        {
                            if (ID == null || ID.Length == 0)
                            {
                                ID = Guid.NewGuid().ToString();
                                return db.ExSql("insert into DKHACHHANG(ID, NAME, DIENTHOAI, TINHTHANH, QUANHUYEN, PHUONGXA, DIACHI, NOTE, USERNAME, PASSWORD, DNHOMKHACHHANGID, LOAIVANCHUYEN, DNHAXEID, EMAIL) values(@ID, @NAME, @DIENTHOAI, @TINHTHANH, @QUANHUYEN, @PHUONGXA, @DIACHI, @NOTE, @USERNAME, @PASSWORD, @DNHOMKHACHHANGID, @LOAIVANCHUYEN, @DNHAXEID, @EMAIL)", attrs) > 0;
                            }
                            else
                            {
                                return db.ExSql("update set ID=@ID, NAME=@NAME, DIENTHOAI=@DIENTHOAI, TINHTHANH=@TINHTHANH, QUANHUYEN=@QUANHUYEN, PHUONGXA=@PHUONGXA, DIACHI=@DIACHI, NOTE=@NOTE, USERNAME=@USERNAME, PASSWORD=@PASSWORD, DNHOMKHACHHANGID=@DNHOMKHACHHANGID, LOAIVANCHUYEN=@LOAIVANCHUYEN, DNHAXEID=@DNHAXEID, EMAIL=@EMAIL where id = @id", attrs) > 0;
                                }
                            }

                        public void Delete()
                        {
                            db.ExSql("delete DKHACHHANG from id = @id", attrs);
                        }
                    }
                }