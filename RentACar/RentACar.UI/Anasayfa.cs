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
    public partial class Anasayfa : Form
    {
        Context db;
        int uyeId;
        public Anasayfa(Context context , int uye)
        {
            uyeId = uye;
            db = context;
            InitializeComponent();
        }

        private void Anasayfa_Load(object sender, EventArgs e)
        {

            dgvArabaListesi.DataSource = db.Arabalar
                .Where(araba => araba.KiradaMi == false)
                .Join(db.Resimler, jaraba => jaraba.ID, resim => resim.ID, (jaraba, resim) => new { id = jaraba.ID, fotograf = resim.Fotograf, SasiNo = jaraba.SasiNo, Marka = jaraba.Marka, Model = jaraba.Model, Fiyat = jaraba.Fiyat })
                .GroupBy(biraraba => biraraba.id)
                .Select(x => x.FirstOrDefault())
                .ToList();

        }
        int secilenId;
        private void dgvArabaListesi_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvArabaListesi != null && dgvArabaListesi.SelectedRows.Count > 0)
            {
                DataGridViewRow satir = dgvArabaListesi.SelectedRows[0];
                if (satir != null)
                {                    
                    secilenId = Convert.ToInt32(satir.Cells[0].Value);
                    ArabaDetay arabaDetay = new ArabaDetay(this, db, secilenId,uyeId);
                    Hide();
                    arabaDetay.Show();
                }
            }
        }
 

    }
}
