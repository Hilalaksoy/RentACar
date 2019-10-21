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
        string sasiNo;
        
        public KiralamaEkrani(ArabaDetay araba, Context context , int uye, string gelenSasiNo)
        {
            sasiNo = gelenSasiNo;
            uyeId = uye;
            arabaDetay = araba;
            db = context;         
            InitializeComponent();
        }
        private void KiralamaEkrani_Load(object sender, EventArgs e)
        {
            btnTamamla.Enabled = false;
        }
        private void btnMusteriEkle_Click(object sender, EventArgs e)
        {
            if (Metotlar.BosAlanVarMi(pnlMusteriler))
            {
                MessageBox.Show("Boş alanları doldurmak zorundasınız !!");
            }
            else
            {

                if ((txtTcNo.Text).Length < 11 || (txtTcNo.Text).Length > 11)
                    MessageBox.Show("Lütfen TC No için 11 karakter giriniz");
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
                        UyeID = uyeId  //fk
                    };
                    db.Musteriler.Add(musteri);
                    db.SaveChanges();
                    MessageBox.Show("Müşteri bilgisi kaydedildi.");
                    pbKimlik.Tag = null;
                    Metotlar.Temizle(pnlMusteriler);
                    btnTamamla.Enabled = true;
                }
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
        private void NmrGunSayisi_ValueChanged(object sender, EventArgs e)
        {
            if (nmrGunSayisi.Value < 7)
            {
                int fiyati =Convert.ToInt32(db.Arabalar.Where(x => x.SasiNo == sasiNo).Select(x => x.Fiyat).FirstOrDefault());
                lblFiyat.Text = (fiyati * Convert.ToInt32(nmrGunSayisi.Value)).ToString();
                lblIndirim.Text = "0";
            }

            else if (nmrGunSayisi.Value > 6 && nmrGunSayisi.Value <30)
            {
                int indirimsizFiyat = Convert.ToInt32 (db.Arabalar.Where(x => x.SasiNo == sasiNo).Select(x => x.Fiyat).FirstOrDefault());
                int toplamFiyat = Convert.ToInt32(indirimsizFiyat) * Convert.ToInt32(nmrGunSayisi.Value);
                int kalanGun = Convert.ToInt32(nmrGunSayisi.Value) - 7;
                int indirimliFiyat = (7 * indirimsizFiyat) * 70 / 100;
                int sonIndirim = indirimliFiyat + (kalanGun * indirimsizFiyat);
                lblFiyat.Text = sonIndirim.ToString();
                lblIndirim.Text = "%30";
               
            }
            else if (nmrGunSayisi.Value > 29 && nmrGunSayisi.Value < 61)
            {
                int indirimsizFiyat = Convert.ToInt32(db.Arabalar.Where(x => x.SasiNo == sasiNo).Select(x => x.Fiyat).FirstOrDefault());
                int toplamFiyat = Convert.ToInt32(indirimsizFiyat) * Convert.ToInt32(nmrGunSayisi.Value);
                int kalanGun = Convert.ToInt32(nmrGunSayisi.Value) - 30;
                int indirimliFiyat = (30 * indirimsizFiyat) * 60 / 100;
                int sonIndirim = indirimliFiyat + (kalanGun * indirimsizFiyat);
                lblFiyat.Text = sonIndirim.ToString();
                lblIndirim.Text = "%40";
            }   
        }
        private void btnDetayGeri_Click(object sender, EventArgs e)
        {
            Hide();
            arabaDetay.Show();
        }
        private void BtnTamamla_Click(object sender, EventArgs e)
        {

            Araba araba2 = db.Arabalar.FirstOrDefault(x => x.SasiNo == sasiNo);
            int id = araba2.ID;

            Kiralama kiralama = new Kiralama();
            kiralama.GunSayisi = Convert.ToInt32(nmrGunSayisi.Value);
            kiralama.Fiyat = Convert.ToDecimal(lblFiyat.Text);
            kiralama.Indirim = lblIndirim.Text;
            kiralama.MusteriID = uyeId;
            kiralama.ID = id;


            Araba araba = db.Arabalar.FirstOrDefault(x => x.SasiNo == sasiNo);
            araba.KiradaMi = true;
            db.Kiralamalar.Add(kiralama);
            db.SaveChanges();

            MessageBox.Show("Kiralama işlemi başarılı bir şekilde gerçekleşti.");

            this.Close();

        }
    }
}
