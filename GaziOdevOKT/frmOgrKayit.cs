﻿using OkulApp.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace OkulAppSube1BIL
{
    public partial class frmOgrKayit : Form
    {

        public int Ogrenciid { get; set; }
        public bool Bulundu { get; private set; }
        public bool ogrenciBulundu { get; private set; }

        public frmOgrKayit()
        {

            InitializeComponent();
            btnSil.Enabled = false;            //SİL VE GÜNCELLE AYARI
            btnGuncelle.Enabled = false;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                var obl = new OgrenciBL();
                bool sonuc = obl.OgrenciEkle(new Ogrenci { Ad = txtAd.Text.Trim(), Soyad = txtSoyad.Text.Trim(), Numara = txtNumara.Text.Trim() });
                MessageBox.Show(sonuc ? "Ekleme Başarılı!" : "Ekleme Başarısız!!");
            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 2627:
                        MessageBox.Show("Bu numaralı öğrenci daha önce kayıtlı");
                        break;
                    default:
                        MessageBox.Show("Veritabanı hatası");
                        break;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Bilinmeyen Hata!!");
            }
        }

        private void btnBul_Click(object sender, EventArgs e)
        {

            frmOgrBul frm = new frmOgrBul(this);
            frm.ShowDialog(); // Bul formunu aç

            // Bul formundan döndüğünde, burada kontrol et ve işlemleri yap
            if (frm.Bulundu)
            {
                btnSil.Enabled = true;
                btnGuncelle.Enabled = true;

                // TextBox'ların içeriğini temizler
                txtAd.Clear();
                txtSoyad.Clear();
                txtNumara.Clear();
            }
            // Öğrenci bulunduğunda
            if (ogrenciBulundu)
            {
                Bulundu = true;
                this.Close(); // Formu kapatır
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            var obl = new OgrenciBL();
            obl.OgrenciGuncelle(new Ogrenci { Ad = txtAd.Text.Trim(), Soyad = txtSoyad.Text.Trim(), Numara = txtNumara.Text.Trim(), Ogrenciid = Ogrenciid });
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            var obl = new OgrenciBL();
            obl.OgrenciSil(Ogrenciid);
        }
    }

    //Güncelleme Başarılı mesajı
    //Güncelleme butonu aktifliği?
    //Silme butonu aktifliği
    //Silme işlemi mesajı
    //Tüm işlemlerde try-catch
    //Helperda bulunan connection ve commandlerin dispose edilmesi (IDisposable Pattern)
    //Singleton Pattern (Sürkeli nesne oluşmadan tek nesne üstünden işlemlerin yapılması)
    //Öğretmen entity'si için kalan CRUD işlemleri



    interface ITransfer
    {
        int Eft(string gondericiiban, string aliciiban, double tutar);
        int Havale(string gondericiiban, string aliciiban, double tutar);

    }

    class Transfer : ITransfer
    {
        public int Eft(string gondericiiban, string aliciiban, double tutar)
        {
            throw new NotImplementedException();
        }

        public int Havale(string gondericiiban, string aliciiban, double tutar)
        {
            throw new NotImplementedException();
        }

        //
    }
}

//Garbage Collector