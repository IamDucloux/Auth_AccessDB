using System;
using System.Windows.Forms;

namespace Autenticacion_BD
{
    public partial class Form5 : Form
    {

        public Form5()
        {
            InitializeComponent();
        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //richTextBox1.Text = Form2.Buscar(Form1.Conecta_Bd(), textBox1.Text);


            listBox1.Items.Clear();
            Form2.Buscar(Form1.Conecta_Bd(), textBox1.Text, listBox1);

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //Form2.Eliminar(Form1.Conecta_Bd(), richTextBox1.SelectedText);
            switch (MessageBox.Show("Esta seguro que desea eliminar el elemento seleccionado", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2))
            {
                case DialogResult.None:
                    break;
                case DialogResult.OK:
                    break;
                case DialogResult.Cancel:
                    break;
                case DialogResult.Abort:
                    break;
                case DialogResult.Retry:
                    break;
                case DialogResult.Ignore:
                    break;
                case DialogResult.Yes:
                    try
                    {
                        Form2.Eliminar(Form1.Conecta_Bd(), listBox1.SelectedItem.ToString());
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.ToString());
                    }

                    break;
                case DialogResult.No:
                    break;
                default:
                    break;
            }




        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
