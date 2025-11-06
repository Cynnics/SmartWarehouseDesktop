using System.Drawing;
using System.Windows.Forms;

namespace SmartWarehouseDesktop
{
    public static class UIHelper
    {
        public static void EstilizarBoton(Button btn)
        {
            btn.BackColor = TemaApp.Naranja;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 1;
            btn.Font = TemaApp.FuenteBoton;
            btn.Cursor = Cursors.Hand;
        }

        public static void EstiloHover(Button btn)
        {
            btn.MouseEnter += (s, e) => btn.BackColor = TemaApp.AzulClaro;
            btn.MouseLeave += (s, e) => btn.BackColor = TemaApp.Naranja;
        }

        public static void EstilizarLabel(Label lbl, bool esTitulo = false)
        {
            if (esTitulo)
            {
                lbl.ForeColor = Color.White;
                lbl.Font = TemaApp.FuenteTitulo;
                lbl.TextAlign = ContentAlignment.MiddleCenter;
            }
            else
            {
                lbl.ForeColor = Color.White;
                lbl.Font = TemaApp.FuenteGeneral;
                lbl.TextAlign = ContentAlignment.MiddleLeft;
            }
        }

        public static void EstilizarTextBox(TextBox txt)
        {
            txt.BorderStyle = BorderStyle.None;
            txt.BackColor = Color.White;
            txt.ForeColor = TemaApp.AzulOscuro;
            txt.Font = TemaApp.FuenteGeneral;

            Panel underline = new Panel();
            underline.Height = 2;
            underline.Dock = DockStyle.Bottom;
            underline.BackColor = TemaApp.AzulClaro;
            txt.Controls.Add(underline);
        }
        public static void EstilizarFormulario(Form form)
        {
            form.BackColor = TemaApp.AzulOscuro;
            form.Font = TemaApp.FuenteGeneral;
            form.ForeColor = Color.White;
        }
    }
}
