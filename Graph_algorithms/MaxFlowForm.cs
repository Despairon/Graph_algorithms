using System;
using System.Windows.Forms;

namespace Graph_algorithms
{
    public partial class MaxFlowForm : Form
    {
        public MaxFlowForm(Main_form parent)
        {
            InitializeComponent();
            main_form = parent;
        }
        private Graph.Node source;
        private Graph.Node drain;
        private Main_form main_form;

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                source = main_form.graph.nodes.Find(node => node.name == Convert.ToInt32(tbStart.Text));
                drain = main_form.graph.nodes.Find(node => node.name == Convert.ToInt32(tbGoal.Text));
                if ((source == null) || (drain == null))
                    throw new FormatException();
                Close();
                main_form.graph.doAlgorithm(new Graph.Algorithm.MaxFlow(main_form.graph,source,drain));
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
