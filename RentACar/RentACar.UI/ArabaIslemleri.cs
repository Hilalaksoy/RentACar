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
        public ArabaIslemleri(GirisEkrani giris, Context context)
        {
            girisEkrani = giris;
            db = context;
            InitializeComponent();
        }

        private void BtnArabaEkle_Click(object sender, EventArgs e)
        {
            if (Metotlar.BosAlanVarMi(panel1))
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.");
            }

            else
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

                db.SaveChanges();

                Metotlar.Temizle(panel1);

                MessageBox.Show("Kayıt işlemi başarıyla gerçekleşti.");
            }

            
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (Metotlar.BosAlanVarMi(panel1))
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz");
            }

            else
            {
                Araba araba = db.Arabalar.Where(x => x.ID == (int)cmbArabaListesi.SelectedValue).FirstOrDefault();

                araba.SasiNo = txtSasiNo.Text;
                araba.Model = txtModel.Text;
                araba.Marka = txtMarka.Text;
                araba.Mesafe = Convert.ToInt32(txtMesafe.Text);
                araba.YillikMesafe = Convert.ToInt32(txtMesafeKm.Text);
                araba.CikisTarihi = dtCikisTarihi.Value;

                db.SaveChanges();

                MessageBox.Show("Güncelleme başarılı.");

                btnGuncelle.Enabled = false;
                btnArabaEkle.Enabled = true;
            }

            
        }

        private void ArabaIslemleri_Load(object sender, EventArgs e)
        {
            cmbArabaListesi.DataSource = db.Arabalar.ToList();
            cmbArabaListesi.DisplayMember = "Model";
            cmbArabaListesi.ValueMember = "ID";

            btnGuncelle.Enabled = false;
            rdoEvet.Checked = true;
        }

        private void BtnGirisVeyaGuncelle_Click(object sender, EventArgs e)
        {
            btnGuncelle.Enabled = true;
            btnArabaEkle.Enabled = false;

            Araba araba = db.Arabalar.Where(x => x.ID == (int)cmbArabaListesi.SelectedValue).FirstOrDefault();
            txtSasiNo.Text = araba.SasiNo;
            txtModel.Text = araba.Model;
            txtMarka.Text = araba.Marka;
            txtMesafe.Text = araba.Mesafe.ToString();
            txtMesafeKm.Text = araba.YillikMesafe.ToString();
            dtCikisTarihi.Value = araba.CikisTarihi;
            if (araba.KiradaMi == true)
                rdoEvet.Checked = true;

            else rdoHayir.Checked = true;
            
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            Araba araba = db.Arabalar.Where(x => x.ID == (int)cmbArabaListesi.SelectedValue).FirstOrDefault();

            DialogResult ds = new DialogResult();

            ds = MessageBox.Show("Silme işlemi yapıldıktan sonra geri alınamaz. Seçilen araba silinsin mi?","Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (ds == DialogResult.Yes)
            {
                db.Arabalar.Remove(araba);
                MessageBox.Show("Silme işlemi başarıyla gerçekleşti");
            }

            db.SaveChanges();
        }

        private void ArabaIslemleri_FormClosing(object sender, FormClosingEventArgs e)
        {
            girisEkrani.Show();
        }
    }
}
