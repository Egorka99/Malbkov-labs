namespace GraphicInterface
{
    partial class DrawGraphForm
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
            this.sheet = new System.Windows.Forms.PictureBox();
            this.drawVertexButton = new System.Windows.Forms.Button();
            this.drawEdgeButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.deleteALLButton = new System.Windows.Forms.Button();
            this.buttonPrim = new System.Windows.Forms.Button();
            this.buttonKruskal = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panelKruskal = new System.Windows.Forms.Panel();
            this.panelPrim = new System.Windows.Forms.Panel();
            this.panelBF = new System.Windows.Forms.Panel();
            this.buttonBF = new System.Windows.Forms.Button();
            this.panelDFS = new System.Windows.Forms.Panel();
            this.buttonDFS = new System.Windows.Forms.Button();
            this.panelCycles = new System.Windows.Forms.Panel();
            this.buttonGamilton = new System.Windows.Forms.Button();
            this.buttonEuler = new System.Windows.Forms.Button();
            this.panelDijktra = new System.Windows.Forms.Panel();
            this.buttonDijkstra = new System.Windows.Forms.Button();
            this.panelFU = new System.Windows.Forms.Panel();
            this.buttonFU = new System.Windows.Forms.Button();
            this.panelSCC = new System.Windows.Forms.Panel();
            this.buttonSCC = new System.Windows.Forms.Button();
            this.panelBFS = new System.Windows.Forms.Panel();
            this.BFS_button = new System.Windows.Forms.Button();
            this.panelMP = new System.Windows.Forms.Panel();
            this.buttonMP = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.sheet)).BeginInit();
            this.panelKruskal.SuspendLayout();
            this.panelPrim.SuspendLayout();
            this.panelBF.SuspendLayout();
            this.panelDFS.SuspendLayout();
            this.panelCycles.SuspendLayout();
            this.panelDijktra.SuspendLayout();
            this.panelFU.SuspendLayout();
            this.panelSCC.SuspendLayout();
            this.panelBFS.SuspendLayout();
            this.panelMP.SuspendLayout();
            this.SuspendLayout();
            // 
            // sheet
            // 
            this.sheet.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.sheet.Location = new System.Drawing.Point(113, 12);
            this.sheet.Name = "sheet";
            this.sheet.Size = new System.Drawing.Size(846, 449);
            this.sheet.TabIndex = 0;
            this.sheet.TabStop = false;
            this.sheet.MouseClick += new System.Windows.Forms.MouseEventHandler(this.sheet_MouseClick);
            // 
            // drawVertexButton
            // 
            this.drawVertexButton.Location = new System.Drawing.Point(12, 46);
            this.drawVertexButton.Name = "drawVertexButton";
            this.drawVertexButton.Size = new System.Drawing.Size(95, 59);
            this.drawVertexButton.TabIndex = 1;
            this.drawVertexButton.Text = "Нарисовать вершину";
            this.drawVertexButton.UseVisualStyleBackColor = true;
            this.drawVertexButton.Click += new System.EventHandler(this.drawVertexButton_Click);
            // 
            // drawEdgeButton
            // 
            this.drawEdgeButton.Location = new System.Drawing.Point(12, 147);
            this.drawEdgeButton.Name = "drawEdgeButton";
            this.drawEdgeButton.Size = new System.Drawing.Size(95, 59);
            this.drawEdgeButton.TabIndex = 2;
            this.drawEdgeButton.Text = "Нарисовать ребро";
            this.drawEdgeButton.UseVisualStyleBackColor = true;
            this.drawEdgeButton.Click += new System.EventHandler(this.drawEdgeButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(12, 247);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(95, 59);
            this.deleteButton.TabIndex = 4;
            this.deleteButton.Text = "Удалить";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // deleteALLButton
            // 
            this.deleteALLButton.Location = new System.Drawing.Point(12, 343);
            this.deleteALLButton.Name = "deleteALLButton";
            this.deleteALLButton.Size = new System.Drawing.Size(95, 59);
            this.deleteALLButton.TabIndex = 5;
            this.deleteALLButton.Text = "Удалить все";
            this.deleteALLButton.UseVisualStyleBackColor = true;
            this.deleteALLButton.Click += new System.EventHandler(this.deleteALLButton_Click);
            // 
            // buttonPrim
            // 
            this.buttonPrim.Location = new System.Drawing.Point(27, 21);
            this.buttonPrim.Name = "buttonPrim";
            this.buttonPrim.Size = new System.Drawing.Size(158, 62);
            this.buttonPrim.TabIndex = 6;
            this.buttonPrim.Text = "Решить Алгоритмом Прима";
            this.buttonPrim.UseVisualStyleBackColor = true;
            this.buttonPrim.Click += new System.EventHandler(this.buttonPrim_Click);
            // 
            // buttonKruskal
            // 
            this.buttonKruskal.Location = new System.Drawing.Point(16, 15);
            this.buttonKruskal.Name = "buttonKruskal";
            this.buttonKruskal.Size = new System.Drawing.Size(184, 62);
            this.buttonKruskal.TabIndex = 7;
            this.buttonKruskal.Text = "Решить Алгоритмом Крускала";
            this.buttonKruskal.UseVisualStyleBackColor = true;
            this.buttonKruskal.Click += new System.EventHandler(this.buttonKruskal_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(231, 22);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(114, 61);
            this.button2.TabIndex = 7;
            this.button2.Text = "иттерация прим";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(216, 16);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(125, 61);
            this.button3.TabIndex = 8;
            this.button3.Text = "иттерация Крускал";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Алгоритм Крускала",
            "Алгоритм Прима",
            "Алгоритм Беллмана-Форда",
            "Алгоритм Флойда-Уоршелла",
            "Поиск в глубину (DFS)",
            "Циклы в графах",
            "Алгоритм Дейкстры",
            "Поиск сильно связанных компонент",
            "Поиск в ширину (BFS)",
            "Кратчайшее расстояние в бесконтурном графе"});
            this.comboBox1.Location = new System.Drawing.Point(153, 514);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(244, 21);
            this.comboBox1.TabIndex = 9;
            this.comboBox1.UseWaitCursor = true;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 514);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Алгоритмы";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(460, 514);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(492, 134);
            this.listBox1.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(672, 480);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Информация";
            // 
            // panelKruskal
            // 
            this.panelKruskal.Controls.Add(this.buttonKruskal);
            this.panelKruskal.Controls.Add(this.button3);
            this.panelKruskal.Location = new System.Drawing.Point(64, 545);
            this.panelKruskal.Name = "panelKruskal";
            this.panelKruskal.Size = new System.Drawing.Size(356, 100);
            this.panelKruskal.TabIndex = 13;
            this.panelKruskal.Visible = false;
            // 
            // panelPrim
            // 
            this.panelPrim.Controls.Add(this.buttonPrim);
            this.panelPrim.Controls.Add(this.button2);
            this.panelPrim.Location = new System.Drawing.Point(44, 545);
            this.panelPrim.Name = "panelPrim";
            this.panelPrim.Size = new System.Drawing.Size(376, 100);
            this.panelPrim.TabIndex = 14;
            this.panelPrim.Visible = false;
            // 
            // panelBF
            // 
            this.panelBF.Controls.Add(this.buttonBF);
            this.panelBF.Location = new System.Drawing.Point(122, 96);
            this.panelBF.Name = "panelBF";
            this.panelBF.Size = new System.Drawing.Size(376, 100);
            this.panelBF.TabIndex = 15;
            this.panelBF.Visible = false;
            // 
            // buttonBF
            // 
            this.buttonBF.Location = new System.Drawing.Point(92, 16);
            this.buttonBF.Name = "buttonBF";
            this.buttonBF.Size = new System.Drawing.Size(200, 62);
            this.buttonBF.TabIndex = 0;
            this.buttonBF.Text = "Кратчайшее расстояние от начальной вершины до остальных";
            this.buttonBF.UseVisualStyleBackColor = true;
            this.buttonBF.Click += new System.EventHandler(this.ButtonBF_Click);
            // 
            // panelDFS
            // 
            this.panelDFS.Controls.Add(this.buttonDFS);
            this.panelDFS.Location = new System.Drawing.Point(0, 1);
            this.panelDFS.Name = "panelDFS";
            this.panelDFS.Size = new System.Drawing.Size(379, 100);
            this.panelDFS.TabIndex = 16;
            this.panelDFS.Visible = false;
            this.panelDFS.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelDFS_Paint);
            // 
            // buttonDFS
            // 
            this.buttonDFS.Location = new System.Drawing.Point(112, 21);
            this.buttonDFS.Name = "buttonDFS";
            this.buttonDFS.Size = new System.Drawing.Size(160, 48);
            this.buttonDFS.TabIndex = 0;
            this.buttonDFS.Text = "Обход в глубину";
            this.buttonDFS.UseVisualStyleBackColor = true;
            this.buttonDFS.Click += new System.EventHandler(this.ButtonDFS_Click);
            // 
            // panelCycles
            // 
            this.panelCycles.Controls.Add(this.buttonGamilton);
            this.panelCycles.Controls.Add(this.buttonEuler);
            this.panelCycles.Controls.Add(this.panelBF);
            this.panelCycles.Location = new System.Drawing.Point(44, 545);
            this.panelCycles.Name = "panelCycles";
            this.panelCycles.Size = new System.Drawing.Size(379, 100);
            this.panelCycles.TabIndex = 17;
            this.panelCycles.Visible = false;
            // 
            // buttonGamilton
            // 
            this.buttonGamilton.Location = new System.Drawing.Point(219, 23);
            this.buttonGamilton.Name = "buttonGamilton";
            this.buttonGamilton.Size = new System.Drawing.Size(114, 49);
            this.buttonGamilton.TabIndex = 1;
            this.buttonGamilton.Text = "Гамильтонов цикл";
            this.buttonGamilton.UseVisualStyleBackColor = true;
            this.buttonGamilton.Click += new System.EventHandler(this.ButtonGamilton_Click);
            // 
            // buttonEuler
            // 
            this.buttonEuler.Location = new System.Drawing.Point(39, 23);
            this.buttonEuler.Name = "buttonEuler";
            this.buttonEuler.Size = new System.Drawing.Size(118, 49);
            this.buttonEuler.TabIndex = 0;
            this.buttonEuler.Text = "Эйлеров цикл";
            this.buttonEuler.UseVisualStyleBackColor = true;
            this.buttonEuler.Click += new System.EventHandler(this.ButtonEuler_Click);
            // 
            // panelDijktra
            // 
            this.panelDijktra.Controls.Add(this.buttonDijkstra);
            this.panelDijktra.Location = new System.Drawing.Point(44, 545);
            this.panelDijktra.Name = "panelDijktra";
            this.panelDijktra.Size = new System.Drawing.Size(379, 100);
            this.panelDijktra.TabIndex = 18;
            this.panelDijktra.Visible = false;
            // 
            // buttonDijkstra
            // 
            this.buttonDijkstra.Location = new System.Drawing.Point(105, 16);
            this.buttonDijkstra.Name = "buttonDijkstra";
            this.buttonDijkstra.Size = new System.Drawing.Size(167, 65);
            this.buttonDijkstra.TabIndex = 0;
            this.buttonDijkstra.Text = "Кратчайшие пути от одной из вершин графа до всех остальных";
            this.buttonDijkstra.UseVisualStyleBackColor = true;
            this.buttonDijkstra.Click += new System.EventHandler(this.ButtonDijkstra_Click);
            // 
            // panelFU
            // 
            this.panelFU.Controls.Add(this.buttonFU);
            this.panelFU.Location = new System.Drawing.Point(44, 545);
            this.panelFU.Name = "panelFU";
            this.panelFU.Size = new System.Drawing.Size(379, 100);
            this.panelFU.TabIndex = 19;
            this.panelFU.Visible = false;
            // 
            // buttonFU
            // 
            this.buttonFU.Location = new System.Drawing.Point(112, 25);
            this.buttonFU.Name = "buttonFU";
            this.buttonFU.Size = new System.Drawing.Size(154, 46);
            this.buttonFU.TabIndex = 20;
            this.buttonFU.Text = "Построить матрицу расстояний";
            this.buttonFU.UseVisualStyleBackColor = true;
            this.buttonFU.Click += new System.EventHandler(this.ButtonFU_Click);
            // 
            // panelSCC
            // 
            this.panelSCC.Controls.Add(this.buttonSCC);
            this.panelSCC.Location = new System.Drawing.Point(44, 544);
            this.panelSCC.Name = "panelSCC";
            this.panelSCC.Size = new System.Drawing.Size(379, 100);
            this.panelSCC.TabIndex = 20;
            this.panelSCC.Visible = false;
            // 
            // buttonSCC
            // 
            this.buttonSCC.Location = new System.Drawing.Point(112, 28);
            this.buttonSCC.Name = "buttonSCC";
            this.buttonSCC.Size = new System.Drawing.Size(141, 48);
            this.buttonSCC.TabIndex = 21;
            this.buttonSCC.Text = "Поиск сильно связанных компонент";
            this.buttonSCC.UseVisualStyleBackColor = true;
            this.buttonSCC.Click += new System.EventHandler(this.ButtonSCC_Click);
            // 
            // panelBFS
            // 
            this.panelBFS.Controls.Add(this.BFS_button);
            this.panelBFS.Controls.Add(this.panelDFS);
            this.panelBFS.Location = new System.Drawing.Point(0, 0);
            this.panelBFS.Name = "panelBFS";
            this.panelBFS.Size = new System.Drawing.Size(379, 100);
            this.panelBFS.TabIndex = 21;
            this.panelBFS.Visible = false;
            // 
            // BFS_button
            // 
            this.BFS_button.Location = new System.Drawing.Point(112, 28);
            this.BFS_button.Name = "BFS_button";
            this.BFS_button.Size = new System.Drawing.Size(141, 48);
            this.BFS_button.TabIndex = 21;
            this.BFS_button.Text = "Поиск в ширину BFS ";
            this.BFS_button.UseVisualStyleBackColor = true;
            this.BFS_button.Click += new System.EventHandler(this.BFS_button_Click);
            // 
            // panelMP
            // 
            this.panelMP.Controls.Add(this.buttonMP);
            this.panelMP.Controls.Add(this.panelBFS);
            this.panelMP.Location = new System.Drawing.Point(44, 544);
            this.panelMP.Name = "panelMP";
            this.panelMP.Size = new System.Drawing.Size(379, 100);
            this.panelMP.TabIndex = 22;
            this.panelMP.Visible = false;
            // 
            // buttonMP
            // 
            this.buttonMP.Location = new System.Drawing.Point(98, 19);
            this.buttonMP.Name = "buttonMP";
            this.buttonMP.Size = new System.Drawing.Size(168, 58);
            this.buttonMP.TabIndex = 23;
            this.buttonMP.Text = "Кратчайшее расстояние в ациклическом графе";
            this.buttonMP.UseVisualStyleBackColor = true;
            this.buttonMP.Click += new System.EventHandler(this.ButtonMP_Click);
            // 
            // DrawGraphForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 664);
            this.Controls.Add(this.panelMP);
            this.Controls.Add(this.panelFU);
            this.Controls.Add(this.panelSCC);
            this.Controls.Add(this.panelDijktra);
            this.Controls.Add(this.panelCycles);
            this.Controls.Add(this.panelPrim);
            this.Controls.Add(this.panelKruskal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.deleteALLButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.drawEdgeButton);
            this.Controls.Add(this.drawVertexButton);
            this.Controls.Add(this.sheet);
            this.Name = "DrawGraphForm";
            this.Text = "Графы и алгоритмы";
            ((System.ComponentModel.ISupportInitialize)(this.sheet)).EndInit();
            this.panelKruskal.ResumeLayout(false);
            this.panelPrim.ResumeLayout(false);
            this.panelBF.ResumeLayout(false);
            this.panelDFS.ResumeLayout(false);
            this.panelCycles.ResumeLayout(false);
            this.panelDijktra.ResumeLayout(false);
            this.panelFU.ResumeLayout(false);
            this.panelSCC.ResumeLayout(false);
            this.panelBFS.ResumeLayout(false);
            this.panelMP.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox sheet;
        private System.Windows.Forms.Button drawVertexButton;
        private System.Windows.Forms.Button drawEdgeButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button deleteALLButton;
        private System.Windows.Forms.Button buttonPrim;
        private System.Windows.Forms.Button buttonKruskal;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelKruskal;
        private System.Windows.Forms.Panel panelPrim;
        private System.Windows.Forms.Panel panelBF;
        private System.Windows.Forms.Button buttonBF;
        private System.Windows.Forms.Panel panelDFS;
        private System.Windows.Forms.Button buttonDFS;
        private System.Windows.Forms.Panel panelCycles;
        private System.Windows.Forms.Button buttonGamilton;
        private System.Windows.Forms.Button buttonEuler;
        private System.Windows.Forms.Panel panelDijktra;
        private System.Windows.Forms.Button buttonDijkstra;
        private System.Windows.Forms.Panel panelFU;
        private System.Windows.Forms.Button buttonFU;
        private System.Windows.Forms.Panel panelSCC;
        private System.Windows.Forms.Button buttonSCC;
        private System.Windows.Forms.Panel panelBFS;
        private System.Windows.Forms.Button BFS_button;
        private System.Windows.Forms.Panel panelMP;
        private System.Windows.Forms.Button buttonMP;
    }
}