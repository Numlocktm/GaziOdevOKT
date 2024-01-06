using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class Helper : IDisposable  //Bu sınıfın IDisposable arayüzünü uyguladığını belirtir.
                                       //Bu, sınıfın Dispose metodunu içermesini gerektirir.
                                       //IDisposable arayüzü, sınıfın kaynaklarını temizlemesini ve serbest bırakmasını sağlar.
    {
        private static Helper instance; // Bu özel kurucu metod, sınıfın dışarıdan erişilebilir olmasını engeller.
                                        // Helper sınıfının sadece içerisindeki GetInstance metoduyla örneğini alabiliriz.
                                        // Böylece sınıfın yalnızca tek bir örneği olur.
        private SqlConnection cn;
        private SqlCommand cmd;
        private string cstr = ConfigurationManager.ConnectionStrings["cstr"].ConnectionString;

        private Helper() { } // Constructor private yapılır singleton pattern uygulanabilmesi için tüm uygulama boyunca tek bi noktadan erişilmeli.

        public static Helper GetInstance()  // Bu metod, sınıfın yalnızca bir örneğini döndürür.
                                            // Eğer instance örneği null ise, yeni bir örnek oluşturur ve döndürür.
                                            // Aksi takdirde, var olan örneği döndürür.
        {
            if (instance == null)
            {
                instance = new Helper();
            }
            return instance;
        }

        public void Dispose()
        {
            if (cn != null && cn.State != ConnectionState.Closed)
            {
                cn.Close();
                cn.Dispose();
            }

            if (cmd != null)
            {
                cmd.Dispose();
            }
        }

        public int ExecuteNonQuery(string cmdtext, SqlParameter[] p = null)     // 1. TRY-CATCH EKLEME
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
            catch (SqlException ex)
            {

                Console.WriteLine("Veritabanı hatası: " + ex.Message);
                throw;
            }
            
        }

        public SqlDataReader ExecuteReader(string cmdtext, SqlParameter[] p = null)  //2. TRY-CATCH EKLEME
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
            catch (SqlException ex)
            {
                Console.WriteLine("Veritabanı hatası: " + ex.Message);
                throw;
            }
            
        }
    }
}
