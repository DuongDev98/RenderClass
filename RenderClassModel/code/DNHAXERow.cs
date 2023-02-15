using System;
                using System.Collections.Generic;
                using System.Data;
                using DuongNn.Db;

                namespace DuongNn.Mapping
                {
                    public class DNHAXERow
                    {
                        Database db = new Database(DbConfig.server, DbConfig.user, DbConfig.password, DbConfig.database);
                        
                        public string ID { set; get; }
public string NAME { set; get; }
public string DIENTHOAI { set; get; }
public string BIENSO { set; get; }
public string GIOXECHAY { set; get; }
public string BENDO { set; get; }
public int XEOM { set; get; }


                        public DNHAXERow()
                        {
                            InitWithoutParam();
                        }

                        private void InitWithoutParam()
                        {
                            ID = "";
NAME = "";
DIENTHOAI = "";
BIENSO = "";
GIOXECHAY = "";
BENDO = "";
XEOM = 0;

                        }

                        public DNHAXERow(DataRow row)
                        {
                            InitWithDataRow(row);
                        }

                        private void InitWithDataRow(DataRow row)
                        {
                            if (row.Table.Columns.Contains("ID") && row["ID"] != DBNull.Value) ID = row["ID"].ToString();
if (row.Table.Columns.Contains("NAME") && row["NAME"] != DBNull.Value) NAME = row["NAME"].ToString();
if (row.Table.Columns.Contains("DIENTHOAI") && row["DIENTHOAI"] != DBNull.Value) DIENTHOAI = row["DIENTHOAI"].ToString();
if (row.Table.Columns.Contains("BIENSO") && row["BIENSO"] != DBNull.Value) BIENSO = row["BIENSO"].ToString();
if (row.Table.Columns.Contains("GIOXECHAY") && row["GIOXECHAY"] != DBNull.Value) GIOXECHAY = row["GIOXECHAY"].ToString();
if (row.Table.Columns.Contains("BENDO") && row["BENDO"] != DBNull.Value) BENDO = row["BENDO"].ToString();
if (row.Table.Columns.Contains("XEOM") && row["XEOM"] != DBNull.Value) XEOM = Convert.ToInt32(row["XEOM"]);

                        }

                        public DNHAXERow(string ID)
                {
                    this.ID = ID;
                    if (ID == null || ID.Length == 0) InitWithoutParam();
                    else
                    {
                        DataRow row = db.GetFirstRow("select * from DNHAXE where id = @id", attrs);
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
dic.Add("@BIENSO", BIENSO);
dic.Add("@GIOXECHAY", GIOXECHAY);
dic.Add("@BENDO", BENDO);
dic.Add("@XEOM", XEOM);

                                return dic;
                            }
                        }

                        public DataRow ToRow(DataTable dt)
                        {
                            DataRow row = dt.NewRow();
                            row["ID"] = ID;
row["NAME"] = NAME;
row["DIENTHOAI"] = DIENTHOAI;
row["BIENSO"] = BIENSO;
row["GIOXECHAY"] = GIOXECHAY;
row["BENDO"] = BENDO;
row["XEOM"] = XEOM;

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
                        querySql = "insert into DNHAXE(" + p1 + ") values(" + p2 + ")";
                    }
                    else
                    {
                        querySql = "update DNHAXE set " + querySql + @" where ID = @ID";
                    }
                    return db.ExSql(querySql, attrs) > 0;
                }

                        
                public void Delete()
                {
                    db.ExSql("delete DNHAXE from id = @id", attrs);
                }
                    }
                }