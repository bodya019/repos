namespace BodyaAPP
{
    partial class PinPong
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
            this.components = new System.ComponentModel.Container();
            this.platform = new System.Windows.Forms.PictureBox();
            this.ball = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.panel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.Ulose = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.platform)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ball)).BeginInit();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // platform
            // 
            this.platform.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.platform.Location = new System.Drawing.Point(269, 399);
            this.platform.Name = "platform";
            this.platform.Size = new System.Drawing.Size(170, 26);
            this.platform.TabIndex = 0;
            this.platform.TabStop = false;
            // 
            // ball
            // 
            this.ball.BackColor = System.Drawing.Color.Green;
            this.ball.Location = new System.Drawing.Point(21, 210);
            this.ball.Name = "ball";
            this.ball.Size = new System.Drawing.Size(49, 46);
            this.ball.TabIndex = 1;
            this.ball.TabStop = false;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // panel
            // 
            this.panel.Controls.Add(this.Ulose);
            this.panel.Controls.Add(this.label1);
            this.panel.Controls.Add(this.ball);
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(800, 450);
            this.panel.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(589, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Результат: 0\r\n";
            // 
            // Ulose
            // 
            this.Ulose.AutoSize = true;
            this.Ulose.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Ulose.Location = new System.Drawing.Point(245, 192);
            this.Ulose.Name = "Ulose";
            this.Ulose.Size = new System.Drawing.Size(285, 42);
            this.Ulose.TabIndex = 3;
            this.Ulose.Text = "Вы проиграли!";
            this.Ulose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Ulose.Visible = false;
            // 
            // PinPong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.platform);
            this.Controls.Add(this.panel);
            this.Name = "PinPong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PinPong";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PinPong_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.platform)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ball)).EndInit();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox platform;
        private System.Windows.Forms.PictureBox ball;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Ulose;
    }
}