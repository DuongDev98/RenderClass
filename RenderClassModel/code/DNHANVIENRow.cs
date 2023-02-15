using System;
                using System.Collections.Generic;
                using System.Data;
                using DuongNn.Db;

                namespace DuongNn.Mapping
                {
                    public class DNHANVIENRow
                    {
                        Database db = new Database(DbConfig.server, DbConfig.user, DbConfig.password, DbConfig.database);
                        
                        public string ID { set; get; }
public string NAME { set; get; }
public string DIENTHOAI { set; get; }
public string DIACHI { set; get; }
public string NOTE { set; get; }
public int LOAITAIKHOAN { set; get; }


                        public DNHANVIENRow()
                        {
                            InitWithoutParam();
                        }

                        private void InitWithoutParam()
                        {
                            ID = "";
NAME = "";
DIENTHOAI = "";
DIACHI = "";
NOTE = "";
LOAITAIKHOAN = 0;

                        }

                        public DNHANVIENRow(DataRow row)
                        {
                            InitWithDataRow(row);
                        }

                        private void InitWithDataRow(DataRow row)
                        {
                            if (row.Table.Columns.Contains("ID") && row["ID"] != DBNull.Value) ID = row["ID"].ToString();
if (row.Table.Columns.Contains("NAME") && row["NAME"] != DBNull.Value) NAME = row["NAME"].ToString();
if (row.Table.Columns.Contains("DIENTHOAI") && row["DIENTHOAI"] != DBNull.Value) DIENTHOAI = row["DIENTHOAI"].ToString();
if (row.Table.Columns.Contains("DIACHI") && row["DIACHI"] != DBNull.Value) DIACHI = row["DIACHI"].ToString();
if (row.Table.Columns.Contains("NOTE") && row["NOTE"] != DBNull.Value) NOTE = row["NOTE"].ToString();
if (row.Table.Columns.Contains("LOAITAIKHOAN") && row["LOAITAIKHOAN"] != DBNull.Value) LOAITAIKHOAN = Convert.ToInt32(row["LOAITAIKHOAN"]);

                        }

                        public DNHANVIENRow(string ID)
                {
                    this.ID = ID;
                    if (ID == null || ID.Length == 0) InitWithoutParam();
                    else
                    {
                        DataRow row = db.GetFirstRow("select * from DNHANVIEN where id = @id", attrs);
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
dic.Add("@DIACHI", DIACHI);
dic.Add("@NOTE", NOTE);
dic.Add("@LOAITAIKHOAN", LOAITAIKHOAN);

                                return dic;
                            }
                        }

                        public DataRow ToRow(DataTable dt)
                        {
                            DataRow row = dt.NewRow();
                            row["ID"] = ID;
row["NAME"] = NAME;
row["DIENTHOAI"] = DIENTHOAI;
row["DIACHI"] = DIACHI;
row["NOTE"] = NOTE;
row["LOAITAIKHOAN"] = LOAITAIKHOAN;

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
                        querySql = "insert into DNHANVIEN(" + p1 + ") values(" + p2 + ")";
                    }
                    else
                    {
                        querySql = "update DNHANVIEN set " + querySql + @" where ID = @ID";
                    }
                    return db.ExSql(querySql, attrs) > 0;
                }

                        
                public void Delete()
                {
                    db.ExSql("delete DNHANVIEN from id = @id", attrs);
                }
                    }
                }