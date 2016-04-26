using System;
using System.Windows.Forms;

namespace Graph_algorithms
{
    public partial class Main_form : Form
    {
        public Main_form()
        {
            InitializeComponent();
            graph = new Graph(ref graphics);
        }
        private bool switcher = false;
        private SearchAlg_Form searchAlg_form;
        public Graph graph;
        public static double weight { get; private set; }
        

        private void bClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tDrawing_Tick(object sender, EventArgs e)
        {
            graph.drawAll();
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            graph.clearAll();
            switcher = false;
        }


        private void graphics_MouseClick(object sender, MouseEventArgs e)
        {

            if (!graph.highlightNode(e.X, e.Y))
                if (!switcher)
                {
                    graph.addNode(e.X, e.Y);
                    if (!graph.connect(e.X, e.Y))
                        switcher = true;
                }
                else
                {
                    var node = new Graph.Node(e.X, e.Y);
                    graph.addNode(node);
                    graph.connect(node, weight);
                    switcher = false;
                }
            else
                switcher = false;
        }

        private void tbWeight_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (tbWeight.Text == "")
                    weight = 0;
                else
                    weight = Convert.ToDouble(tbWeight.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Неправильно введена вага!","Помилка!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void bHclear_Click(object sender, EventArgs e)
        {
            graph.deleteHighlights();
        }

        private void WideSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            searchAlg_form = new SearchAlg_Form(this,(int)algorithms.BFS);
            searchAlg_form.ShowDialog();
        }

        private void Main_form_Shown(object sender, EventArgs e)
        {
            MessageBox.Show("Ласкаво просимо до системи моделювання графових алгоритмів!\n"
                           +"Інструкції для роботи з системою:\n"
                           +"Спочатку створіть граф: натискання мишею на білому полі створює вершину.\n"
                           +"Натискання другий раз після створення вершини на білому полі створює другу "
                           +"вершину, та з'єднує її з першою.\n"
                           +"Натискання на вершину виділяє її \n"
                           +"Натискання на білому полі при виділеній "
                           +"вершині створює другу вершину, та з'єднує її з виділеною.\n"
                           + "Послідовне натиснення на дві вершини з'єднує їх.\n"
                           + "Для виконання алгоритму, виберіть потрібний алгоритм з меню та слідуйте "
                           +"інструкціям\n"
                           + "Не забудьте вводити ваги ребер графа! (поле у правому верхньому кутку)\n",
                            "Ласкаво просимо!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        private void DeepSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            searchAlg_form = new SearchAlg_Form(this, (int)algorithms.DFS);
            searchAlg_form.ShowDialog();
        }

        private void CruscalsAlgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            graph.doAlgorithm(new Graph.Algorithm.Kruskal(graph));
        }

        private void PrimsAlgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            graph.doAlgorithm(new Graph.Algorithm.Prim(graph));
        }
    }
}
