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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Form2.Buscar(Form1.Conecta_Bd(), textBox5.Text, listBox1);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = listBox1.SelectedItem.ToString();
                textBox2.Text = Form1.Consulta_contraseña(Form1.Conecta_Bd(), listBox1.SelectedItem.ToString());
                textBox4.Text = Form1.Consulta_Foto(Form1.Conecta_Bd(), listBox1.SelectedItem.ToString());
                comboBox1.SelectedItem = Form1.Consulta_Nivel(Form1.Conecta_Bd(), listBox1.SelectedItem.ToString());
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

;        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Form4.Insertar_BD(Form1.Conecta_Bd(), textBox1.Text, textBox2.Text, textBox4.Text, comboBox1.SelectedText);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
    }
}
