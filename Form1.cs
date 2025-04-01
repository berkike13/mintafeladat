using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Protobuf.Collections;
using KonzolosApp;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace GuiApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Product> lista1 = new List<Product>();
            List<StockEntry> lista2 = new List<StockEntry>();
            List<Supplier> lista3 = new List<Supplier>();

            KonzolosApp.Program.Beolvas(lista1, lista2, lista3);
            KonzolosApp.Program.Feltoltes(lista1,lista2,lista3);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connStr = "server=localhost;user=root;database=InventorySystem;";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                MessageBox.Show("Kapcsolódva az adatbázishoz...");

                string sql = "INSERT INTO Suppliers (name, email) VALUES (@name, @email)";
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@name", textBox1.Text);
                    cmd.Parameters.AddWithValue("@email", textBox2.Text);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Adatok feltöltve az adatbázisba!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connStr = "server=localhost;user=root;database=InventorySystem;";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                MessageBox.Show("Kapcsolódva az adatbázishoz...");

                string sql = "SELECT name, quantity FROM Products WHERE name = @name";
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@name", textBox3.Text);
                    using (var eredmeny = cmd.ExecuteReader()) 
                    {
                        while (eredmeny.Read()) 
                        {
                            listBox1.Items.Add(eredmeny["name"] + " - " + eredmeny["quantity"] + " db");
                        }
                    }
                }

           
            }
        }
    }
}
