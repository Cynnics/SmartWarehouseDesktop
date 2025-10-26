using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartWarehouseDesktop.CRUDs
{
    class Prompt
    {
        public static string ShowDialog(string text, string caption, string defaultValue = "")
        {
            Form prompt = new Form()
            {
                Width = 400,
                Height = 180,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label lbl = new Label() { Left = 20, Top = 20, Text = text, Width = 340 };
            TextBox input = new TextBox() { Left = 20, Top = 50, Width = 340, Text = defaultValue };
            Button ok = new Button() { Text = "OK", Left = 200, Width = 80, Top = 90 };
            Button cancel = new Button() { Text = "Cancelar", Left = 290, Width = 80, Top = 90 };

            string result = defaultValue;
            ok.Click += (sender, e) => { result = input.Text; prompt.Close(); };
            cancel.Click += (sender, e) => { result = defaultValue; prompt.Close(); };

            prompt.Controls.Add(lbl);
            prompt.Controls.Add(input);
            prompt.Controls.Add(ok);
            prompt.Controls.Add(cancel);
            prompt.AcceptButton = ok;
            prompt.CancelButton = cancel;

            prompt.ShowDialog();
            return result;
        }
    }
}
