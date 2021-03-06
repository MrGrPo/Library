﻿using System;
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
    public partial class Klient : Form
    {
        SqlConnection sqlConnection;
        public Klient()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Podłącza bazę danych oraz wywoluje na listbox w zakładce klient zawartość tabeli klient z bazy danych
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Klient_Load(object sender, EventArgs e)
        {
            string connectionSring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\forwa\documents\visual studio 2017\Projects\Biblioteka\Biblioteka\Biblioteka.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionSring);
            await sqlConnection.OpenAsync();
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM[Klient]", sqlConnection);

            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    listBox1.Items.Add(Convert.ToString(sqlReader["Id"]) + "  " + Convert.ToString(sqlReader["Imię"]) + "  " + Convert.ToString(sqlReader["Nazwisko"]) + "  " + 
                        Convert.ToString(sqlReader["Telefon"]) + "  " + Convert.ToString(sqlReader["Wojewódstwo"]) + "  " +  Convert.ToString(sqlReader["Miasto"]) + "  " +
                        Convert.ToString(sqlReader["Kod pocztowy"]) + "  " + Convert.ToString(sqlReader["Ulica"]) + "  " + Convert.ToString(sqlReader["Numer domu"]) + "  " +
                        Convert.ToString(sqlReader["Numer mieszkania"]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }


        private void zamkrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close();

        }

        private void Klient_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close();

        }

        /// <summary>
        /// Aktualizuje wartość komórek w tabeli, jakie przypisane do  textboxsów po Id w zakładce UPDATE, jeśli one  nie są puste. Jeśli puste to pojawi się  messagebox z opisem błądu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button2_Click(object sender, EventArgs e)
        {
           
                if (!string.IsNullOrEmpty(textBox19.Text) && !string.IsNullOrWhiteSpace(textBox19.Text) &&
                    !string.IsNullOrEmpty(textBox18.Text) && !string.IsNullOrWhiteSpace(textBox18.Text) &&
                    !string.IsNullOrEmpty(textBox17.Text) && !string.IsNullOrWhiteSpace(textBox17.Text) &&
                    !string.IsNullOrEmpty(textBox16.Text) && !string.IsNullOrWhiteSpace(textBox16.Text) &&
                    !string.IsNullOrEmpty(textBox15.Text) && !string.IsNullOrWhiteSpace(textBox15.Text) &&
                    !string.IsNullOrEmpty(textBox14.Text) && !string.IsNullOrWhiteSpace(textBox14.Text) &&
                    !string.IsNullOrEmpty(textBox13.Text) && !string.IsNullOrWhiteSpace(textBox13.Text) &&
                    !string.IsNullOrEmpty(textBox12.Text) && !string.IsNullOrWhiteSpace(textBox12.Text) &&
                    !string.IsNullOrEmpty(comboBox2.Text) && !string.IsNullOrWhiteSpace(comboBox2.Text) &&
                    !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text)
                    )
                {
                    SqlCommand command = new SqlCommand("UPDATE [Klient] SET [Imię]=@Imię, [Nazwisko]=@Nazwisko, [Telefon]=@Telefon, [Wojewódstwo]=@Wojewódstwo,[Miasto]=@Miasto," +
                        "[Kod pocztowy]=@Kodpocztowy, [Ulica]=@Ulica, [Numer domu]=@Numerdomu, [Numer mieszkania]=@Numermieszkania WHERE [Id]= @Id", sqlConnection);

                    command.Parameters.AddWithValue("Imię", textBox19.Text);
                    command.Parameters.AddWithValue("Nazwisko", textBox18.Text);
                    command.Parameters.AddWithValue("Telefon", textBox17.Text);
                    command.Parameters.AddWithValue("Wojewódstwo", comboBox2.Text);
                    command.Parameters.AddWithValue("Miasto", textBox16.Text);
                    command.Parameters.AddWithValue("Kodpocztowy", textBox12.Text);
                    command.Parameters.AddWithValue("Ulica", textBox15.Text);
                    command.Parameters.AddWithValue("Numerdomu", textBox14.Text);
                    command.Parameters.AddWithValue("Numermieszkania", textBox13.Text);
                    command.Parameters.AddWithValue("Id", textBox2.Text);

                    await command.ExecuteNonQueryAsync();
                }
                else
                {
                    MessageBox.Show("wszystkie pola muszą być wypełnione");
                }

            
        }

        /// <summary>
        /// Wywoluje na listbox w zakładce klient zawartość tabeli klient z bazy danych po działaniu jakiejś metody
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void odświeżyćToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM[Klient]", sqlConnection);



            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    listBox1.Items.Add(Convert.ToString(sqlReader["Id"]) + "  " + Convert.ToString(sqlReader["Imię"]) + "  " + Convert.ToString(sqlReader["Nazwisko"]) + "  " +
                        Convert.ToString(sqlReader["Telefon"]) + "  " + Convert.ToString(sqlReader["Wojewódstwo"]) + "  " + Convert.ToString(sqlReader["Miasto"]) + "  " +
                        Convert.ToString(sqlReader["Kod pocztowy"]) + "  " + Convert.ToString(sqlReader["Ulica"]) + "  " + Convert.ToString(sqlReader["Numer domu"]) + "  " +
                        Convert.ToString(sqlReader["Numer mieszkania"]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }

        }

        /// <summary>
        /// Usuwa z tabeli wiersz z takim samym Id jak użytkownik wpisał w textbox w zakładce DELETE, jeśli on  nie są puste. Jeśli puste to pojawi się  messagebox z opisem błądu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private async void button1_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text)
                )
            {
                SqlCommand command = new SqlCommand("DELETE FROM [Klient]   WHERE [Id]= @Id", sqlConnection);


                command.Parameters.AddWithValue("Id", textBox1.Text);

                await command.ExecuteNonQueryAsync();
            }
            else
            {
                MessageBox.Show("wszystkie pola muszą być wypełnione");
            }
        }       
    }
}
