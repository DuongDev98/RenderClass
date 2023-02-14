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
                            if (row.Table.Columns.Contains("ID")) ID = row["ID"].ToString();
if (row.Table.Columns.Contains("NAME")) NAME = row["NAME"].ToString();
if (row.Table.Columns.Contains("DIENTHOAI")) DIENTHOAI = row["DIENTHOAI"].ToString();
if (row.Table.Columns.Contains("DIACHI")) DIACHI = row["DIACHI"].ToString();
if (row.Table.Columns.Contains("NOTE")) NOTE = row["NOTE"].ToString();
if (row.Table.Columns.Contains("LOAITAIKHOAN")) LOAITAIKHOAN = Convert.ToInt32(row["LOAITAIKHOAN"]);

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
                                dic.Add("ID", ID);
dic.Add("NAME", NAME);
dic.Add("DIENTHOAI", DIENTHOAI);
dic.Add("DIACHI", DIACHI);
dic.Add("NOTE", NOTE);
dic.Add("LOAITAIKHOAN", LOAITAIKHOAN);

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
                            if (ID == null || ID.Length == 0)
                            {
                                ID = Guid.NewGuid().ToString();
                                return db.ExSql("insert into DNHANVIEN(ID, NAME, DIENTHOAI, DIACHI, NOTE, LOAITAIKHOAN) values(@ID, @NAME, @DIENTHOAI, @DIACHI, @NOTE, @LOAITAIKHOAN)", attrs) > 0;
                            }
                            else
                            {
                                return db.ExSql("update set ID=@ID, NAME=@NAME, DIENTHOAI=@DIENTHOAI, DIACHI=@DIACHI, NOTE=@NOTE, LOAITAIKHOAN=@LOAITAIKHOAN where id = @id", attrs) > 0;
                                }
                            }

                        public void Delete()
                        {
                            db.ExSql("delete DNHANVIEN from id = @id", attrs);
                        }
                    }
                }