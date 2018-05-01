namespace graphproject
{
    partial class Form1
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.sfmLcanvas1 = new graphproject.SFMLcanvas();
            this.restart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(606, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(318, 481);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // sfmLcanvas1
            // 
            this.sfmLcanvas1.Location = new System.Drawing.Point(0, 2);
            this.sfmLcanvas1.Name = "sfmLcanvas1";
            this.sfmLcanvas1.Size = new System.Drawing.Size(600, 600);
            this.sfmLcanvas1.TabIndex = 1;
            // 
            // restart
            // 
            this.restart.Location = new System.Drawing.Point(606, 499);
            this.restart.Name = "restart";
            this.restart.Size = new System.Drawing.Size(318, 92);
            this.restart.TabIndex = 2;
            this.restart.Text = "restart";
            this.restart.UseVisualStyleBackColor = true;
            this.restart.Click += new System.EventHandler(this.restart_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 603);
            this.Controls.Add(this.restart);
            this.Controls.Add(this.sfmLcanvas1);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        
        private System.Windows.Forms.RichTextBox richTextBox1;
        private SFMLcanvas sfmLcanvas1;
        private System.Windows.Forms.Button restart;
    }
}

