using RentACar.DAL;
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
    public partial class ArabaIslemleri : Form
    {
        Context db;
        GirisEkrani girisEkrani;
        public ArabaIslemleri(GirisEkrani giris,Context context)
        {
            girisEkrani = giris;
            db = context;
            InitializeComponent();
        }

        private void BtnArabaEkle_Click(object sender, EventArgs e)
        {
            Araba araba = new Araba()
            {
                SasiNo = txtSasiNo.Text,
                Model = txtModel.Text,
                Marka = txtMarka.Text,
                CikisTarihi = dtCikisTarihi.Value,
                KiradaMi = rdoEvet.Checked,
                Mesafe = Convert.ToInt32(txtMesafe.Text),
                YillikMesafe = Convert.ToInt32(txtMesafeKm.Text)
            };
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
        //    Araba araba = db.Arabalar.Where(x => x.ID == (int)cmbArabaListesi.SelectedValue).FirstOrDefault();

        //    araba.SasiNo = txtSasiNo.Text;
        //    araba.Model = txtModel.Text;
        //    araba.Marka = txtMarka.Text;
        //    araba.Mesafe =Convert.ToInt32(txtMesafe.Text);
        //    araba.YillikMesafe =Convert.ToInt32(txtMesafeKm.Text);
        //    araba.CikisTarihi = dtCikisTarihi.Value;
        }

        private void ArabaIslemleri_Load(object sender, EventArgs e)
        {
            
            cmbArabaListesi.DataSource = db.Arabalar.ToList();
            cmbArabaListesi.DisplayMember = "Marka";
            cmbArabaListesi.ValueMember = "ID";

            
        }

        private void CmbArabaListesi_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Araba araba = db.Arabalar.Where(x => x.ID == (int)cmbArabaListesi.SelectedValue).FirstOrDefault();

            //txtSasiNo.Text = araba.SasiNo;
            //txtModel.Text = araba.Model;
            //txtMarka.Text = araba.Marka;
            //txtMesafe.Text = Convert.ToString(araba.Mesafe);
            //txtMesafeKm.Text = Convert.ToString(araba.YillikMesafe);
            //dtCikisTarihi.Value = araba.CikisTarihi;
        }
    }
}
