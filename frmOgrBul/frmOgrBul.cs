﻿using OkulApp.BLL;
using OkulApp.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OkulAppSube1BIL
{
    public partial class frmOgrBul : Form
    {
        private frmOgrKayit frm;

        public bool Bulundu { get; private set; }

        public frmOgrBul(frmOgrKayit frm)
        {
            InitializeComponent();
            this.frm = frm;
        }

        private void Bul_Click(object sender, EventArgs e)
        {
            if (ogrenciBulundu)
            {
                Bulundu = true;
                this.Close();
            }
        }
    }
}
