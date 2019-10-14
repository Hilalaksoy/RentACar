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
    public partial class ArabaDetay : Form
    {
        Anasayfa anasayfa;
        Context db;
        int arabaId;
        public ArabaDetay(Anasayfa sayfa,Context context,int id)
        {
            db = context;
            anasayfa = sayfa;
            arabaId = id;
            InitializeComponent();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {     
            //Listeye geri dön.
            Hide();
            anasayfa.Show();
        }

        private void ArabaDetay_Load(object sender, EventArgs e)
        {
            Araba araba = db.Arabalar.FirstOrDefault(x => x.ID == arabaId);
            lblSasiNo.Text = araba.SasiNo;
            lblModel.Text = araba.Model;
            lblMarka.Text = araba.Marka;
            lblCikisTarihi.Text = araba.CikisTarihi.ToLongDateString();
            lblFiyat.Text = araba.Fiyat.ToString();
            lblMesafe.Text = araba.Mesafe.ToString();
            lblMesafeKm.Text = araba.YillikMesafe.ToString();

            List<Resim> resimler = db.Resimler.Where(x => x.ID == arabaId).ToList();

            foreach (Resim resim in resimler)
            {               
                if(resim != null)
                {
                    foreach (Control item in grpResimler.Controls)
                    {
                        if(item is PictureBox)
                        {
                            if(((PictureBox)item).Tag == null)
                            {
                                ((PictureBox)item).Image = Metotlar.ConvertBinaryToImage(resim.Fotograf);
                                item.Tag = "full";
                                break;
                            }
                        }                     
                    }
                }
            }
          
        }

        private void btnKirala_Click(object sender, EventArgs e)
        {
            KiralamaEkrani kiralama = new KiralamaEkrani(this, db);
            Hide();
            kiralama.Show();

        }
    }
}
