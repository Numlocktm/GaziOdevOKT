using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class Helper : IDisposable
    {
        SqlConnection cn;
        SqlCommand cmd;
        string cstr = ConfigurationManager.ConnectionStrings["cstr"].ConnectionString;

        private static Helper hlp;
        private Helper() { }
      
        public static Helper helper
        {
            get
            {
                if (hlp == null)
                {
                    hlp = new Helper();
                    
                }
                return hlp;
            }
        }


        public int ExecuteNonQuery(string cmdtext, SqlParameter[] p = null)
        {
            try
            {

                using (cn = new SqlConnection(cstr))
                {
                    using (cmd = new SqlCommand(cmdtext, cn))
                    {
                        if (p != null)
                        {
                            cmd.Parameters.AddRange(p);
                        }
                        cn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public SqlDataReader ExecuteReader(string cmdtext, SqlParameter[] p = null)
        {
            try
            {
                cn = new SqlConnection(cstr);
                cmd = new SqlCommand(cmdtext, cn);
                if (p != null)
                {
                    cmd.Parameters.AddRange(p);
                }
                cn.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Dispose()
        {
            if (cn != null)
            {
                cn.Close();
                cn.Dispose();
                cn = null;
            }
            if (cmd != null)
            {
                cmd.Dispose();
                cmd = null;
            }
        }
    }
}