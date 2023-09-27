namespace WFA
{
    partial class win
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
            this.button3 = new System.Windows.Forms.Button();
            this.txtScore = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(226, 356);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(212, 94);
            this.button3.TabIndex = 8;
            this.button3.Text = "main menu";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtScore
            // 
            this.txtScore.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScore.Location = new System.Drawing.Point(319, 14);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(336, 73);
            this.txtScore.TabIndex = 7;
            this.txtScore.Tag = "txtScore";
            this.txtScore.Text = "score";
            this.txtScore.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(226, 564);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(212, 94);
            this.button2.TabIndex = 6;
            this.button2.Text = "exit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(226, 152);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(212, 94);
            this.button1.TabIndex = 5;
            this.button1.Text = "restart";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // win
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 782);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.txtScore);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "win";
            this.Text = "win";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.win_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label txtScore;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}