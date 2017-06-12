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
    public partial class Zamówienie : Form
    {
        SqlConnection sqlConnection;
        public Zamówienie()
        {
            InitializeComponent();
        }

        private async void Zamówienie_Load(object sender, EventArgs e)
        {
            string connectionSring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\forwa\documents\visual studio 2017\Projects\Biblioteka\Biblioteka\Biblioteka.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionSring);
            await sqlConnection.OpenAsync();
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM[Zamówienie]", sqlConnection);

            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    listBox1.Items.Add(Convert.ToString(sqlReader["Id"]) + "  " + Convert.ToString(sqlReader["Data wypożyczenia"]) + "  " + Convert.ToString(sqlReader["Data zwrotu"]) + "  " +
                        Convert.ToString(sqlReader["Id_Kl"]) + "  " + Convert.ToString(sqlReader["Id_Pr"]) + "  " + Convert.ToString(sqlReader["Id_Ks"]));
                    
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
    }
}
