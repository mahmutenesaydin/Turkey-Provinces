using Bunifu.Framework.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusinessLayer
{
    public class Clears
    {
        public void ClearAll(Control ctl)
        {
            foreach (Control c in ctl.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Clear();
                }
                if (c.Controls.Count > 0)
                {
                    ClearAll(c);
                }

                if (c is ComboBox)
                {
                    ((ComboBox)c).Text = "";
                }
                if (c.Controls.Count > 0)
                {
                    ClearAll(c);
                }

                if (c is MaskedTextBox)
                {
                    ((MaskedTextBox)c).Clear();
                }
                if (c.Controls.Count > 0)
                {
                    ClearAll(c);
                }

                if (c is BunifuTextbox)
                {
                    ((BunifuTextbox)c).text = "";
                }
                if (c.Controls.Count > 0)
                {
                    ClearAll(c);
                }
            }
        }
    }
}
