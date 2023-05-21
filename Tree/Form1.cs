using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;

namespace LB14_3
{
    public partial class Form1 : Form
    {

        System.Drawing.Drawing2D.GraphicsPath myPath;

        BinaryTree<int> tree;
        const int WIDTH = 30;
        const int HEIGHT = 30;

        List<Point> pointList = new List<Point>(0);
        List<int> dataList = new List<int>(0);
        public Form1()
        {
            myPath = new System.Drawing.Drawing2D.GraphicsPath();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
        }

        private void Button1_Click(object sender, EventArgs e) // 5 4 3 7 6 28
        {
            try
            {
                int level = 0;
                string[] sNums = textBox1.Text.Split(' ');
                tree = new BinaryTree<int>(Convert.ToInt32(sNums[0]), level);
                for (int i = 1; i < sNums.Length; i++)
                    tree.addnode(Convert.ToInt32(sNums[i]), level);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (tree != null)
                {
                    string[] sNums = textBox1.Text.Split(' ');
                    int level = 0;
                    for (int i = 0; i < sNums.Length; i++)
                        tree.addnode(Convert.ToInt32(sNums[i]), level);
                }
                else
                    throw new NullReferenceException();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }


        }

        private void Button3_Click(object sender, EventArgs e) // вывод дерева
        {
            pointList.Clear();
            dataList.Clear();
            pushNodesInList(tree.Getroot, pointList, dataList);
            myPath.Reset(); // очищаем путь
            DisplayTree(); // заполняем путь
            CheckForScroll(tree.Getroot); // увеличиваем панель если превосходит изначально
            panel1.BackColor = Color.Black;
            panel1.Region = new Region(myPath); // заполняем панель

        }

        /// <summary>
        /// Вывод дерева
        /// </summary>
        /// <param name="root"> корень дерева</param>
        /// <param name="pointList">точки каждого элемента</param>
        /// <param name="datalist">значение каждого элемента</param>
        private void pushNodesInList(BinaryTree<int>.Node<int> root, List<Point> pointList, List<int> datalist) // заполняем листы для вывода
        {
            if (root.Left != null)
            {
                pushNodesInList(root.Left, pointList, datalist);
            }
            root.point.X = (WIDTH + WIDTH) * pointList.Count + /*delta*/2 * WIDTH;
            root.point.Y = (HEIGHT + HEIGHT) * root.Level;
            pointList.Add(root.point);
            datalist.Add(root.Value);
            if (root.Right != null)
                pushNodesInList(root.Right, pointList, datalist);
        }

        private void CheckForScroll(BinaryTree<int>.Node<int> root) // проверка , если больше то расширяем окно
        {
            int treePanelCurrentWidth = panel1.Width;
            if (root.Right != null)
                CheckForScroll(root.Right);
            if (root.Right == null && root.point.X > treePanelCurrentWidth)
                panel1.Width = root.point.X + WIDTH;
            int treePanelCurrentHeight = panel1.Height;

        }
        public void DisplayTree() // заполнение графики
        {

            for (int i = 0; i < pointList.Count; i++)
            {
                string s = Convert.ToString(dataList[i]);

                myPath.AddEllipse(pointList[i].X, pointList[i].Y, WIDTH + 5, HEIGHT + 5);
                if (dataList[i] > 9 || dataList[i] < -9)
                    myPath.AddString(s, new FontFamily("Arial"), (int)FontStyle.Bold, 15, new Point(pointList[i].X + 5, pointList[i].Y + 8), StringFormat.GenericDefault);
                else
                    myPath.AddString(s, new FontFamily("Arial"), (int)FontStyle.Bold, 15, new Point(pointList[i].X + 10, pointList[i].Y + 8), StringFormat.GenericDefault);

            }
          //DisplayTree_Line();
        }
     /*   public void DisplayTree_Line() // заполнение графики
        {

            BinaryTree<int>.Node<int> root2 = tree.Getroot;
            for(int i=0;i<tree.Count;i++)
            {
                if(root2.Right!=null)
                {
                    root2.Right.point.X += 40;
                    root2.Right.point.Y += 50;
                    myPath.AddLine(root2.point, root2.Right.point);
                }
                    
                if(root2.Left!=null)
                    myPath.AddLine(root2.point, root2.Left.point);
                if(root2.Left!=null)
                {
                    root2 = root2.Left;
                }
             
            }
        }*/
        /// Конец вывода дерева

        private void Button4_Click(object sender, EventArgs e)//сумму элементов, расположенных на максимальном уровне от корня
        {
            int maxlevel = 0;
            tree.maxLevel(tree.Getroot, ref maxlevel);

            int sum = 0;
            sum = tree.sumMaxLevel_fromRoot(tree.Getroot, maxlevel);
            textBox1.Clear();
            textBox1.Text = " Summa = " + sum.ToString();
        }

        private void Button5_Click(object sender, EventArgs e)//Обнулить все совершенные листья дерева, большие разности максимального и минимального значения элементов дерева
        {
            label1.Text = "min element  : " + Convert.ToInt32(tree.minElem);
            label2.Text = "max element  : " + Convert.ToInt32(tree.maxElem);
            tree.zeroing_of_perfect_leaves(tree.Getroot);
            StreamWriter file = new StreamWriter("tree.res");
            tree.printTree_direct(file, tree.Getroot);
            file.Close();
            label3.Text = " Файл сохранен (прямой обход)";
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            try
            {
                tree.cleartree();
                FileInfo file = new FileInfo("tree.res");
                if (!file.Exists)
                {
                    throw new Exception("Файл не существует");
                }
                else
                    label4.Text = "Файл: существует";

                StreamReader file_tree = file.OpenText();
                string number;
                int level = 0;
                number = file_tree.ReadLine();
                if (number == null)
                {
                    throw new Exception("Файл пуст");
                }
                tree = new BinaryTree<int>(Convert.ToInt32(number), level);
                do
                {
                    number = file_tree.ReadLine();
                    if (number == null) break;
                    tree.addnode(Convert.ToInt32(number), level);

                } while (true);
                file_tree.Close();

                if (tree.checkTree(tree.Getroot) == true)
                {
                    label5.Text = " Данные сохраненые в файле - дерево";
                }
                else
                    label5.Text = " Данные сохраненые в файле - не дерево";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }
    }
}




