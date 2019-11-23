using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            richTextBox1.Text = Form2.Buscar(Form1.Conecta_Bd(), textBox1.Text);

            listBox1.Items.Add( Form2.Buscar(Form1.Conecta_Bd(), textBox1.Text));

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //Form2.Eliminar(Form1.Conecta_Bd(), richTextBox1.SelectedText);
            Form2.Eliminar(Form1.Conecta_Bd(), listBox1.SelectedItem.ToString());
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
