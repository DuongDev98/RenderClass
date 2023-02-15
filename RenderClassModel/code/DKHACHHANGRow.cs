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
                            if (row.Table.Columns.Contains("ID") && row["ID"] != DBNull.Value) ID = row["ID"].ToString();
if (row.Table.Columns.Contains("NAME") && row["NAME"] != DBNull.Value) NAME = row["NAME"].ToString();
if (row.Table.Columns.Contains("DIENTHOAI") && row["DIENTHOAI"] != DBNull.Value) DIENTHOAI = row["DIENTHOAI"].ToString();
if (row.Table.Columns.Contains("TINHTHANH") && row["TINHTHANH"] != DBNull.Value) TINHTHANH = row["TINHTHANH"].ToString();
if (row.Table.Columns.Contains("QUANHUYEN") && row["QUANHUYEN"] != DBNull.Value) QUANHUYEN = row["QUANHUYEN"].ToString();
if (row.Table.Columns.Contains("PHUONGXA") && row["PHUONGXA"] != DBNull.Value) PHUONGXA = row["PHUONGXA"].ToString();
if (row.Table.Columns.Contains("DIACHI") && row["DIACHI"] != DBNull.Value) DIACHI = row["DIACHI"].ToString();
if (row.Table.Columns.Contains("NOTE") && row["NOTE"] != DBNull.Value) NOTE = row["NOTE"].ToString();
if (row.Table.Columns.Contains("USERNAME") && row["USERNAME"] != DBNull.Value) USERNAME = row["USERNAME"].ToString();
if (row.Table.Columns.Contains("PASSWORD") && row["PASSWORD"] != DBNull.Value) PASSWORD = row["PASSWORD"].ToString();
if (row.Table.Columns.Contains("DNHOMKHACHHANGID") && row["DNHOMKHACHHANGID"] != DBNull.Value) DNHOMKHACHHANGID = row["DNHOMKHACHHANGID"].ToString();
if (row.Table.Columns.Contains("LOAIVANCHUYEN") && row["LOAIVANCHUYEN"] != DBNull.Value) LOAIVANCHUYEN = Convert.ToInt32(row["LOAIVANCHUYEN"]);
if (row.Table.Columns.Contains("DNHAXEID") && row["DNHAXEID"] != DBNull.Value) DNHAXEID = row["DNHAXEID"].ToString();
if (row.Table.Columns.Contains("EMAIL") && row["EMAIL"] != DBNull.Value) EMAIL = row["EMAIL"].ToString();

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
                                dic.Add("@ID", ID);
dic.Add("@NAME", NAME);
dic.Add("@DIENTHOAI", DIENTHOAI);
dic.Add("@TINHTHANH", TINHTHANH);
dic.Add("@QUANHUYEN", QUANHUYEN);
dic.Add("@PHUONGXA", PHUONGXA);
dic.Add("@DIACHI", DIACHI);
dic.Add("@NOTE", NOTE);
dic.Add("@USERNAME", USERNAME);
dic.Add("@PASSWORD", PASSWORD);
dic.Add("@DNHOMKHACHHANGID", DNHOMKHACHHANGID);
dic.Add("@LOAIVANCHUYEN", LOAIVANCHUYEN);
dic.Add("@DNHAXEID", DNHAXEID);
dic.Add("@EMAIL", EMAIL);

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
                        querySql = "insert into DKHACHHANG(" + p1 + ") values(" + p2 + ")";
                    }
                    else
                    {
                        querySql = "update DKHACHHANG set " + querySql + @" where ID = @ID";
                    }
                    return db.ExSql(querySql, attrs) > 0;
                }

                        
                public void Delete()
                {
                    db.ExSql("delete DKHACHHANG from id = @id", attrs);
                }
                    }
                }