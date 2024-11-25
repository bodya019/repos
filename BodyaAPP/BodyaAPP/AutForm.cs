using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BodyaAPP
{
    public partial class AutForm : Form
    {
        public AutForm()
        {
            InitializeComponent();
            UserLoginField.Text = "Введите Login";
            UserPasswordField.Text = "Введите Password";
        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Name == "UserLoginField" && UserLoginField.Text.Trim() == "Введите Login")
            {
                UserLoginField.Text = "";
                UserLoginField.ForeColor = Color.White;
            }

            
            if (((TextBox)sender).Name == "UserPasswordField" && UserPasswordField.Text.Trim() == "Введите Password")
            {
                UserPasswordField.Text = "";
                UserPasswordField.UseSystemPasswordChar = true;
                UserPasswordField.ForeColor = Color.White;
            }
        }

        public void textBox1_Leave(object sender, EventArgs e)
        {
            if (((TextBox)sender).Name == "UserLoginField" && UserLoginField.Text.Trim() == "")
            {
                UserLoginField.Text = "Введите Login";
                UserLoginField.ForeColor = Color.Gray;
            }

            

            if (((TextBox)sender).Name == "UserPasswordField" && UserPasswordField.Text.Trim() == "")
            {
                UserPasswordField.ForeColor = Color.Gray;
                UserPasswordField.Text = "Введите Password";
                UserPasswordField.UseSystemPasswordChar = false;

            }
        }

        public void AutBTN_Click(object sender, EventArgs e)
        {
            if (UserLoginField.Text.Trim() == "" || UserLoginField.Text.Trim() == "Введите Login")
            {
                MessageBox.Show("не введен Login");
                return;
            }
            
            if (UserPasswordField.Text.Trim() == "" || UserPasswordField.Text.Trim() == "Введите Password")
            {
                MessageBox.Show("не введен Password");
                return;
            }

            DB db = new DB();
            MySqlCommand command = new MySqlCommand(
                "SELECT COUNT(id) FROM users WHERE login = @login AND password = @password ",
                db.GetConnection()
                );
            command.Parameters.AddWithValue("login", UserLoginField.Text);
            
            command.Parameters.AddWithValue("password", Hash(UserPasswordField.Text));

            db.OpenConnection();
            int countUser = Convert.ToInt32(command.ExecuteScalar());
            if (countUser > 0)
            {
                this.Hide();
                PinPong pinPong = new PinPong();
                pinPong.ShowDialog();                
                this.Close();
            } 
            else MessageBox.Show("User NO exist");
            db.CloseConnection();
        }
        public string Hash(string input)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            using (SHA512Managed sha = new SHA512Managed())
            {
                var hash = sha.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }        

        private void AutForm_Load(object sender, EventArgs e)
        {
            this.ActiveControl = LinkToReg;
        }

        private void linklabl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
            this.Close();
        }
    }
}
