﻿using RentACar.DAL;
using RentACar.DATA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentACar.UI
{
    public partial class KayitEkrani : Form
    {
        Context db;
        GirisEkrani girisEkrani;
        public KayitEkrani(GirisEkrani giris,Context context)
        {
            girisEkrani = giris;
            db=context;
            InitializeComponent();
        }

        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            Uye uye = new Uye()
            {
                Email = txtEmail.Text,
                Sifre = txtSifre.Text,

            };
            db.Uyeler.Add(uye);

            db.SaveChanges();
            MessageBox.Show("Kayıdınız başarıyla oluşturulmuştur.");
            girisEkrani.Show();
            this.Hide();
        }
    }
}