namespace UnrealClassRenamer
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
            this.textBox_OldClassName = new System.Windows.Forms.TextBox();
            this.textBox_NewClassName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.label_FolderURL = new System.Windows.Forms.Label();
            this.btnRename = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_OldClassName
            // 
            this.textBox_OldClassName.Location = new System.Drawing.Point(33, 68);
            this.textBox_OldClassName.Name = "textBox_OldClassName";
            this.textBox_OldClassName.Size = new System.Drawing.Size(237, 20);
            this.textBox_OldClassName.TabIndex = 0;
            // 
            // textBox_NewClassName
            // 
            this.textBox_NewClassName.Location = new System.Drawing.Point(286, 68);
            this.textBox_NewClassName.Name = "textBox_NewClassName";
            this.textBox_NewClassName.Size = new System.Drawing.Size(237, 20);
            this.textBox_NewClassName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Old Class Name";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(286, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "New Class Name";
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Location = new System.Drawing.Point(30, 12);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(160, 23);
            this.btnSelectFolder.TabIndex = 4;
            this.btnSelectFolder.Text = "Select UE4 Project Folder";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // label_FolderURL
            // 
            this.label_FolderURL.AutoSize = true;
            this.label_FolderURL.Location = new System.Drawing.Point(207, 17);
            this.label_FolderURL.Name = "label_FolderURL";
            this.label_FolderURL.Size = new System.Drawing.Size(212, 13);
            this.label_FolderURL.TabIndex = 5;
            this.label_FolderURL.Text = "<<SELECT YOUR UPROJECT FOLDER>>";
            // 
            // btnRename
            // 
            this.btnRename.Location = new System.Drawing.Point(33, 94);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(120, 23);
            this.btnRename.TabIndex = 6;
            this.btnRename.Text = "RENAME";
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkRed;
            this.label3.Location = new System.Drawing.Point(15, 256);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(212, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "IMPORTANT, READ BEFORE USE!!";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkRed;
            this.label4.Location = new System.Drawing.Point(13, 273);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(258, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "1. Close Unreal and Visual Studio before run";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkRed;
            this.label5.Location = new System.Drawing.Point(14, 286);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(268, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "2. Backup Before use (Git, Perforce, SVN, etc)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkRed;
            this.label6.Location = new System.Drawing.Point(14, 299);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(209, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "3. May be Buggy, PLEASE BACKUP";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(36, 146);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "REGENERATE PROJECT";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 328);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnRename);
            this.Controls.Add(this.label_FolderURL);
            this.Controls.Add(this.btnSelectFolder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_NewClassName);
            this.Controls.Add(this.textBox_OldClassName);
            this.Name = "Form1";
            this.Text = "Unreal Class Renamer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_OldClassName;
        private System.Windows.Forms.TextBox textBox_NewClassName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.Label label_FolderURL;
        private System.Windows.Forms.Button btnRename;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
    }
}

