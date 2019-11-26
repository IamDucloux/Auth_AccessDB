using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Autenticacion_BD
{
    public partial class Form1 : Form
    {
        public static Form2 form2 = new Form2();
        public static Form4 form4 = new Form4();
        public static Form3 usrform = new Form3();

        public static OleDbConnection Conecta_Bd()
        {

            OleDbConnection con; string stringconexion = "Provider =" + "Microsoft.Jet.OLEDB.4.0; Data Source = " + "C:/Users/iandu/Documents/Universidad/Computo en la nube/usuarios.mdb";

            OleDbCommand cmd = new OleDbCommand(); con = new OleDbConnection(stringconexion);

            try
            {

                con.Open();
                //MessageBox.Show("Conectado");



            }
            catch (Exception ex)
            {

                MessageBox.Show("Error " + ex);
            }

            return con;
        }

        public static String Consulta_Usuario(OleDbConnection conexion, TextBox texb)
        {
            //conexion.Open();
            string usuario = null;
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conexion;
            cmd.CommandText = "SELECT Usuario FROM Cuentas WHERE Usuario='" + texb.Text + "'";
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                usuario = reader.GetString(0);
            }
            reader.Close();
            //conexion.Close();
            return usuario;
        }

        

        public static String Consulta_contraseña(OleDbConnection conexion, TextBox texb)
        {
            //conexion.Open();
            string cadena = null;
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conexion;
            cmd.CommandText = "SELECT Contraseña FROM Cuentas WHERE usuario='" + texb.Text + "'";
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cadena = reader.GetString(0);
            }
            reader.Close();
            //conexion.Close();
            return cadena;
        }

        public static string Consulta_Nivel(OleDbConnection conexion, string usuario)
        {
            string nivel = null;
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conexion;
            cmd.CommandText = "SELECT Nivel FROM Cuentas WHERE usuario='" + usuario + "'";
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                nivel = reader.GetString(0);
            }
            reader.Close();
            //conexion.Close();
            return nivel;
        }

        public static Boolean Autenticacion(string usuario, string contraseña, TextBox entr_usr, TextBox entr_contr)
        {
            Boolean bandera = false;
            try
            {
                if (usuario == entr_usr.Text && contraseña == entr_contr.Text)
                {
                    bandera = true;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

            return bandera;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (Autenticacion(Consulta_Usuario(Conecta_Bd(), textBox1), Consulta_contraseña(Conecta_Bd(), textBox1), textBox1, textBox2))
            {
                MessageBox.Show("Correcto");
                if (Consulta_Nivel(Conecta_Bd(),textBox1.Text)=="Usuario")
                {
                    usrform.Show();
                    Hide();
                }
                else if (Consulta_Nivel(Conecta_Bd(), textBox1.Text) == "Mantenimiento")
                {
                    form2.Show();
                    Hide();
                }
                
            }
            else
            {
                MessageBox.Show("Esta mal");
            }

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            form4.Show();
            
        }
    }
}
