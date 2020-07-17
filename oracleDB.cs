using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Types;
using Oracle.ManagedDataAccess.Client;
using System.Net;

namespace WorkFlow
{
    public class OracleDB
    {
        public string connString = "Data Source=(DESCRIPTION =" +
                                                            "    (ADDRESS = (PROTOCOL = TCP)(HOST = 192.168.1.151)(PORT = 1521))" +
                                                            "    (CONNECT_DATA =" +
                                                            "    (SERVER = DEDICATED)" +
                                                             "   (SERVICE_NAME = hc)" +
                                                            "    )" +
                                                            "  ); Persist Security Info=True;User ID=dev;Password=hcoracle;"; 
        public DataSet ExecuteDataTable(string sql)//, params OracleParameter[] parameters)
        {
            using (OracleConnection conn = new OracleConnection(connString))
            {
                conn.Open();
                using (OracleCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    Console.WriteLine(sql);
                    //cmd.Parameters.AddRange(parameters);
                    OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                    DataSet datatable = new DataSet();
                    adapter.Fill(datatable);
                    Console.WriteLine("Number of rows : {0} ", datatable.Tables[0].Rows.Count);
                    return datatable;
                }
            }
        }



        public  int ExecuteSQL(String sql)
        {
            int count = 0;
            using (OracleConnection conn = new OracleConnection(connString))
            {
                conn.Open();
                using (OracleCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    //Console.WriteLine(sql);
                    count = cmd.ExecuteNonQuery();
                }
            }
            return count;
        }


        public  string ConnectOracle()
        {
            try
            {
                Console.WriteLine(connString);
                OracleConnection con = new OracleConnection(connString);
                con.Open();
                return string.Empty;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }


    }
}


