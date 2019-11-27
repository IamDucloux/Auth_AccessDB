using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Autenticacion_BD
{
    public partial class Form2 : Form
    {
        static Form4 alta = new Form4();
        static Form5 baja = new Form5();
        static Form6 edita = new Form6();
        public Form2()
        {
            InitializeComponent();
        }

        public static void Buscar(OleDbConnection conexion, string busqueda, ListBox list)
        {
            
            string[] cadena = new string[100];
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conexion;
            cmd.CommandText = "SELECT Usuario FROM Cuentas WHERE usuario like'" + busqueda + "'";
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Items.Add(reader.GetString(0));
            }
            reader.Close();
            
        }
        
        public static void Eliminar(OleDbConnection conexion, string elemento)
        {
            string delete = "DELETE FROM Cuentas Where usuario='"+elemento+"'";
            OleDbCommand cmd = new OleDbCommand(delete, conexion);
            MessageBox.Show(delete);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            
        }

        public static void Editar_BD(OleDbConnection conexion, string usuario, string contraseña, string foto, string nivel, string busqueda)
        {
            //int filas = 0;
            string update = "UPDATE Cuentas SET Usuario ='" + usuario + "'," + "Contraseña='" + contraseña + "'," + "Fotografia='" + foto + "'," + "Nivel='" + nivel + "' "+
                "WHERE Usuario='"+busqueda+"'";  
            OleDbCommand cmd = new OleDbCommand(update, conexion);
            MessageBox.Show(update);
            cmd.ExecuteNonQuery();


            //INSERT INTO cuentas(USUARIO,CONTRASEÑA,FOTOGREAFIA,NIVEL) VALUES('iAN',"123","1","Usuario")

        }


        



        private void Button1_Click(object sender, EventArgs e)
        {
            alta = new Form4();
            alta.Show();

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Buscar(Form1.Conecta_Bd(), textBox1.Text, listBox1);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            baja = new Form5();
            baja.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            edita = new Form6();
            edita.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }
    }
}
