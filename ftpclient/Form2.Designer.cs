namespace ftpclient
{
    partial class Form2
    {
        private const bool V = false;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.button1 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button4 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.feltöltésToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mappaFeltöltéseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fájlokFeltöltéseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gyökérkönyvtárbaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mappaLetöltéseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mappaTörléseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserDialog2 = new System.Windows.Forms.FolderBrowserDialog();
            this.panel3 = new System.Windows.Forms.Panel();
            this.data4 = new System.Windows.Forms.Label();
            this.data3 = new System.Windows.Forms.Label();
            this.data2 = new System.Windows.Forms.Label();
            this.data1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(790, 457);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 54);
            this.button1.TabIndex = 0;
            this.button1.Text = "Szerver választás";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ItemHeight = 24;
            this.listBox1.Location = new System.Drawing.Point(12, 41);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox1.Size = new System.Drawing.Size(872, 388);
            this.listBox1.TabIndex = 5;
            this.listBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseClick);
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button4.Location = new System.Drawing.Point(790, 523);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(91, 54);
            this.button4.TabIndex = 6;
            this.button4.Text = "Kilépés";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(21, 79);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(307, 24);
            this.progressBar1.TabIndex = 9;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(21, 50);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(307, 24);
            this.progressBar2.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(103, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 25);
            this.label1.TabIndex = 11;
            this.label1.Text = "0/0";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.feltöltésToolStripMenuItem,
            this.infoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1257, 24);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // feltöltésToolStripMenuItem
            // 
            this.feltöltésToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mappaFeltöltéseToolStripMenuItem,
            this.fájlokFeltöltéseToolStripMenuItem,
            this.gyökérkönyvtárbaToolStripMenuItem,
            this.mappaLetöltéseToolStripMenuItem,
            this.mappaTörléseToolStripMenuItem});
            this.feltöltésToolStripMenuItem.Name = "feltöltésToolStripMenuItem";
            this.feltöltésToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.feltöltésToolStripMenuItem.Text = "Menü";
            // 
            // mappaFeltöltéseToolStripMenuItem
            // 
            this.mappaFeltöltéseToolStripMenuItem.Name = "mappaFeltöltéseToolStripMenuItem";
            this.mappaFeltöltéseToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.mappaFeltöltéseToolStripMenuItem.Text = "Mappa feltöltése";
            this.mappaFeltöltéseToolStripMenuItem.Click += new System.EventHandler(this.mappaFeltöltéseToolStripMenuItem_Click);
            // 
            // fájlokFeltöltéseToolStripMenuItem
            // 
            this.fájlokFeltöltéseToolStripMenuItem.Name = "fájlokFeltöltéseToolStripMenuItem";
            this.fájlokFeltöltéseToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.fájlokFeltöltéseToolStripMenuItem.Text = "Fájlok feltöltése";
            this.fájlokFeltöltéseToolStripMenuItem.Click += new System.EventHandler(this.fájlokFeltöltéseToolStripMenuItem_Click);
            // 
            // gyökérkönyvtárbaToolStripMenuItem
            // 
            this.gyökérkönyvtárbaToolStripMenuItem.Name = "gyökérkönyvtárbaToolStripMenuItem";
            this.gyökérkönyvtárbaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.gyökérkönyvtárbaToolStripMenuItem.Text = "Gyökér könyvtár";
            this.gyökérkönyvtárbaToolStripMenuItem.Click += new System.EventHandler(this.gyökérkönyvtárbaToolStripMenuItem_Click);
            // 
            // mappaLetöltéseToolStripMenuItem
            // 
            this.mappaLetöltéseToolStripMenuItem.Name = "mappaLetöltéseToolStripMenuItem";
            this.mappaLetöltéseToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.mappaLetöltéseToolStripMenuItem.Text = "Mappa letöltése";
            this.mappaLetöltéseToolStripMenuItem.Click += new System.EventHandler(this.mappaLetöltéseToolStripMenuItem_Click);
            // 
            // mappaTörléseToolStripMenuItem
            // 
            this.mappaTörléseToolStripMenuItem.Name = "mappaTörléseToolStripMenuItem";
            this.mappaTörléseToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.mappaTörléseToolStripMenuItem.Text = "Mappa törlése";
            this.mappaTörléseToolStripMenuItem.Click += new System.EventHandler(this.mappaTörléseToolStripMenuItem_Click);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.infoToolStripMenuItem.Text = "Info";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.progressBar2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Location = new System.Drawing.Point(12, 447);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(347, 138);
            this.panel1.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(117, 106);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 25);
            this.label8.TabIndex = 13;
            this.label8.Text = "0/0 MB";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(17, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 24);
            this.label2.TabIndex = 12;
            this.label2.Text = "Állapot:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(365, 447);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(307, 138);
            this.panel2.TabIndex = 16;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button2.Location = new System.Drawing.Point(15, 97);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(249, 28);
            this.button2.TabIndex = 2;
            this.button2.Text = "Mehet";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox1.Location = new System.Drawing.Point(15, 50);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(249, 35);
            this.textBox1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(11, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "Mappa neve:";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button3.Location = new System.Drawing.Point(678, 457);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(106, 54);
            this.button3.TabIndex = 17;
            this.button3.Text = "Fájlok törlése";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button5.Location = new System.Drawing.Point(678, 523);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(106, 54);
            this.button5.TabIndex = 18;
            this.button5.Text = "Kijelölt fájlok letöltése";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.data4);
            this.panel3.Controls.Add(this.data3);
            this.panel3.Controls.Add(this.data2);
            this.panel3.Controls.Add(this.data1);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.panel3.Location = new System.Drawing.Point(890, 41);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(355, 543);
            this.panel3.TabIndex = 21;
            // 
            // data4
            // 
            this.data4.AutoSize = true;
            this.data4.Cursor = System.Windows.Forms.Cursors.Default;
            this.data4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.data4.Location = new System.Drawing.Point(148, 160);
            this.data4.Name = "data4";
            this.data4.Size = new System.Drawing.Size(14, 18);
            this.data4.TabIndex = 28;
            this.data4.Text = "-";
            // 
            // data3
            // 
            this.data3.AutoSize = true;
            this.data3.Cursor = System.Windows.Forms.Cursors.Default;
            this.data3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.data3.Location = new System.Drawing.Point(212, 109);
            this.data3.Name = "data3";
            this.data3.Size = new System.Drawing.Size(14, 18);
            this.data3.TabIndex = 27;
            this.data3.Text = "-";
            // 
            // data2
            // 
            this.data2.AutoSize = true;
            this.data2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.data2.Location = new System.Drawing.Point(118, 61);
            this.data2.Name = "data2";
            this.data2.Size = new System.Drawing.Size(14, 18);
            this.data2.TabIndex = 26;
            this.data2.Text = "-";
            // 
            // data1
            // 
            this.data1.AutoSize = true;
            this.data1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.data1.Location = new System.Drawing.Point(98, 15);
            this.data1.Name = "data1";
            this.data1.Size = new System.Drawing.Size(14, 18);
            this.data1.TabIndex = 25;
            this.data1.Text = "-";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Cursor = System.Windows.Forms.Cursors.Default;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(21, 160);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 18);
            this.label7.TabIndex = 24;
            this.label7.Text = "Fájl engedély:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Cursor = System.Windows.Forms.Cursors.Default;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(21, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(185, 18);
            this.label6.TabIndex = 23;
            this.label6.Text = "Fájl utolsó módosítása:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(21, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 18);
            this.label5.TabIndex = 22;
            this.label5.Text = "Fájl méret:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(21, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 18);
            this.label4.TabIndex = 21;
            this.label4.Text = "Fájl név:";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(1257, 596);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FTP - Csatlakozva";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem feltöltésToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fájlokFeltöltéseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gyökérkönyvtárbaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ToolStripMenuItem mappaFeltöltéseToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog2;
        private System.Windows.Forms.ToolStripMenuItem mappaLetöltéseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mappaTörléseToolStripMenuItem;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label data4;
        private System.Windows.Forms.Label data3;
        private System.Windows.Forms.Label data2;
        private System.Windows.Forms.Label data1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
    }
}