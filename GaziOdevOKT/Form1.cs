using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using DAL;
using okulApp.model;

namespace GaziOdevOKT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
           
                var obl = new OgrenciBL();
                bool sonuc = obl.OgrenciEkle(new Ogrenci { Ad = txtAd.Text.Trim(), Soyad = txtSoyad.Text.Trim(), Numara = txtNumara.Text.Trim() });
                MessageBox.Show(sonuc ? "Ekleme başarılı!" : "Ekleme başarısız!!");
            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 2627:
                        MessageBox.Show("Bu numara daha önce kayıtlı");
                        break;
                    default:
                        MessageBox.Show("Veritabanı Hatası!");
                        break;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Bir hata oluştu!!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                var obl = new OgretmenBL();
                bool sonuc = obl.OgretmenEkle(new Ogretmen { Tc = txtTc.Text.Trim(), Ad = txtAd.Text.Trim(), Soyad = txtSoyad.Text.Trim() });
                MessageBox.Show(sonuc ? "Ekleme başarılı!" : "Ekleme başarısız!!");
            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 2627:
                        MessageBox.Show("Bu numara daha önce kayıtlı");
                        break;
                    default:
                        MessageBox.Show("Veritabanı Hatası!");
                        break;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Bir hata oluştu!!");
            }
        }

        private void txtTC_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

