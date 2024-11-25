namespace BodyaAPP
{
    partial class RegisterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.UserLoginField = new System.Windows.Forms.TextBox();
            this.UserMailField = new System.Windows.Forms.TextBox();
            this.UserPasswordField = new System.Windows.Forms.TextBox();
            this.UserBn = new System.Windows.Forms.Button();
            this.LinkToAut = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Honeydew;
            this.label1.Location = new System.Drawing.Point(45, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Регестрация";
            // 
            // UserLoginField
            // 
            this.UserLoginField.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(48)))), ((int)(((byte)(31)))));
            this.UserLoginField.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UserLoginField.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UserLoginField.ForeColor = System.Drawing.SystemColors.GrayText;
            this.UserLoginField.Location = new System.Drawing.Point(31, 86);
            this.UserLoginField.Name = "UserLoginField";
            this.UserLoginField.Size = new System.Drawing.Size(189, 25);
            this.UserLoginField.TabIndex = 1;
            this.UserLoginField.Enter += new System.EventHandler(this.textBox1_TextChanged);
            this.UserLoginField.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // UserMailField
            // 
            this.UserMailField.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(48)))), ((int)(((byte)(31)))));
            this.UserMailField.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UserMailField.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UserMailField.ForeColor = System.Drawing.SystemColors.GrayText;
            this.UserMailField.Location = new System.Drawing.Point(31, 142);
            this.UserMailField.Name = "UserMailField";
            this.UserMailField.Size = new System.Drawing.Size(189, 25);
            this.UserMailField.TabIndex = 2;
            this.UserMailField.Enter += new System.EventHandler(this.textBox1_TextChanged);
            this.UserMailField.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // UserPasswordField
            // 
            this.UserPasswordField.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(48)))), ((int)(((byte)(31)))));
            this.UserPasswordField.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UserPasswordField.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UserPasswordField.ForeColor = System.Drawing.SystemColors.GrayText;
            this.UserPasswordField.Location = new System.Drawing.Point(31, 191);
            this.UserPasswordField.Name = "UserPasswordField";
            this.UserPasswordField.Size = new System.Drawing.Size(189, 25);
            this.UserPasswordField.TabIndex = 3;
            this.UserPasswordField.Enter += new System.EventHandler(this.textBox1_TextChanged);
            this.UserPasswordField.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // UserBn
            // 
            this.UserBn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(153)))), ((int)(((byte)(133)))));
            this.UserBn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UserBn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UserBn.ForeColor = System.Drawing.Color.Honeydew;
            this.UserBn.Location = new System.Drawing.Point(12, 251);
            this.UserBn.Name = "UserBn";
            this.UserBn.Size = new System.Drawing.Size(220, 60);
            this.UserBn.TabIndex = 4;
            this.UserBn.Text = "Зарегестрироваться";
            this.UserBn.UseVisualStyleBackColor = false;
            this.UserBn.Click += new System.EventHandler(this.UserBn_Click);
            // 
            // LinkToAut
            // 
            this.LinkToAut.AutoSize = true;
            this.LinkToAut.LinkColor = System.Drawing.Color.Honeydew;
            this.LinkToAut.Location = new System.Drawing.Point(81, 340);
            this.LinkToAut.Name = "LinkToAut";
            this.LinkToAut.Size = new System.Drawing.Size(94, 16);
            this.LinkToAut.TabIndex = 5;
            this.LinkToAut.TabStop = true;
            this.LinkToAut.Text = "Авторизация";
            this.LinkToAut.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkToAut_LinkClicked);
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(117)))), ((int)(((byte)(76)))));
            this.ClientSize = new System.Drawing.Size(267, 403);
            this.Controls.Add(this.LinkToAut);
            this.Controls.Add(this.UserBn);
            this.Controls.Add(this.UserPasswordField);
            this.Controls.Add(this.UserMailField);
            this.Controls.Add(this.UserLoginField);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.BlueViolet;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RegisterForm";
            this.Load += new System.EventHandler(this.RegisterForm_Load);
            this.Enter += new System.EventHandler(this.textBox1_TextChanged);
            this.Leave += new System.EventHandler(this.textBox1_Leave);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox UserLoginField;
        private System.Windows.Forms.TextBox UserMailField;
        private System.Windows.Forms.TextBox UserPasswordField;
        private System.Windows.Forms.Button UserBn;
        private System.Windows.Forms.LinkLabel LinkToAut;
    }
}