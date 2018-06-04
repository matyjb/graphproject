﻿namespace graphproject
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
            this.rLog = new System.Windows.Forms.RichTextBox();
            this.restart = new System.Windows.Forms.Button();
            this.bgenerate = new System.Windows.Forms.Button();
            this.GenGraphWorker = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.NUPvcount = new System.Windows.Forms.NumericUpDown();
            this.CBmixed = new System.Windows.Forms.CheckBox();
            this.CBdirected = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.EKbutton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.NUDsink = new System.Windows.Forms.NumericUpDown();
            this.NUDsource = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.bClearLog = new System.Windows.Forms.Button();
            this.bSaveLog = new System.Windows.Forms.Button();
            this.rTBLog = new System.Windows.Forms.RichTextBox();
            this.bAddToLog = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rCustomGraph = new System.Windows.Forms.RichTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.bLoadGraph = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.sfmLcanvas1 = new graphproject.SFMLcanvas();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUPvcount)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDsink)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDsource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // rLog
            // 
            this.rLog.Location = new System.Drawing.Point(7, 19);
            this.rLog.Name = "rLog";
            this.rLog.Size = new System.Drawing.Size(305, 91);
            this.rLog.TabIndex = 0;
            this.rLog.Text = "";
            // 
            // restart
            // 
            this.restart.Location = new System.Drawing.Point(813, 550);
            this.restart.Name = "restart";
            this.restart.Size = new System.Drawing.Size(111, 41);
            this.restart.TabIndex = 2;
            this.restart.Text = "restart wizualizatora";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(125, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "ilość V";
            // 
            // NUPvcount
            // 
            this.NUPvcount.Location = new System.Drawing.Point(128, 20);
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.EKbutton);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.NUDsink);
            this.groupBox2.Controls.Add(this.NUDsource);
            this.groupBox2.Location = new System.Drawing.Point(813, 425);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(111, 119);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "EdmondsKarp";
            // 
            // EKbutton
            // 
            this.EKbutton.Location = new System.Drawing.Point(7, 73);
            this.EKbutton.Name = "EKbutton";
            this.EKbutton.Size = new System.Drawing.Size(98, 35);
            this.EKbutton.TabIndex = 4;
            this.EKbutton.Text = "Pokaż";
            this.EKbutton.UseVisualStyleBackColor = true;
            this.EKbutton.Click += new System.EventHandler(this.EKbutton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "sink";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "source";
            // 
            // NUDsink
            // 
            this.NUDsink.Location = new System.Drawing.Point(7, 46);
            this.NUDsink.Name = "NUDsink";
            this.NUDsink.Size = new System.Drawing.Size(38, 20);
            this.NUDsink.TabIndex = 1;
            this.NUDsink.ValueChanged += new System.EventHandler(this.NUDsink_ValueChanged);
            // 
            // NUDsource
            // 
            this.NUDsource.Location = new System.Drawing.Point(7, 19);
            this.NUDsource.Name = "NUDsource";
            this.NUDsource.Size = new System.Drawing.Size(38, 20);
            this.NUDsource.TabIndex = 0;
            this.NUDsource.ValueChanged += new System.EventHandler(this.NUDsource_ValueChanged);
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(7, 46);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(38, 20);
            this.numericUpDown2.TabIndex = 1;
            // 
            // bClearLog
            // 
            this.bClearLog.Location = new System.Drawing.Point(7, 116);
            this.bClearLog.Name = "bClearLog";
            this.bClearLog.Size = new System.Drawing.Size(117, 23);
            this.bClearLog.TabIndex = 6;
            this.bClearLog.Text = "Wyczyść log";
            this.bClearLog.UseVisualStyleBackColor = true;
            this.bClearLog.Click += new System.EventHandler(this.bClearLog_Click);
            // 
            // bSaveLog
            // 
            this.bSaveLog.Location = new System.Drawing.Point(128, 116);
            this.bSaveLog.Name = "bSaveLog";
            this.bSaveLog.Size = new System.Drawing.Size(184, 23);
            this.bSaveLog.TabIndex = 7;
            this.bSaveLog.Text = "Zapisz log do pliku";
            this.bSaveLog.UseVisualStyleBackColor = true;
            this.bSaveLog.Click += new System.EventHandler(this.bSaveLog_Click);
            // 
            // rTBLog
            // 
            this.rTBLog.Location = new System.Drawing.Point(606, 12);
            this.rTBLog.Name = "rTBLog";
            this.rTBLog.Size = new System.Drawing.Size(318, 136);
            this.rTBLog.TabIndex = 0;
            this.rTBLog.Text = "";
            // 
            // bAddToLog
            // 
            this.bAddToLog.Location = new System.Drawing.Point(7, 145);
            this.bAddToLog.Name = "bAddToLog";
            this.bAddToLog.Size = new System.Drawing.Size(305, 23);
            this.bAddToLog.TabIndex = 8;
            this.bAddToLog.Text = "Dodaj do logu";
            this.bAddToLog.UseVisualStyleBackColor = true;
            this.bAddToLog.Click += new System.EventHandler(this.bAddToLog_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rLog);
            this.groupBox3.Controls.Add(this.bAddToLog);
            this.groupBox3.Controls.Add(this.bClearLog);
            this.groupBox3.Controls.Add(this.bSaveLog);
            this.groupBox3.Location = new System.Drawing.Point(606, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(318, 175);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Log";
            // 
            // rCustomGraph
            // 
            this.rCustomGraph.Location = new System.Drawing.Point(7, 19);
            this.rCustomGraph.Name = "rCustomGraph";
            this.rCustomGraph.Size = new System.Drawing.Size(245, 210);
            this.rCustomGraph.TabIndex = 10;
            this.rCustomGraph.Text = "";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.bLoadGraph);
            this.groupBox4.Controls.Add(this.rCustomGraph);
            this.groupBox4.Location = new System.Drawing.Point(606, 184);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(318, 235);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Własny graf";
            // 
            // bLoadGraph
            // 
            this.bLoadGraph.Location = new System.Drawing.Point(259, 19);
            this.bLoadGraph.Name = "bLoadGraph";
            this.bLoadGraph.Size = new System.Drawing.Size(53, 210);
            this.bLoadGraph.TabIndex = 11;
            this.bLoadGraph.Text = "Załaduj";
            this.bLoadGraph.UseVisualStyleBackColor = true;
            this.bLoadGraph.Click += new System.EventHandler(this.bLoadGraph_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(7, 19);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(245, 210);
            this.richTextBox1.TabIndex = 10;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 603);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.restart);
            this.Controls.Add(this.sfmLcanvas1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUPvcount)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDsink)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDsource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        
        private System.Windows.Forms.RichTextBox rLog;
        private SFMLcanvas sfmLcanvas1;
        private System.Windows.Forms.Button restart;
        private System.Windows.Forms.Button bgenerate;
        private System.ComponentModel.BackgroundWorker GenGraphWorker;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown NUPvcount;
        private System.Windows.Forms.CheckBox CBmixed;
        private System.Windows.Forms.CheckBox CBdirected;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown NUDsink;
        private System.Windows.Forms.NumericUpDown NUDsource;
        private System.Windows.Forms.Button EKbutton;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Button bClearLog;
        private System.Windows.Forms.Button bSaveLog;
        private System.Windows.Forms.RichTextBox rTBLog;
        private System.Windows.Forms.Button bAddToLog;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox rCustomGraph;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button bLoadGraph;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

