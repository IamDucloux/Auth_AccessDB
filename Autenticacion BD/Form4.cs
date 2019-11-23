using System;
using System.Data.OleDb;
using System.Windows.Forms;
namespace Autenticacion_BD
{
    public partial class Form4 : Form
    {

        Form1 inicio = new Form1();
        public Form4()
        {
            InitializeComponent();
        }

        public static void Insertar_BD(OleDbConnection conexion, string usuario, string contraseña, string foto, string nivel)
        {
            //int filas = 0;
            string insert = "INSERT INTO Cuentas(Usuario,Contraseña,Fotografia,Nivel)  VALUES(" + "'" + usuario + "'," + "'" + contraseña + "'," + "'" + foto + "'," + "'" + nivel + "'" + ")";
            OleDbCommand cmd = new OleDbCommand(insert, conexion);
            MessageBox.Show(insert);
            cmd.ExecuteNonQuery();


            //INSERT INTO cuentas(USUARIO,CONTRASEÑA,FOTOGREAFIA,NIVEL) VALUES('iAN',"123","1","Usuario")

        }


        public static Boolean Verifica_Contraseña(string contraseña1, string contraseña2)
        {
            Boolean bandera = false;
            if (contraseña1 == contraseña2)
            {
                bandera = true;
            }

            return bandera;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null && textBox2.Text != null && textBox3.Text != null && Verifica_Contraseña(textBox2.Text, textBox3.Text) == true)
            {
                try
                {
                    Insertar_BD(Form1.Conecta_Bd(), textBox1.Text, textBox2.Text, textBox4.Text, comboBox1.SelectedItem.ToString());
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            inicio.Show();
        }
    }
}
