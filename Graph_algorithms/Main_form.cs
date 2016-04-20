using System;
using Tao.Platform.Windows;
using System.Windows.Forms;
using System.Drawing;

namespace Graph_algorithms
{
    public partial class Main_form : Form
    {
        public Main_form()
        {
            InitializeComponent();
            graph = new Graph(ref graphics);
        }
        Graph graph;
        private bool switcher = false;
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
                    Graph.Node node = new Graph.Node(e.X, e.Y);
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
    }
}
