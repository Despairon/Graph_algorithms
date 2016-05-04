﻿using System;
using System.Windows.Forms;

namespace Graph_algorithms
{
    public partial class MinRoutesForm : Form
    {
        public MinRoutesForm(Main_form parent, int algorithm)
        {
            InitializeComponent();
            start = null;
            goal = null;
            main_form = parent;
            this.algorithm = algorithm;
        }
        Graph.Node start;
        Graph.Node goal;
        Main_form main_form;
        int algorithm;

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
                switch (algorithm)
                {
                    case (int)algorithms.DIJKSTRAS:
                        main_form.graph.doAlgorithm(new Graph.Algorithm.Dijkstras(main_form.graph, start, goal));
                        break;
                }
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