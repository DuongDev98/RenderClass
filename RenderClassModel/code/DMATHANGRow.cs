using System;
                using System.Collections.Generic;
                using System.Data;
                using DuongNn.Db;

                namespace DuongNn.Mapping
                {
                    public class DMATHANGRow
                    {
                        Database db = new Database(DbConfig.server, DbConfig.user, DbConfig.password, DbConfig.database);
                        
                        public string ID { set; get; }
public string CODE { set; get; }
public string NAME { set; get; }
public string DNHOMHANGID { set; get; }
public string DPHANLOAIID { set; get; }
public string DDANGID { set; get; }
public string DTHOIGIANDATID { set; get; }
public long GIABAN { set; get; }
public long GIABAN2 { set; get; }
public long GIABAN3 { set; get; }
public long GIABAN4 { set; get; }
public long GIABAN5 { set; get; }
public long GIABAN6 { set; get; }
public long GIABAN7 { set; get; }
public long GIABAN8 { set; get; }
public int NOIBAT { set; get; }
public int HANGSALE { set; get; }
public int BANAMKHO { set; get; }
public DateTime TIMECREATED { set; get; }
public decimal KHOILUONG { set; get; }
public decimal DAI { set; get; }
public decimal RONG { set; get; }
public decimal CAO { set; get; }
public long GIANHAP { set; get; }


                        public DMATHANGRow()
                        {
                            InitWithoutParam();
                        }

                        private void InitWithoutParam()
                        {
                            ID = "";
CODE = "";
NAME = "";
DNHOMHANGID = "";
DPHANLOAIID = "";
DDANGID = "";
DTHOIGIANDATID = "";
GIABAN = 0;
GIABAN2 = 0;
GIABAN3 = 0;
GIABAN4 = 0;
GIABAN5 = 0;
GIABAN6 = 0;
GIABAN7 = 0;
GIABAN8 = 0;
NOIBAT = 0;
HANGSALE = 0;
BANAMKHO = 0;
TIMECREATED = DateTime.Now;
KHOILUONG = 0;
DAI = 0;
RONG = 0;
CAO = 0;
GIANHAP = 0;

                        }

                        public DMATHANGRow(DataRow row)
                        {
                            InitWithDataRow(row);
                        }

                        private void InitWithDataRow(DataRow row)
                        {
                            if (row.Table.Columns.Contains("ID") && row["ID"] != DBNull.Value) ID = row["ID"].ToString();
if (row.Table.Columns.Contains("CODE") && row["CODE"] != DBNull.Value) CODE = row["CODE"].ToString();
if (row.Table.Columns.Contains("NAME") && row["NAME"] != DBNull.Value) NAME = row["NAME"].ToString();
if (row.Table.Columns.Contains("DNHOMHANGID") && row["DNHOMHANGID"] != DBNull.Value) DNHOMHANGID = row["DNHOMHANGID"].ToString();
if (row.Table.Columns.Contains("DPHANLOAIID") && row["DPHANLOAIID"] != DBNull.Value) DPHANLOAIID = row["DPHANLOAIID"].ToString();
if (row.Table.Columns.Contains("DDANGID") && row["DDANGID"] != DBNull.Value) DDANGID = row["DDANGID"].ToString();
if (row.Table.Columns.Contains("DTHOIGIANDATID") && row["DTHOIGIANDATID"] != DBNull.Value) DTHOIGIANDATID = row["DTHOIGIANDATID"].ToString();
if (row.Table.Columns.Contains("GIABAN") && row["GIABAN"] != DBNull.Value) GIABAN = Convert.ToInt64(row["GIABAN"]);
if (row.Table.Columns.Contains("GIABAN2") && row["GIABAN2"] != DBNull.Value) GIABAN2 = Convert.ToInt64(row["GIABAN2"]);
if (row.Table.Columns.Contains("GIABAN3") && row["GIABAN3"] != DBNull.Value) GIABAN3 = Convert.ToInt64(row["GIABAN3"]);
if (row.Table.Columns.Contains("GIABAN4") && row["GIABAN4"] != DBNull.Value) GIABAN4 = Convert.ToInt64(row["GIABAN4"]);
if (row.Table.Columns.Contains("GIABAN5") && row["GIABAN5"] != DBNull.Value) GIABAN5 = Convert.ToInt64(row["GIABAN5"]);
if (row.Table.Columns.Contains("GIABAN6") && row["GIABAN6"] != DBNull.Value) GIABAN6 = Convert.ToInt64(row["GIABAN6"]);
if (row.Table.Columns.Contains("GIABAN7") && row["GIABAN7"] != DBNull.Value) GIABAN7 = Convert.ToInt64(row["GIABAN7"]);
if (row.Table.Columns.Contains("GIABAN8") && row["GIABAN8"] != DBNull.Value) GIABAN8 = Convert.ToInt64(row["GIABAN8"]);
if (row.Table.Columns.Contains("NOIBAT") && row["NOIBAT"] != DBNull.Value) NOIBAT = Convert.ToInt32(row["NOIBAT"]);
if (row.Table.Columns.Contains("HANGSALE") && row["HANGSALE"] != DBNull.Value) HANGSALE = Convert.ToInt32(row["HANGSALE"]);
if (row.Table.Columns.Contains("BANAMKHO") && row["BANAMKHO"] != DBNull.Value) BANAMKHO = Convert.ToInt32(row["BANAMKHO"]);
if (row.Table.Columns.Contains("TIMECREATED") && row["TIMECREATED"] != DBNull.Value) TIMECREATED = Convert.ToDateTime(row["TIMECREATED"]);
if (row.Table.Columns.Contains("KHOILUONG") && row["KHOILUONG"] != DBNull.Value) KHOILUONG = Convert.ToDecimal(row["KHOILUONG"]);
if (row.Table.Columns.Contains("DAI") && row["DAI"] != DBNull.Value) DAI = Convert.ToDecimal(row["DAI"]);
if (row.Table.Columns.Contains("RONG") && row["RONG"] != DBNull.Value) RONG = Convert.ToDecimal(row["RONG"]);
if (row.Table.Columns.Contains("CAO") && row["CAO"] != DBNull.Value) CAO = Convert.ToDecimal(row["CAO"]);
if (row.Table.Columns.Contains("GIANHAP") && row["GIANHAP"] != DBNull.Value) GIANHAP = Convert.ToInt64(row["GIANHAP"]);

                        }

                        public DMATHANGRow(string ID)
                {
                    this.ID = ID;
                    if (ID == null || ID.Length == 0) InitWithoutParam();
                    else
                    {
                        DataRow row = db.GetFirstRow("select * from DMATHANG where id = @id", attrs);
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
dic.Add("@CODE", CODE);
dic.Add("@NAME", NAME);
dic.Add("@DNHOMHANGID", DNHOMHANGID);
dic.Add("@DPHANLOAIID", DPHANLOAIID);
dic.Add("@DDANGID", DDANGID);
dic.Add("@DTHOIGIANDATID", DTHOIGIANDATID);
dic.Add("@GIABAN", GIABAN);
dic.Add("@GIABAN2", GIABAN2);
dic.Add("@GIABAN3", GIABAN3);
dic.Add("@GIABAN4", GIABAN4);
dic.Add("@GIABAN5", GIABAN5);
dic.Add("@GIABAN6", GIABAN6);
dic.Add("@GIABAN7", GIABAN7);
dic.Add("@GIABAN8", GIABAN8);
dic.Add("@NOIBAT", NOIBAT);
dic.Add("@HANGSALE", HANGSALE);
dic.Add("@BANAMKHO", BANAMKHO);
dic.Add("@TIMECREATED", TIMECREATED);
dic.Add("@KHOILUONG", KHOILUONG);
dic.Add("@DAI", DAI);
dic.Add("@RONG", RONG);
dic.Add("@CAO", CAO);
dic.Add("@GIANHAP", GIANHAP);

                                return dic;
                            }
                        }

                        public DataRow ToRow(DataTable dt)
                        {
                            DataRow row = dt.NewRow();
                            row["ID"] = ID;
row["CODE"] = CODE;
row["NAME"] = NAME;
row["DNHOMHANGID"] = DNHOMHANGID;
row["DPHANLOAIID"] = DPHANLOAIID;
row["DDANGID"] = DDANGID;
row["DTHOIGIANDATID"] = DTHOIGIANDATID;
row["GIABAN"] = GIABAN;
row["GIABAN2"] = GIABAN2;
row["GIABAN3"] = GIABAN3;
row["GIABAN4"] = GIABAN4;
row["GIABAN5"] = GIABAN5;
row["GIABAN6"] = GIABAN6;
row["GIABAN7"] = GIABAN7;
row["GIABAN8"] = GIABAN8;
row["NOIBAT"] = NOIBAT;
row["HANGSALE"] = HANGSALE;
row["BANAMKHO"] = BANAMKHO;
row["TIMECREATED"] = TIMECREATED;
row["KHOILUONG"] = KHOILUONG;
row["DAI"] = DAI;
row["RONG"] = RONG;
row["CAO"] = CAO;
row["GIANHAP"] = GIANHAP;

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
                        querySql = "insert into DMATHANG(" + p1 + ") values(" + p2 + ")";
                    }
                    else
                    {
                        querySql = "update DMATHANG set " + querySql + @" where ID = @ID";
                    }
                    return db.ExSql(querySql, attrs) > 0;
                }

                        
                public void Delete()
                {
                    db.ExSql("delete DMATHANG from id = @id", attrs);
                }
                    }
                }