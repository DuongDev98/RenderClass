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
                            if (row.Table.Columns.Contains("ID")) ID = row["ID"].ToString();
if (row.Table.Columns.Contains("CODE")) CODE = row["CODE"].ToString();
if (row.Table.Columns.Contains("NAME")) NAME = row["NAME"].ToString();
if (row.Table.Columns.Contains("DNHOMHANGID")) DNHOMHANGID = row["DNHOMHANGID"].ToString();
if (row.Table.Columns.Contains("DPHANLOAIID")) DPHANLOAIID = row["DPHANLOAIID"].ToString();
if (row.Table.Columns.Contains("DDANGID")) DDANGID = row["DDANGID"].ToString();
if (row.Table.Columns.Contains("DTHOIGIANDATID")) DTHOIGIANDATID = row["DTHOIGIANDATID"].ToString();
if (row.Table.Columns.Contains("GIABAN")) GIABAN = Convert.ToInt64(row["GIABAN"]);
if (row.Table.Columns.Contains("GIABAN2")) GIABAN2 = Convert.ToInt64(row["GIABAN2"]);
if (row.Table.Columns.Contains("GIABAN3")) GIABAN3 = Convert.ToInt64(row["GIABAN3"]);
if (row.Table.Columns.Contains("GIABAN4")) GIABAN4 = Convert.ToInt64(row["GIABAN4"]);
if (row.Table.Columns.Contains("GIABAN5")) GIABAN5 = Convert.ToInt64(row["GIABAN5"]);
if (row.Table.Columns.Contains("GIABAN6")) GIABAN6 = Convert.ToInt64(row["GIABAN6"]);
if (row.Table.Columns.Contains("GIABAN7")) GIABAN7 = Convert.ToInt64(row["GIABAN7"]);
if (row.Table.Columns.Contains("GIABAN8")) GIABAN8 = Convert.ToInt64(row["GIABAN8"]);
if (row.Table.Columns.Contains("NOIBAT")) NOIBAT = Convert.ToInt32(row["NOIBAT"]);
if (row.Table.Columns.Contains("HANGSALE")) HANGSALE = Convert.ToInt32(row["HANGSALE"]);
if (row.Table.Columns.Contains("BANAMKHO")) BANAMKHO = Convert.ToInt32(row["BANAMKHO"]);
if (row.Table.Columns.Contains("TIMECREATED")) TIMECREATED = Convert.ToDateTime(row["TIMECREATED"]);
if (row.Table.Columns.Contains("KHOILUONG")) KHOILUONG = Convert.ToDecimal(row["KHOILUONG"]);
if (row.Table.Columns.Contains("DAI")) DAI = Convert.ToDecimal(row["DAI"]);
if (row.Table.Columns.Contains("RONG")) RONG = Convert.ToDecimal(row["RONG"]);
if (row.Table.Columns.Contains("CAO")) CAO = Convert.ToDecimal(row["CAO"]);
if (row.Table.Columns.Contains("GIANHAP")) GIANHAP = Convert.ToInt64(row["GIANHAP"]);

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
                                dic.Add("ID", ID);
dic.Add("CODE", CODE);
dic.Add("NAME", NAME);
dic.Add("DNHOMHANGID", DNHOMHANGID);
dic.Add("DPHANLOAIID", DPHANLOAIID);
dic.Add("DDANGID", DDANGID);
dic.Add("DTHOIGIANDATID", DTHOIGIANDATID);
dic.Add("GIABAN", GIABAN);
dic.Add("GIABAN2", GIABAN2);
dic.Add("GIABAN3", GIABAN3);
dic.Add("GIABAN4", GIABAN4);
dic.Add("GIABAN5", GIABAN5);
dic.Add("GIABAN6", GIABAN6);
dic.Add("GIABAN7", GIABAN7);
dic.Add("GIABAN8", GIABAN8);
dic.Add("NOIBAT", NOIBAT);
dic.Add("HANGSALE", HANGSALE);
dic.Add("BANAMKHO", BANAMKHO);
dic.Add("TIMECREATED", TIMECREATED);
dic.Add("KHOILUONG", KHOILUONG);
dic.Add("DAI", DAI);
dic.Add("RONG", RONG);
dic.Add("CAO", CAO);
dic.Add("GIANHAP", GIANHAP);

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
                            if (ID == null || ID.Length == 0)
                            {
                                ID = Guid.NewGuid().ToString();
                                return db.ExSql("insert into DMATHANG(ID, CODE, NAME, DNHOMHANGID, DPHANLOAIID, DDANGID, DTHOIGIANDATID, GIABAN, GIABAN2, GIABAN3, GIABAN4, GIABAN5, GIABAN6, GIABAN7, GIABAN8, NOIBAT, HANGSALE, BANAMKHO, TIMECREATED, KHOILUONG, DAI, RONG, CAO, GIANHAP) values(@ID, @CODE, @NAME, @DNHOMHANGID, @DPHANLOAIID, @DDANGID, @DTHOIGIANDATID, @GIABAN, @GIABAN2, @GIABAN3, @GIABAN4, @GIABAN5, @GIABAN6, @GIABAN7, @GIABAN8, @NOIBAT, @HANGSALE, @BANAMKHO, @TIMECREATED, @KHOILUONG, @DAI, @RONG, @CAO, @GIANHAP)", attrs) > 0;
                            }
                            else
                            {
                                return db.ExSql("update set ID=@ID, CODE=@CODE, NAME=@NAME, DNHOMHANGID=@DNHOMHANGID, DPHANLOAIID=@DPHANLOAIID, DDANGID=@DDANGID, DTHOIGIANDATID=@DTHOIGIANDATID, GIABAN=@GIABAN, GIABAN2=@GIABAN2, GIABAN3=@GIABAN3, GIABAN4=@GIABAN4, GIABAN5=@GIABAN5, GIABAN6=@GIABAN6, GIABAN7=@GIABAN7, GIABAN8=@GIABAN8, NOIBAT=@NOIBAT, HANGSALE=@HANGSALE, BANAMKHO=@BANAMKHO, TIMECREATED=@TIMECREATED, KHOILUONG=@KHOILUONG, DAI=@DAI, RONG=@RONG, CAO=@CAO, GIANHAP=@GIANHAP where id = @id", attrs) > 0;
                                }
                            }

                        public void Delete()
                        {
                            db.ExSql("delete DMATHANG from id = @id", attrs);
                        }
                    }
                }