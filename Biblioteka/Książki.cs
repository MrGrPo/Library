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
    public partial class Książki : Form

    {
        SqlConnection sqlConnection;

        public Książki()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Podłącza bazę danych oraz wywoluje na listbox w zakładce książki zawartość tabeli książki z bazy danych
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Książki_Load(object sender, EventArgs e)
        {
            string connectionSring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\forwa\documents\visual studio 2017\Projects\Biblioteka\Biblioteka\Biblioteka.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionSring);

            await sqlConnection.OpenAsync();

            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM[Książki]", sqlConnection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    listBox1.Items.Add(Convert.ToString(sqlReader["Id"]) + "  " + Convert.ToString(sqlReader["Nazwa"]) + "  " + Convert.ToString(sqlReader["Wydawnictwo"]) + "  " +
                        Convert.ToString(sqlReader["Rok"]) + "  " + Convert.ToString(sqlReader["Autor"]));
                     
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
        /// Zapisuje wartość wszystkich textboxsów w zakładce INSERT do tabeli, jeśli one  nie są puste. Jeśli puste to pojawi się  messagebox z opisem błądu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox15.Text) && !string.IsNullOrWhiteSpace(textBox15.Text) &&
                !string.IsNullOrEmpty(textBox16.Text) && !string.IsNullOrWhiteSpace(textBox16.Text) &&
                !string.IsNullOrEmpty(textBox17.Text) && !string.IsNullOrWhiteSpace(textBox17.Text) &&
                !string.IsNullOrEmpty(textBox18.Text) && !string.IsNullOrWhiteSpace(textBox18.Text)
                )


            {
                SqlCommand command = new SqlCommand("INSERT INTO [Książki] (Nazwa, Autor, Rok, Wydawnictwo) " +
                 "VALUES (@Nazwa, @Autor, @Rok, @Wydawnictwo)", sqlConnection);

                command.Parameters.AddWithValue("Nazwa", textBox15.Text);
                command.Parameters.AddWithValue("Autor", textBox16.Text);
                command.Parameters.AddWithValue("Wydawnictwo", textBox17.Text);
                command.Parameters.AddWithValue("Rok", textBox18.Text);


                await command.ExecuteNonQueryAsync();
            }
            else
            {
                MessageBox.Show("wszystkie pola muszą być wypełnione");
            }
        }

        /// <summary>
        /// Wywoluje na listbox w zakładce książki zawartość tabeli książki z bazy danych po działaniu jakiejś metody
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void odśToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM[Książki]", sqlConnection);



            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    listBox1.Items.Add(Convert.ToString(sqlReader["Id"]) + "  " + Convert.ToString(sqlReader["Nazwa"]) + "  " + Convert.ToString(sqlReader["Wydawnictwo"]) + "  " +
                        Convert.ToString(sqlReader["Rok"]) + "  " + Convert.ToString(sqlReader["Autor"]));

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
        /// Aktualizuje wartość komórek w tabeli, jakie przypisane do  textboxsów po Id w zakładce UPDATE, jeśli one  nie są puste. Jeśli puste to pojawi się  messagebox z opisem błądu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrWhiteSpace(textBox6.Text) &&
                !string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrWhiteSpace(textBox5.Text) &&
                !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text) &&
                !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) &&
                !string.IsNullOrEmpty(textBox7.Text) && !string.IsNullOrWhiteSpace(textBox7.Text)
                )
            { 
                SqlCommand command = new SqlCommand("UPDATE  [Książki] SET [Nazwa]=@Nazwa, [Autor]= @Autor, [Rok]=@Rok, [Wydawnictwo]=@Wydawnictwo WHERE [Id]=@Id", sqlConnection);
         

            command.Parameters.AddWithValue("Nazwa", textBox6.Text);
            command.Parameters.AddWithValue("Autor", textBox5.Text);
            command.Parameters.AddWithValue("Wydawnictwo", textBox3.Text);
            command.Parameters.AddWithValue("Rok", textBox2.Text);
            command.Parameters.AddWithValue("Id", textBox7.Text);



                await command.ExecuteNonQueryAsync();
            }
            else
            {
                MessageBox.Show("wszystkie pola muszą być wypełnione");
            }
        }

        /// <summary>
        /// Usuwa z tabeli wiersz z takim samym Id jak użytkownik wpisał w textbox w zakładce DELETE, jeśli on  nie są puste. Jeśli puste to pojawi się  messagebox z opisem błądu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text)
                )
            {
                SqlCommand command = new SqlCommand("DELETE FROM [Książki]   WHERE [Id]= @Id", sqlConnection);


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
