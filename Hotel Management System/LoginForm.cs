using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Hotel_Management_System
{
    public partial class LoginForm : Form
    {
        DBConnect connect = new DBConnect();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void label_exit_MouseEnter(object sender, EventArgs e)
        {
            label_exit.ForeColor = Color.Red;
        }

        private void label_exit_MouseLeave(object sender, EventArgs e)
        {
            label_exit.ForeColor = Color.DarkBlue;
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            label_exit.ForeColor = Color.Red;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label_exit.ForeColor = Color.DarkBlue;
        }

        private void label_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            
        }

        private void Button_login_Click(object sender, EventArgs e)
        {
            if (TextBox_userid.Text.Trim().Equals("") || TextBox_password.Text == "")
            {
                MessageBox.Show("Enter you userid and password to login", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else {
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                string selectquery = "SELECT * FROM `users` WHERE `UserID` = @uid AND `password` = @pass";
                MySqlCommand command = new MySqlCommand(selectquery,connect.GetConnection());
                command.Parameters.Add("@uid", MySqlDbType.VarChar).Value = TextBox_userid.Text;
                command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = TextBox_userid.Text;
                adapter.SelectCommand = command;
                adapter.Fill(table);


                // if the username and password exists
                if (table.Rows.Count > 0)
                {
                    // Show the main form
                    this.Hide();
                    MainForm mainForm = new MainForm();
                    mainForm.Show();
                }
                else
                {
                    MessageBox.Show("You userid and password dosen't exist", "Wrong Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
