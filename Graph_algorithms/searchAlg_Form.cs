using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Graph_algorithms
{
    public partial class SearchAlg_Form : Form
    {
        public SearchAlg_Form(Main_form parent)
        {
            InitializeComponent();
            start = null;
            goal = null;
            main_form = parent;
        }
        Graph.Node start;
        Graph.Node goal;
        Main_form main_form;

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                start = main_form.graph.nodes.Find(node => node.name == Convert.ToInt32(tbStart.Text));
                goal = main_form.graph.nodes.Find(node => node.name == Convert.ToInt32(tbGoal.Text));
                if ((start == null) || (goal == null))
                    throw new FormatException();
                Close();
                    main_form.graph.doAlgorithm(new Graph.Algorithm.BFS(main_form.graph,start,goal));
            }
            catch (FormatException)
            {
                MessageBox.Show("Невірно введені дані!",
                                "Помилка!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
}
