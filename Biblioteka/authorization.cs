using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteka
{
    public partial class authorization : Form
    {
        public authorization()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Admin")
            {
                if (textBox2.Text == "admin")

                {
                    this.Hide();
                    Form1 f1 = new Form1();
                    f1.ShowDialog();
                }
            }
            else
                MessageBox.Show("Is not a valid username or password");
            textBox1.Clear();
            textBox2.Clear();

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
