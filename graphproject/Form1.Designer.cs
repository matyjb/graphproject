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
            this.bgenerate = new System.Windows.Forms.Button();
            this.GenGraphWorker = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CBdirected = new System.Windows.Forms.CheckBox();
            this.CBmixed = new System.Windows.Forms.CheckBox();
            this.NUPvcount = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUPvcount)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(606, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(318, 316);
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
            this.restart.Location = new System.Drawing.Point(606, 550);
            this.restart.Name = "restart";
            this.restart.Size = new System.Drawing.Size(318, 41);
            this.restart.TabIndex = 2;
            this.restart.Text = "restart";
            this.restart.UseVisualStyleBackColor = true;
            this.restart.Click += new System.EventHandler(this.restart_Click);
            // 
            // bgenerate
            // 
            this.bgenerate.Location = new System.Drawing.Point(7, 67);
            this.bgenerate.Name = "bgenerate";
            this.bgenerate.Size = new System.Drawing.Size(187, 41);
            this.bgenerate.TabIndex = 3;
            this.bgenerate.Text = "Generuj Graf";
            this.bgenerate.UseVisualStyleBackColor = true;
            this.bgenerate.Click += new System.EventHandler(this.bgenerate_Click);
            // 
            // GenGraphWorker
            // 
            this.GenGraphWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.GenGraphWorker_DoWork);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.NUPvcount);
            this.groupBox1.Controls.Add(this.CBmixed);
            this.groupBox1.Controls.Add(this.bgenerate);
            this.groupBox1.Controls.Add(this.CBdirected);
            this.groupBox1.Location = new System.Drawing.Point(606, 425);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 119);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Generator Grafów";
            // 
            // CBdirected
            // 
            this.CBdirected.AutoSize = true;
            this.CBdirected.Location = new System.Drawing.Point(7, 20);
            this.CBdirected.Name = "CBdirected";
            this.CBdirected.Size = new System.Drawing.Size(81, 17);
            this.CBdirected.TabIndex = 0;
            this.CBdirected.Text = "Skierowany";
            this.CBdirected.UseVisualStyleBackColor = true;
            // 
            // CBmixed
            // 
            this.CBmixed.AutoSize = true;
            this.CBmixed.Location = new System.Drawing.Point(7, 44);
            this.CBmixed.Name = "CBmixed";
            this.CBmixed.Size = new System.Drawing.Size(70, 17);
            this.CBmixed.TabIndex = 1;
            this.CBmixed.Text = "Mieszany";
            this.CBmixed.UseVisualStyleBackColor = true;
            // 
            // NUPvcount
            // 
            this.NUPvcount.Location = new System.Drawing.Point(128, 20);
            this.NUPvcount.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.NUPvcount.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.NUPvcount.Name = "NUPvcount";
            this.NUPvcount.Size = new System.Drawing.Size(42, 20);
            this.NUPvcount.TabIndex = 4;
            this.NUPvcount.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(125, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "ilość V";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 603);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.restart);
            this.Controls.Add(this.sfmLcanvas1);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUPvcount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        
        private System.Windows.Forms.RichTextBox richTextBox1;
        private SFMLcanvas sfmLcanvas1;
        private System.Windows.Forms.Button restart;
        private System.Windows.Forms.Button bgenerate;
        private System.ComponentModel.BackgroundWorker GenGraphWorker;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown NUPvcount;
        private System.Windows.Forms.CheckBox CBmixed;
        private System.Windows.Forms.CheckBox CBdirected;
    }
}

