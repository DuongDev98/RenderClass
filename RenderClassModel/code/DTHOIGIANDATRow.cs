using System;
                using System.Collections.Generic;
                using System.Data;
                using DuongNn.Db;

                namespace DuongNn.Mapping
                {
                    public class DTHOIGIANDATRow
                    {
                        Database db = new Database(DbConfig.server, DbConfig.user, DbConfig.password, DbConfig.database);
                        
                        public string ID { set; get; }
public string NAME { set; get; }


                        public DTHOIGIANDATRow()
                        {
                            InitWithoutParam();
                        }

                        private void InitWithoutParam()
                        {
                            ID = "";
NAME = "";

                        }

                        public DTHOIGIANDATRow(DataRow row)
                        {
                            InitWithDataRow(row);
                        }

                        private void InitWithDataRow(DataRow row)
                        {
                            if (row.Table.Columns.Contains("ID")) ID = row["ID"].ToString();
if (row.Table.Columns.Contains("NAME")) NAME = row["NAME"].ToString();

                        }

                        public DTHOIGIANDATRow(string ID)
                        {
                            this.ID = ID;
                            if (ID == null || ID.Length == 0) InitWithoutParam();
                            else
                            {
                                DataRow row = db.GetFirstRow("select * from DTHOIGIANDAT where id = @id", attrs);
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

                                return dic;
                            }
                        }

                        public DataRow ToRow(DataTable dt)
                        {
                            DataRow row = dt.NewRow();
                            row["ID"] = ID;
row["NAME"] = NAME;

                            return row;
                        }

                        public bool Update()
                        {
                            if (ID == null || ID.Length == 0)
                            {
                                ID = Guid.NewGuid().ToString();
                                return db.ExSql("insert into DTHOIGIANDAT(ID, NAME) values(@ID, @NAME)", attrs) > 0;
                            }
                            else
                            {
                                return db.ExSql("update set ID=@ID, NAME=@NAME where id = @id", attrs) > 0;
                                }
                            }

                        public void Delete()
                        {
                            db.ExSql("delete DTHOIGIANDAT from id = @id", attrs);
                        }
                    }
                }