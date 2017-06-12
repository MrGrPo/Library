using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteka
{
    public partial class Form1 : Form
    {
        SqlConnection sqlConnection;
        public Form1()
        {
            InitializeComponent();
        }

        private void klientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Klient frm = new Klient();

            frm.Show();
        }

        private void pracownikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pracownik frm = new Pracownik();

            frm.Show();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            string connectionSring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\forwa\documents\visual studio 2017\Projects\Biblioteka\Biblioteka\Biblioteka.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionSring);
            await sqlConnection.OpenAsync();


        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text) &&
                !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) &&
                !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text) &&
                !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4.Text) &&
                !string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrWhiteSpace(textBox5.Text) &&
                !string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrWhiteSpace(textBox6.Text) &&
                !string.IsNullOrEmpty(textBox7.Text) && !string.IsNullOrWhiteSpace(textBox7.Text) &&
                !string.IsNullOrEmpty(textBox7.Text) && !string.IsNullOrWhiteSpace(textBox8.Text) &&
                !string.IsNullOrEmpty(comboBox1.Text) && !string.IsNullOrWhiteSpace(comboBox1.Text)
                )


            {
                SqlCommand command = new SqlCommand("INSERT INTO [Klient] (Imię, Nazwisko, Telefon, Wojewódstwo, Miasto, [Kod pocztowy], Ulica, [Numer domu], [Numer mieszkania]) " +
                 "VALUES (@Imię, @Nazwisko, @Telefon, @Wojewódstwo, @Miasto, @Kodpocztowy, @Ulica, @Numerdomu, @Numermieszkania)", sqlConnection);

                command.Parameters.AddWithValue("Imię", textBox1.Text);
                command.Parameters.AddWithValue("Nazwisko", textBox2.Text);
                command.Parameters.AddWithValue("Telefon", textBox3.Text);
                command.Parameters.AddWithValue("Wojewódstwo", comboBox1.Text);
                command.Parameters.AddWithValue("Miasto", textBox4.Text);
                command.Parameters.AddWithValue("Kodpocztowy", textBox8.Text);
                command.Parameters.AddWithValue("Ulica", textBox5.Text);
                command.Parameters.AddWithValue("Numerdomu", textBox6.Text);
                command.Parameters.AddWithValue("Numermieszkania", textBox7.Text);

                await command.ExecuteNonQueryAsync();
            }
            else
            {
                MessageBox.Show("Alll");
            }
        }

        private void zamówienieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Zamówienie frm = new Zamówienie();

            frm.Show();

        }

        private void książkiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Książki frm = new Książki();

            frm.Show();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox10.Text) && !string.IsNullOrWhiteSpace(textBox10.Text) &&
                !string.IsNullOrEmpty(textBox11.Text) && !string.IsNullOrWhiteSpace(textBox11.Text) &&
                !string.IsNullOrEmpty(textBox9.Text) && !string.IsNullOrWhiteSpace(textBox9.Text) 
                

                )


            {
                SqlCommand command = new SqlCommand("INSERT INTO [Zamówienie] ([Data wypożyczenia], [Data zwrotu], Id_Kl, Id_Pr, Id_Ks) " +
                 "VALUES (@Datawypożyczenia, @Datazwrotu, @Id_Kl, @Id_Pr, @Id_Ks)", sqlConnection);

                command.Parameters.AddWithValue("Datawypożyczenia", dateTimePicker1.Value);
                command.Parameters.AddWithValue("Datazwrotu", dateTimePicker2.Value);
                command.Parameters.AddWithValue("Id_Kl", textBox9.Text);
                command.Parameters.AddWithValue("Id_Pr", textBox10.Text);
                command.Parameters.AddWithValue("Id_Ks", textBox11.Text);


                await command.ExecuteNonQueryAsync();
            }
            else
            {
                MessageBox.Show("Alll");
            }
        }
    }
}

    

