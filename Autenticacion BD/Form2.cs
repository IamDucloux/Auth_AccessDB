﻿using System;
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
        public Form2()
        {
            InitializeComponent();
        }

        public static string Buscar(OleDbConnection conexion, string busqueda)
        {
            
            string[] cadena = new string[100];
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conexion;
            cmd.CommandText = "SELECT Usuario FROM Cuentas WHERE usuario like'" + busqueda + "'";
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                //cadena += reader.GetString(0)+"\n\r";
                for (int i = 0; i < length; i++) //TODO Encontrar la manera de que el ciclo for ingrese cada resultado devuelto por la consulta en un Array
                {

                }
            }
            reader.Close();
            return cadena;
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

        private void Button1_Click(object sender, EventArgs e)
        {
            alta = new Form4();
            alta.Show();

        }

        private void Button3_Click(object sender, EventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            baja = new Form5();
            baja.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }
    }
}
