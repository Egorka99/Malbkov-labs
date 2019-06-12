using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Labs; 

namespace GraphicInterface
{
    public partial class FormFU : Form 
    {
        public FormFU()
        {
            InitializeComponent();
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";



        }

        Graph graph; 
            

        private void ButtonFile_Click(object sender, EventArgs e)
        {

            try 
            {
                if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;

                string filename = openFileDialog1.FileName;

                StreamReader sr = new StreamReader(filename); 

                buttonFU.Enabled = true;   
                buttonSCC.Enabled = true;
                 
                graph = new Graph(sr);
                 
                labelError.Text = filename; 
            }    
            catch (IndexOutOfRangeException) 
            {
                labelError.Text = "Файл содержит неверные данные"; 
                labelError.ForeColor = Color.Red; 
            }
            catch (Exception ex)
            {
                labelError.Text = ex.Message;
                labelError.ForeColor = Color.Red;
            }
             
        }

        private void ButtonFU_Click(object sender, EventArgs e)
        {
            listBox1.Visible = true;
            textBox1.Visible = false; 

            listBox1.Items.Clear();  
 
            graph.PrintAdjacencyMatrix();

            graph.PrintDistanceMatrix_FU();
             
            foreach (var item in graph.ListInfo)
            { 
                listBox1.Items.Add(item); 
            } 
             
        }     
        private void ButtonSCC_Click(object sender, EventArgs e)
        {

            textBox1.Visible = true; 
            listBox1.Visible = false;
             
            textBox1.Text = graph.SCCToStr(); 
        }

        private void ButtonMP_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear(); 

            listBox1.Visible = true; 
            textBox1.Visible = false;

            graph.MinPathInAcyclicGraph(0);

            foreach (var item in graph.ListInfo)
            { 
                listBox1.Items.Add(item);
            } 
        }
    }   
}   
