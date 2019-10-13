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
        public ArabaDetay(Anasayfa sayfa)
        {
            anasayfa = sayfa;
            InitializeComponent();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {     
            //Listeye geri dön.
            Hide();
            anasayfa.Show();
        }
    }
}
