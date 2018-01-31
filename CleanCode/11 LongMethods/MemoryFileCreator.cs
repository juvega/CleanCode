using System;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace FooFoo
{
    public partial class Download
    {
        public class DataTableToCsvMapper
        {
            public MemoryStream Map(DataTable dataTable)
            {
                MemoryStream ReturnStream = new MemoryStream();                
                StreamWriter sw = new StreamWriter(ReturnStream);
                WriteColumnsNames(dataTable, sw);
                WriteRows(dataTable, sw);
                sw.Flush();
                sw.Close();
                return ReturnStream;
            }

            private static void WriteRows(DataTable dt, StreamWriter sw)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {

                        if (!Convert.IsDBNull(dr[i]))
                        {
                            string str = String.Format("\"{0:c}\"", dr[i].ToString()).Replace("\r\n", " ");
                            sw.Write(str);
                        }
                        else
                        {
                            sw.Write("");
                        }

                        if (i < dt.Columns.Count - 1)
                        {
                            sw.Write(",");
                        }
                    }
                    sw.WriteLine();
                }
            }

            private static void WriteColumnsNames(DataTable dt, StreamWriter sw)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    sw.Write(dt.Columns[i]);
                    if (i < dt.Columns.Count - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.WriteLine();
            }

            
        }
    }

    public class TableReader
    {
        public DataTable GetDataTable()
        {
            string strConn = ConfigurationManager.ConnectionStrings["FooFooConnectionString"].ToString();
            SqlConnection conn = new SqlConnection(strConn);
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [FooFoo] ORDER BY id ASC", conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "FooFoo");
            DataTable dt = ds.Tables["FooFoo"];
            return dt;
        }
    }
}