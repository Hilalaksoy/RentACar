using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentACar.UI
{
    public static class Metotlar
    {
        public static bool BosAlanVarMi(Panel pnl)
        {
            foreach (Control item in pnl.Controls)
            {
                if (item is TextBox && item.Text == "") return true;
                else if (item is DateTimePicker)
                {
                    if ((item as DateTimePicker).Value.Date == DateTime.Now.Date)
                        return true;
                }
                else if (item is ComboBox)
                {
                    if ((item as ComboBox).SelectedIndex == -1)
                        return true;
                }
                else if(item is PictureBox && item.Name.StartsWith("pbAraba"))
                {
                    if ((item as PictureBox).Tag == null)
                        return true;
                }
            }
            return false;
        }
        public static void Temizle(Panel pnl)
        {
            foreach (Control item in pnl.Controls)
            {
                if (item is TextBox) item.Text = "";
                else if (item is ComboBox) ((ComboBox)item).SelectedIndex = -1;
                else if (item is DateTimePicker) ((DateTimePicker)item).Value = DateTime.Now;
                else if (item is MaskedTextBox) ((MaskedTextBox)item).ResetText();
                else if (item is ListBox) ((ListBox)item).DataSource = null;
                else if (item is Label && item.Name.StartsWith("lbl")) item.Text = "";
            }
        }

        public static byte[] ConvertImageToByte(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }

   
    }
}

