using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Algorithms_Library;
using DekstraAlgoritm;
using Labs;
using BFS;


namespace GraphicInterface
{
    public partial class DrawGraphForm : Form 
    { 
        DrawGraph G;
        /// <summary>
        /// Лист с кооринатмаи вершин
        /// </summary>
        List<Vertex> V;
        /// <summary>
        /// Лист ребер
        /// </summary> 
        List<Edgee> E; 

        int selected1; //выбранные вершины, для соединения линиями
        int selected2;

        public DrawGraphForm()
        {
            InitializeComponent();
            V = new List<Vertex>();
            G = new DrawGraph(sheet.Width, sheet.Height);
            E = new List<Edgee>();
            sheet.Image = G.GetBitmap();

        }
        

        //кнопка - рисовать вершину
        private void drawVertexButton_Click(object sender, EventArgs e)
        {
            // делаем доступным выбор алгоритмов 
            comboBox1.Enabled = true;
            comboBox1.SelectedIndex = 0;

            drawVertexButton.Enabled = false;
            
            drawEdgeButton.Enabled = true;
            deleteButton.Enabled = true;
            G.clearSheet();
            G.drawALLGraph(V, E);
            sheet.Image = G.GetBitmap();
        }

        //кнопка - рисовать ребро
        private void drawEdgeButton_Click(object sender, EventArgs e)
        {
            drawEdgeButton.Enabled = false;
            
            drawVertexButton.Enabled = true;
            deleteButton.Enabled = true;
            G.clearSheet();
            G.drawALLGraph(V, E);
            sheet.Image = G.GetBitmap();
            selected1 = -1;
            selected2 = -1;
        }

        //кнопка - удалить элемент
        private void deleteButton_Click(object sender, EventArgs e)
        {
            deleteButton.Enabled = false;
           
            drawVertexButton.Enabled = true;
            drawEdgeButton.Enabled = true;
            G.clearSheet();
            G.drawALLGraph(V, E);
            sheet.Image = G.GetBitmap();
        }

        //кнопка - удалить граф
        private void deleteALLButton_Click(object sender, EventArgs e)
        {
            
            drawVertexButton.Enabled = true;
            drawEdgeButton.Enabled = true;
            deleteButton.Enabled = true;
            const string message = "Вы действительно хотите полностью удалить граф?";
            const string caption = "Удаление";
            var MBSave = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (MBSave == DialogResult.Yes)
            {
                V.Clear();
                E.Clear();
                G.clearSheet();
                sheet.Image = G.GetBitmap();
            }
        }

        private void sheet_MouseClick(object sender, MouseEventArgs e)
        {
           
            //нажата кнопка "рисовать вершину"
            if (drawVertexButton.Enabled == false)
            {
                V.Add(new Vertex(e.X, e.Y));
                G.drawVertex(e.X, e.Y, (V.Count - 1).ToString());
                sheet.Image = G.GetBitmap();
            }
            //нажата кнопка "рисовать ребро"
            if (drawEdgeButton.Enabled == false)
            {
                try
                {

                    if (e.Button == MouseButtons.Left)
                    {
                        for (int i = 0; i < V.Count; i++)
                        {
                            if (Math.Pow((V[i].x - e.X), 2) + Math.Pow((V[i].y - e.Y), 2) <= G.R * G.R)
                            {
                                if (selected1 == -1)
                                {
                                    G.drawSelectedVertex(V[i].x, V[i].y);
                                    selected1 = i;
                                    sheet.Image = G.GetBitmap();
                                    break;
                                }
                                if (selected2 == -1)
                                {
                                    G.drawSelectedVertex(V[i].x, V[i].y);
                                    selected2 = i;
                                    int weigth = Convert.ToInt32(Microsoft.VisualBasic.Interaction.InputBox("Введите вес графа"));
                                    E.Add(new Edgee(selected1, selected2, weigth));
                                    G.drawEdge(V[selected1], V[selected2], E[E.Count - 1], E.Count - 1);
                                    selected1 = -1;
                                    selected2 = -1;
                                    sheet.Image = G.GetBitmap();
                                    break;
                                }
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    
                }
                if (e.Button == MouseButtons.Right)
                {
                    if ((selected1 != -1) &&
                        (Math.Pow((V[selected1].x - e.X), 2) + Math.Pow((V[selected1].y - e.Y), 2) <= G.R * G.R))
                    {
                        G.drawVertex(V[selected1].x, V[selected1].y, (selected1).ToString());
                        selected1 = -1;
                        sheet.Image = G.GetBitmap();
                    }
                }
            }
            //нажата кнопка "удалить элемент"
            if (deleteButton.Enabled == false)
            {
                bool flag = false; //удалили ли что-нибудь по ЭТОМУ клику
                //ищем, возможно была нажата вершина
                for (int i = 0; i < V.Count; i++)
                {
                    if (Math.Pow((V[i].x - e.X), 2) + Math.Pow((V[i].y - e.Y), 2) <= G.R * G.R)
                    {
                        for (int j = 0; j < E.Count; j++)
                        {
                            if ((E[j].v1 == i) || (E[j].v2 == i))
                            {
                                E.RemoveAt(j);
                                j--;
                            }
                            else
                            {
                                if (E[j].v1 > i) E[j].v1--;
                                if (E[j].v2 > i) E[j].v2--;
                            }
                        }
                        V.RemoveAt(i);
                        flag = true;
                        break;
                    }
                }
                //ищем, возможно было нажато ребро
                if (!flag)
                {
                    for (int i = 0; i < E.Count; i++)
                    {
                        if (E[i].v1 == E[i].v2) //если это петля
                        {
                            if ((Math.Pow((V[E[i].v1].x - G.R - e.X), 2) + Math.Pow((V[E[i].v1].y - G.R - e.Y), 2) <= ((G.R + 2) * (G.R + 2))) &&
                                (Math.Pow((V[E[i].v1].x - G.R - e.X), 2) + Math.Pow((V[E[i].v1].y - G.R - e.Y), 2) >= ((G.R - 2) * (G.R - 2))))
                            {
                                E.RemoveAt(i);
                                flag = true;
                                break;
                            }
                        }
                        else //не петля
                        {
                            if (((e.X - V[E[i].v1].x) * (V[E[i].v2].y - V[E[i].v1].y) / (V[E[i].v2].x - V[E[i].v1].x) + V[E[i].v1].y) <= (e.Y + 4) &&
                                ((e.X - V[E[i].v1].x) * (V[E[i].v2].y - V[E[i].v1].y) / (V[E[i].v2].x - V[E[i].v1].x) + V[E[i].v1].y) >= (e.Y - 4))
                            {
                                if ((V[E[i].v1].x <= V[E[i].v2].x && V[E[i].v1].x <= e.X && e.X <= V[E[i].v2].x) ||
                                    (V[E[i].v1].x >= V[E[i].v2].x && V[E[i].v1].x >= e.X && e.X >= V[E[i].v2].x))
                                {
                                    E.RemoveAt(i);
                                    flag = true;
                                    break;
                                }
                            }
                        }
                    }
                }

                //если что-то было удалено, то обновляем граф на экране
                if (flag)
                {
                    G.clearSheet();
                    G.drawALLGraph(V, E);
                    sheet.Image = G.GetBitmap();
                }
            }
        }

        /// <summary>
        /// Лист ответа прима
        /// </summary>
        List<Edge_Prim> MST = new List<Edge_Prim>();
        private void buttonPrim_Click(object sender, EventArgs e)
        {
            List<Edge_Prim> ListPrim = new List<Edge_Prim>();
            foreach (var item in E)
            {
                ListPrim.Add(new Edge_Prim(item.v1, item.v2, item.weight));
            }
            
            Prim p = new Prim();
            p.algorithmByPrim(V.Count, ListPrim, MST);

           

        }

        private List<Edgee> ListAnswerKruskal = new List<Edgee>();
        private void buttonKruskal_Click(object sender, EventArgs e)
        {
            List<Edge> ListKruskal = new List<Edge>();
            foreach (var item in E)
            {
              
              ListKruskal.Add(new Edge(item.v1, item.v2, item.weight));
                
            }
            Kruskal k = new Kruskal(ListKruskal, V.Count, ListKruskal.Count);
            k.BuildSpanningTree();

           
            for (int i = 1; i < E.Count; i++)
            {
                if (k.tree[i, 1] != k.tree[i, 2])
                {
                    ListAnswerKruskal.Add(new Edgee(k.tree[i, 1], k.tree[i, 2], k.tree[i, 3]));
                }
            }

            

        }

        List<Edgee> ListAnswerBr = new List<Edgee>();
        private void buttonBoruvka_Click(object sender, EventArgs e)
        {
            List<Edge_Boruvka> ListBoruvka = new List<Edge_Boruvka>();
            foreach (var item in E)
            {
                ListBoruvka.Add(new Edge_Boruvka(item.v1, item.v2, item.weight));
            }
            Boruvka br = new Boruvka(ListBoruvka, V.Count, ListBoruvka.Count);
            br.boruvkaMST();

           
            foreach (var item in br.MST)
            {
                ListAnswerBr.Add(new Edgee(item.src, item.dest, (int)item.weight));
            }

            


        }


        /// <summary>
        /// Prim
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            List<Edgee> ListAnswerPrim = new List<Edgee>();
            if (MST.Count > 0)
            {
                ListAnswerPrim.Add(new Edgee(MST[0].v1, MST[0].v2, MST[0].weight));
                MST.RemoveAt(0);
            }
            else
            {
                MessageBox.Show("Решение найдено");
            }

            G.drawALLGraphAnswer(V, ListAnswerPrim);
            sheet.Image = G.GetBitmap();
        }

        /// <summary>
        /// Kruskal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {

            List<Edgee> ListAnswerKruskal2 = new List<Edgee>();
            if(ListAnswerKruskal.Count > 0)
            {
                ListAnswerKruskal2.Add(new Edgee(ListAnswerKruskal[0].v1, ListAnswerKruskal[0].v2, ListAnswerKruskal[0].weight));
                ListAnswerKruskal.RemoveAt(0);
            }
            else
            {
                MessageBox.Show("Решение найдено");
            }

            G.drawALLGraphAnswer(V, ListAnswerKruskal2);
            sheet.Image = G.GetBitmap();
        }

 
        private void button4_Click(object sender, EventArgs e)
        {
            List<Edgee> ListAnswerBr2 = new List<Edgee>();
            if(ListAnswerBr.Count>0)
            {
                ListAnswerBr2.Add(new Edgee(ListAnswerBr[0].v1, ListAnswerBr[0].v2, ListAnswerBr[0].weight));
                ListAnswerBr.RemoveAt(0);
            }
            else
            {
                MessageBox.Show("Решение найдено");
            }
            G.drawALLGraphAnswer(V, ListAnswerBr2);
            sheet.Image = G.GetBitmap();
        }

        private void AllPanelClose()
        { 
            panelKruskal.Visible = false; 
            panelPrim.Visible = false;
            panelBF.Visible = false;
            panelDFS.Visible = false; 
            panelCycles.Visible = false;
            panelDijktra.Visible = false;
            panelFU.Visible = false;
            panelSCC.Visible = false;
            panelBFS.Visible = false;
            panelMP.Visible = false;

              
              
        }    
          
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            AllPanelClose(); //закрываем все панели с кнопками для алгоритмов
            listBox1.Items.Clear(); //очищаем лист с ин-цией 

            // показываем панель управления в зависимости от выбранного варианта 
            switch (comboBox1.SelectedIndex)
            {
                case 0: 
                    panelKruskal.Show(); 
                    break;  
                case 1: 
                    panelPrim.Show();
                    break;
                case 2: 
                    panelBF.Show(); 
                    break;
                case 3:
                    panelFU.Show();   
                    break; 
                case 4: 
                    panelDFS.Show();
                    break;
                case 5: 
                    panelCycles.Show(); 
                    break;
                case 6:
                    panelDijktra.Show();
                    break;
                case 7: 
                    panelSCC.Show();
                    break;
                case 8:
                    panelBFS.Show();
                    break;
                case 9:
                    panelMP.Show();
                    break;
            }  
                 
              
        } 
         
        private void ButtonBF_Click(object sender, EventArgs e)
        {
            GraphBF graph = new GraphBF(V.Count,E.Count); //создаем граф для алгоритма Беллмана-Форда 

            //Переносим список ребер из отрисованного графа в граф для Беллмана-Форда 
            int i = 0; 
            foreach (var item in E)
            { 
                graph.edge[i].src = item.v1 ;
                graph.edge[i].dest = item.v2;
                graph.edge[i].weight = item.weight;
                i++;  
            }  

            graph.BellmanFord(graph,0); //выполняем алгоритм  

            // выводим ответ в листбокс 
            foreach (var item in graph.ListInfo)
            {
                listBox1.Items.Add(item);
            }  


                
        } 

        private void ButtonDFS_Click(object sender, EventArgs e)
        {
            GraphBF graph = new GraphBF(V.Count, E.Count); //создаем граф для алгоритма поиска в глубину 

            //Переносим список ребер из отрисованного графа в граф для поиска в глубину 
            int i = 0;
            foreach (var item in E)
            {
                graph.edge[i].src = item.v1; 
                graph.edge[i].dest = item.v2;
                graph.edge[i].weight = item.weight;
                i++; 
            }

            graph.doDFS(); //выполняем алгоритм  
            
            // выводим ответ в листбокс   
            foreach (var item in graph.ListInfo)
            {
                listBox1.Items.Add(item);
            } 
        }

          
        private void ButtonEuler_Click(object sender, EventArgs e)
        {
            bool HasCycle = false;

            int[,] matrix = new int[V.Count, V.Count]; 
             
            for (int i = 0; i < V.Count; i++) 
                for (int j = 0; j < V.Count; j++)
                    matrix[i, j] = 0; 
            for (int i = 0; i < E.Count; i++) 
            { 
                matrix[E[i].v1, E[i].v2] = E[i].weight;
                matrix[E[i].v2, E[i].v1] = E[i].weight;
            }   
              
            HasCycle = Cycles.Euler_cycle(matrix);  
             
            if (HasCycle)
                listBox1.Items.Add("В графе содержится Эйлеров цикл"); 
            else
            {
                listBox1.Items.Add("В графе не содержится Эйлеров цикл");
            }
        } 

        private void ButtonGamilton_Click(object sender, EventArgs e)
        {
            int[] mass; 

            int[,] matrix = new int[V.Count, V.Count];

            for (int i = 0; i < V.Count; i++)
                for (int j = 0; j < V.Count; j++)
                    matrix[i, j] = 0;
            for (int i = 0; i < E.Count; i++)
            {
                matrix[E[i].v1, E[i].v2] = E[i].weight;
                matrix[E[i].v2, E[i].v1] = E[i].weight; 
            } 

            bool flag = Cycles.HamCycle(matrix, matrix.GetLength(1), out mass);
            if (flag)
            { 
                listBox1.Items.Add("Путь: " + (char)13);
                for (int i = 0; i < matrix.GetLength(1); i++)
                    listBox1.Items.Add(mass[i] + "  "); 
            }
            else listBox1.Items.Add("Гамильтонов цикл в данном случае невозможен");

        }
        /**/
        /// <summary>
        /// Метод для нахождения смежных ребер входяшей вершины
        /// </summary>
        /// <param name="vertice">Текушая вершина</param>
        /// <param name="edges">Лист ребер</param>
        /// <returns></returns>
        private List<Edgee> Get_Adjacent_Vertices(int vertice)
        {
            List<Edgee> Adjacent_Vertices = new List<Edgee>();

            for (int i = 0; i < E.Count; i++)
            {
                if (E != null)
                {
                    if ((E[i].v1 == vertice) || (E[i].v2 == vertice))
                    {
                        Adjacent_Vertices.Add(E[i]);
                        E.Remove(E[i]);
                    }
                }
                
            }
            /*
            foreach (var item in E)
            {
                if (item != null)
                    if ((item.v1 == vertice) || (item.v2 == vertice))
                    {
                        Adjacent_Vertices.Add(item);
                        E.Remove(item);
                    }
            }
            */
            return Adjacent_Vertices;

        }
        

        private void ButtonDijkstra_Click(object sender, EventArgs e)
        { 
            /**/
            //делай тута, библа в проекте PS Это был адд
            DekstraAlgoritm.Point[] v = new DekstraAlgoritm.Point[V.Count];
            v[0] = new DekstraAlgoritm.Point(0, false, "0");
            for (int i = 1; i < V.Count; i++)
            {
                v[i] = new DekstraAlgoritm.Point(9999, false, Convert.ToString(i));

            }
           List<Rebro> rebras = new List<Rebro>();
           
           for (int i = 0; E.Count > 0; i++)
            {
                
                List<Edgee> Adjacent_Vertices = Get_Adjacent_Vertices(Convert.ToInt32(v[i].Name));
                while( Adjacent_Vertices.Count > 0)
                {
                    DekstraAlgoritm.Point temp1 = null , temp2  = null;
                    for (int f = 0; f < v.Length; f++)
                    {
                        if (Adjacent_Vertices[0].v1 == Convert.ToInt32(v[f].Name))
                        {
                            temp1 = v[f];

                        }
                        if (Adjacent_Vertices[0].v2 == Convert.ToInt32(v[f].Name))
                        {
                            temp2 = v[f];
                        }


                    }
                    rebras.Add (new Rebro(temp1, temp2,Adjacent_Vertices[0].weight));
                    Adjacent_Vertices.RemoveAt(0);
                    
                   
                }

            }

            DekstraAlgorim da = new DekstraAlgorim(v, rebras.ToArray());
            da.AlgoritmRun();
            //Тут почему то предок точки нулл , хотя в консольке все ок 
            List<string> b = PrintGrath.PrintAllMinPaths(da);//ошибка с печатью потом пофикшу
            for (int i = 0; i < b.Count; i++)                                 // b.Count меняешь на цифру до которого поинта считать (конец)
                listBox1.Items.Add(b[i]);
                

        }

        private void ButtonFU_Click(object sender, EventArgs e)
        {
            FormFU form = new FormFU();
            form.Show(); 
        }

        private void ButtonSCC_Click(object sender, EventArgs e)
        {
            FormFU form = new FormFU();
            form.Show();
        }

        private void BFS_button_Click(object sender, EventArgs e)
        {
            BFSS bfs = new BFSS(V.Count);
            foreach (var item in E)
            {
                bfs.addEdge(item.v1, item.v2);
            }
            bfs.doBFS(); 
            foreach (var item in bfs.Answer) 
            {
                listBox1.Items.Add(item); 
            }
            
        }

        private void ButtonMP_Click(object sender, EventArgs e)
        {
            FormFU form = new FormFU();
            form.Show();
        }

        private void PanelDFS_Paint(object sender, PaintEventArgs e)
        {

        }
    }   
} 
 