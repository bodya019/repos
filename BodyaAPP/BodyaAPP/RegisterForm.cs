using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace BodyaAPP
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
            UserLoginField.Text = "Введите Login";
            UserMailField.Text = "Введите Email";
            UserPasswordField.Text = "Введите Password";
            this.Text = "Регисрация пользователя";
        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Name == "UserLoginField" && UserLoginField.Text.Trim() == "Введите Login")
            {
                UserLoginField.Text = "";
                UserLoginField.ForeColor = Color.White;
            }

            if (((TextBox)sender).Name == "UserMailField" && UserMailField.Text.Trim() == "Введите Email")
            {
                UserMailField.Text = "";
                UserMailField.ForeColor = Color.White;
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

            if (((TextBox)sender).Name == "UserMailField" && UserMailField.Text.Trim() == "")
            {
                UserMailField.Text = "Введите Email";
                UserMailField.ForeColor = Color.Gray;
            }

            if (((TextBox)sender).Name == "UserPasswordField" && UserPasswordField.Text.Trim() == "")
            {
                UserPasswordField.ForeColor = Color.Gray;
                UserPasswordField.Text = "Введите Password";
                UserPasswordField.UseSystemPasswordChar = false;

            }
        }

        public void UserBn_Click(object sender, EventArgs e)
        {
            if (UserLoginField.Text.Trim() == "" || UserLoginField.Text.Trim() == "Введите Login")
            {
                MessageBox.Show("не введен Login");
                return;
            }
            if (UserMailField.Text.Trim() == "" || UserMailField.Text.Trim() == "Введите Email")
            {
                MessageBox.Show("не введен Email");
                return;
            }
            if (UserPasswordField.Text.Trim() == "" || UserPasswordField.Text.Trim() == "Введите Password")
            {
                MessageBox.Show("не введен Password");
                return;
            }

            DB db = new DB();
            MySqlCommand command = new MySqlCommand(
                "INSERT INTO users(login, email, password) VALUES(@login, @email, @password) ",
                db.GetConnection()
                );
            command.Parameters.AddWithValue("login", UserLoginField.Text);
            command.Parameters.AddWithValue("email", UserMailField.Text);
            command.Parameters.AddWithValue("password", Hash(UserPasswordField.Text));

            db.OpenConnection();
            try
            {
                if (command.ExecuteNonQuery() == 1) MessageBox.Show("acc Created");
                else MessageBox.Show("error created");
            }
            catch (MySqlException ex)
            {
                if (ex.Message.Contains("Duplicate entry")) MessageBox.Show("Такой логин уже существует!");
                else MessageBox.Show(ex.Message);
            }


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

        public void RegisterForm_Load(object sender, EventArgs e)
        {
            this.ActiveControl = label1;
        }

        private void LinkToAut_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            AutForm autForm = new AutForm();
            autForm.ShowDialog();
            this.Close();
        }
    }
}
