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
    public partial class GirisEkrani : Form
    {
        Context db;
        public GirisEkrani()
        {
            InitializeComponent();
        }

        private void lnkKayit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            KayitEkrani kayitEkrani = new KayitEkrani(this,db);
            Hide();
            kayitEkrani.Show();

        }
        int uyeId;
        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            Uye uye = db.Uyeler.FirstOrDefault(x => x.Email == txtEmail.Text && x.Sifre == txtSifre.Text);

            if (uye == null)
            {
                MessageBox.Show("Üyeliğiniz bulunamadı. Lütfen kayıt olunuz.");
            }
            else
            {
                if (uye.AdminMi == true)
                {
                 
                    ArabaIslemleri arabaIslemleri = new ArabaIslemleri(this,db);
                    this.Hide();
                    arabaIslemleri.Show();
                }
                else
                {
                    uyeId = uye.UyeID;
                    Anasayfa anasayfa = new Anasayfa(db,uyeId);
                    this.Hide();
                    anasayfa.Show();
                }
            }
        }

        private void GirisEkrani_Load(object sender, EventArgs e)
        {
            db = new Context();
            txtSifre.PasswordChar = '*';
        }
    }
}
