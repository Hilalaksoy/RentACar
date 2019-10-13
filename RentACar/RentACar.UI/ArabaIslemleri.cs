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

        private void ArabaIslemleri_Load(object sender, EventArgs e)
        {
            cmbArabaListesi.DataSource = db.Arabalar.ToList();
            cmbArabaListesi.DisplayMember = "Model";
            cmbArabaListesi.ValueMember = "ID";
            //cmbArabaListesi.SelectedIndex = 0;

            btnGuncelle.Enabled = false;
            rdoEvet.Checked = true;

        }
        private void BtnArabaEkle_Click(object sender, EventArgs e)
        {
            if (Metotlar.BosAlanVarMi(pnlArabaIslem))
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
                    YillikMesafe = Convert.ToInt32(txtMesafeKm.Text),
                    Fiyat = Convert.ToDecimal(txtFiyat.Text)
                };

                db.Arabalar.Add(araba);

                db.SaveChanges();

                cmbArabaListesi.DataSource = db.Arabalar.ToList();
                cmbArabaListesi.DisplayMember = "Model";
                cmbArabaListesi.ValueMember = "ID";


                Metotlar.Temizle(pnlArabaIslem);

                MessageBox.Show("Kayıt işlemi başarıyla gerçekleşti.");
            }


        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            //Db Güncelle
            if (Metotlar.BosAlanVarMi(pnlArabaIslem))
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
                araba.Fiyat = Convert.ToDecimal(txtFiyat.Text);

                db.SaveChanges();

                cmbArabaListesi.DataSource = db.Arabalar.ToList();
                cmbArabaListesi.DisplayMember = "Model";
                cmbArabaListesi.ValueMember = "ID";

                Metotlar.Temizle(pnlArabaIslem);

                MessageBox.Show("Güncelleme başarılı.");

                btnGuncelle.Enabled = false;
                btnArabaEkle.Enabled = true;
                btnGuncellemeYap.Enabled = true;
                btnSil.Enabled = true;
                cmbArabaListesi.Enabled = true;
            }


        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            Araba araba = db.Arabalar.Where(x => x.ID == (int)cmbArabaListesi.SelectedValue).FirstOrDefault();

            DialogResult ds = new DialogResult();

            ds = MessageBox.Show("Silme işlemi yapıldıktan sonra geri alınamaz. Seçilen araba silinsin mi?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (ds == DialogResult.Yes)
            {
                db.Arabalar.Remove(araba);
                MessageBox.Show("Silme işlemi başarıyla gerçekleşti");
            }

            db.SaveChanges();

            cmbArabaListesi.DataSource = db.Arabalar.ToList();
            cmbArabaListesi.DisplayMember = "Model";
            cmbArabaListesi.ValueMember = "ID";


        }

        private void ArabaIslemleri_FormClosing(object sender, FormClosingEventArgs e)
        {
            girisEkrani.Show();
        }

        private void BtnGuncellemeYap_Click(object sender, EventArgs e)
        {
            //Günncelleme Yap 
            btnGuncelle.Enabled = true;
            btnArabaEkle.Enabled = false;
            btnGuncellemeYap.Enabled = false;
            cmbArabaListesi.Enabled = false;
            btnSil.Enabled = false;

            Araba araba = db.Arabalar.Where(x => x.ID == (int)cmbArabaListesi.SelectedValue).FirstOrDefault();
            txtSasiNo.Text = araba.SasiNo;
            txtModel.Text = araba.Model;
            txtMarka.Text = araba.Marka;
            txtMesafe.Text = araba.Mesafe.ToString();
            txtMesafeKm.Text = araba.YillikMesafe.ToString();
            dtCikisTarihi.Value = araba.CikisTarihi;
            txtFiyat.Text = araba.Fiyat.ToString();
            if (araba.KiradaMi == true)
                rdoEvet.Checked = true;

            else rdoHayir.Checked = true;
        }

        private void pbResimEkle_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "(png, jpg)|*.png;*.jpg";
            ofd.ValidateNames = true;
            ofd.Multiselect = false;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (Control item in pnlResimIslem.Controls)
                {
                    if (item is PictureBox && item.Name.StartsWith("pbAraba"))
                    {
                        if (((PictureBox)item).Tag == null)
                        {
                            ((PictureBox)item).Image = Image.FromFile(ofd.FileName);
                            ((PictureBox)item).Tag = System.IO.Path.GetExtension(ofd.FileName);
                            break;
                        }
                        else if (((PictureBox)item).Tag != null && pnlResimIslem.Controls.IndexOf(((PictureBox)item)) == 4)
                        {
                            MessageBox.Show("Maksimum 5 tane resim ekleyebilirsiniz !!");
                        }
                    }
                }
            }
        }
        // async - await  --> İşlemleri bir kerede yapmayı sağlar.
        private async void pbResimKaydet_Click(object sender, EventArgs e)
        {
            //DONE:
            //cmb seçilmediyse uyarı versin.

            if (cmbArabaListesi.SelectedIndex != -1)
            {
                Araba araba = db.Arabalar.Where(x => x.ID == (int)cmbArabaListesi.SelectedValue).FirstOrDefault();

                foreach (Control item in pnlResimIslem.Controls)
                {
                    if (item is PictureBox && item.Name.StartsWith("pbAraba"))
                    {
                        if (((PictureBox)item).Tag != null)
                        {
                            Resim resim1 = new Resim()
                            {
                                Fotograf = Metotlar.ConvertImageToByte(((PictureBox)item).Image),
                                ID = araba.ID,
                            };
                            db.Resimler.Add(resim1);
                        }
                    }
                }
                await db.SaveChangesAsync();
                MessageBox.Show("Resimler başarılı bir şekilde kaydedildi.", "Mesaj Bilgisi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lütfen seçeneklerden hangi arabayı seçiniz..");
            }


        }
    }
}
