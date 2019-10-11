using RentACar.DAL;
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
        public Anasayfa(Context context)
        {
            db = context;
            InitializeComponent();
        }
    }
}
