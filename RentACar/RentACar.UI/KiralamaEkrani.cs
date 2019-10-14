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
    public partial class KiralamaEkrani : Form
    {
        ArabaDetay arabaDetay;
        Context db;
        int uyeId;
        public KiralamaEkrani(ArabaDetay araba, Context context , int uye)
        {
            uyeId = uye;
            arabaDetay = araba;
            db = context;
            InitializeComponent();
        }

        private void btnMusteriEkle_Click(object sender, EventArgs e)
        {
            if (Metotlar.BosAlanVarMi(pnlMusteriler))
            {
                MessageBox.Show("Boş alanları doldurmak zorundasınız !!");
            }
            else
            {
                Musteri musteri = new Musteri()
                {
                    TcKimlikNo = txtTcNo.Text,
                    Ad = txtAd.Text,
                    Soyad = txtSoyad.Text,
                    DogumTarihi = dtDogumTarihi.Value.Date,
                    Memleket = txtMemleket.Text,
                    NufusResim = Metotlar.ConvertImageToByte(pbKimlik.Image),
                    UyeID = uyeId

                };
                db.Musteriler.Add(musteri);
                db.SaveChanges();
                MessageBox.Show("Müşteri bilgisi kaydedildi.");
                pbKimlik.Tag = null;
                Metotlar.Temizle(pnlMusteriler);
            }
            
        }

        private void lnkResimSec_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "(png, jpg)|*.png;*.jpg";
            ofd.ValidateNames = true;
            ofd.Multiselect = false;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pbKimlik.Image = Image.FromFile(ofd.FileName);
                pbKimlik.Tag = System.IO.Path.GetExtension(ofd.FileName);
            }
            else
                pbKimlik.Tag = null;
        }
    }
}
