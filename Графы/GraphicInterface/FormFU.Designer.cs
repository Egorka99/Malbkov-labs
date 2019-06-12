namespace GraphicInterface
{
    partial class FormFU
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.buttonFile = new System.Windows.Forms.Button();
            this.labelError = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonFU = new System.Windows.Forms.Button();
            this.buttonSCC = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.buttonMP = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.buttonFile);
            this.groupBox2.Controls.Add(this.labelError);
            this.groupBox2.Location = new System.Drawing.Point(26, 110);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(346, 164);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Матрица смежности";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(63, 43);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Выбрать файл:";
            // 
            // buttonFile
            // 
            this.buttonFile.Location = new System.Drawing.Point(157, 73);
            this.buttonFile.Name = "buttonFile";
            this.buttonFile.Size = new System.Drawing.Size(75, 23);
            this.buttonFile.TabIndex = 2;
            this.buttonFile.Text = "Файл ";
            this.buttonFile.UseVisualStyleBackColor = true;
            this.buttonFile.Click += new System.EventHandler(this.ButtonFile_Click);
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.Location = new System.Drawing.Point(63, 112);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(64, 13);
            this.labelError.TabIndex = 3;
            this.labelError.Text = "Имя файла";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(566, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Информация";
            // 
            // buttonFU
            // 
            this.buttonFU.Location = new System.Drawing.Point(54, 307);
            this.buttonFU.Name = "buttonFU";
            this.buttonFU.Size = new System.Drawing.Size(127, 67);
            this.buttonFU.TabIndex = 15;
            this.buttonFU.Text = "Алгоритм Флойда-Уоршела";
            this.buttonFU.UseVisualStyleBackColor = true;
            this.buttonFU.Click += new System.EventHandler(this.ButtonFU_Click);
            // 
            // buttonSCC
            // 
            this.buttonSCC.Location = new System.Drawing.Point(220, 307);
            this.buttonSCC.Name = "buttonSCC";
            this.buttonSCC.Size = new System.Drawing.Size(127, 67);
            this.buttonSCC.TabIndex = 16;
            this.buttonSCC.Text = "Поиск сильно связанных компонент";
            this.buttonSCC.UseVisualStyleBackColor = true;
            this.buttonSCC.Click += new System.EventHandler(this.ButtonSCC_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(467, 110);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(289, 247);
            this.textBox1.TabIndex = 17;
            this.textBox1.Visible = false;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(467, 110);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(289, 251);
            this.listBox1.TabIndex = 18;
            this.listBox1.Visible = false;
            // 
            // buttonMP
            // 
            this.buttonMP.Location = new System.Drawing.Point(131, 399);
            this.buttonMP.Name = "buttonMP";
            this.buttonMP.Size = new System.Drawing.Size(127, 67);
            this.buttonMP.TabIndex = 19;
            this.buttonMP.Text = "Кратчайший путь в ациклическом графе";
            this.buttonMP.UseVisualStyleBackColor = true;
            this.buttonMP.Click += new System.EventHandler(this.ButtonMP_Click);
            // 
            // FormFU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 524);
            this.Controls.Add(this.buttonMP);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonSCC);
            this.Controls.Add(this.buttonFU);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Name = "FormFU";
            this.Text = "Алгоритмы для орграфа";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button buttonFile;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonFU;
        private System.Windows.Forms.Button buttonSCC;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button buttonMP;
    }
}