namespace BodyaAPP
{
    partial class AutForm
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
            this.AutBTN = new System.Windows.Forms.Button();
            this.UserPasswordField = new System.Windows.Forms.TextBox();
            this.UserLoginField = new System.Windows.Forms.TextBox();
            this.LinkToReg = new System.Windows.Forms.Label();
            this.linklabl = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // AutBTN
            // 
            this.AutBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(153)))), ((int)(((byte)(133)))));
            this.AutBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AutBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AutBTN.ForeColor = System.Drawing.Color.Honeydew;
            this.AutBTN.Location = new System.Drawing.Point(61, 258);
            this.AutBTN.Name = "AutBTN";
            this.AutBTN.Size = new System.Drawing.Size(135, 35);
            this.AutBTN.TabIndex = 8;
            this.AutBTN.Text = "Войти";
            this.AutBTN.UseVisualStyleBackColor = false;
            this.AutBTN.Click += new System.EventHandler(this.AutBTN_Click);
            // 
            // UserPasswordField
            // 
            this.UserPasswordField.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(48)))), ((int)(((byte)(31)))));
            this.UserPasswordField.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UserPasswordField.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UserPasswordField.ForeColor = System.Drawing.SystemColors.GrayText;
            this.UserPasswordField.Location = new System.Drawing.Point(42, 183);
            this.UserPasswordField.Name = "UserPasswordField";
            this.UserPasswordField.Size = new System.Drawing.Size(189, 25);
            this.UserPasswordField.TabIndex = 7;
            this.UserPasswordField.Enter += new System.EventHandler(this.textBox1_TextChanged);
            this.UserPasswordField.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // UserLoginField
            // 
            this.UserLoginField.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(48)))), ((int)(((byte)(31)))));
            this.UserLoginField.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UserLoginField.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UserLoginField.ForeColor = System.Drawing.SystemColors.GrayText;
            this.UserLoginField.Location = new System.Drawing.Point(42, 121);
            this.UserLoginField.Name = "UserLoginField";
            this.UserLoginField.Size = new System.Drawing.Size(189, 25);
            this.UserLoginField.TabIndex = 6;
            this.UserLoginField.Enter += new System.EventHandler(this.textBox1_TextChanged);
            this.UserLoginField.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // LinkToReg
            // 
            this.LinkToReg.AutoSize = true;
            this.LinkToReg.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LinkToReg.ForeColor = System.Drawing.Color.Honeydew;
            this.LinkToReg.Location = new System.Drawing.Point(56, 60);
            this.LinkToReg.Name = "LinkToReg";
            this.LinkToReg.Size = new System.Drawing.Size(166, 29);
            this.LinkToReg.TabIndex = 5;
            this.LinkToReg.Text = "Авторизация";
            // 
            // linklabl
            // 
            this.linklabl.AutoSize = true;
            this.linklabl.ForeColor = System.Drawing.Color.Honeydew;
            this.linklabl.LinkColor = System.Drawing.Color.Honeydew;
            this.linklabl.Location = new System.Drawing.Point(58, 335);
            this.linklabl.Name = "linklabl";
            this.linklabl.Size = new System.Drawing.Size(144, 16);
            this.linklabl.TabIndex = 9;
            this.linklabl.TabStop = true;
            this.linklabl.Text = "Зарегестрироваться";
            this.linklabl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklabl_LinkClicked);
            // 
            // AutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(117)))), ((int)(((byte)(76)))));
            this.ClientSize = new System.Drawing.Size(267, 403);
            this.Controls.Add(this.linklabl);
            this.Controls.Add(this.AutBTN);
            this.Controls.Add(this.UserPasswordField);
            this.Controls.Add(this.UserLoginField);
            this.Controls.Add(this.LinkToReg);
            this.ForeColor = System.Drawing.Color.BlueViolet;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизация";
            this.Load += new System.EventHandler(this.AutForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AutBTN;
        private System.Windows.Forms.TextBox UserPasswordField;
        private System.Windows.Forms.TextBox UserLoginField;
        private System.Windows.Forms.Label LinkToReg;
        private System.Windows.Forms.LinkLabel linklabl;
    }
}