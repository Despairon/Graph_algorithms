using System;
using System.Collections.Generic;
using System.Text;
using Tao.OpenGl;
using Tao.FreeGlut;
using Tao.Platform.Windows;
using System.Windows.Forms;

namespace Graph_algorithms
{
    public partial class Main_form : Form
    {
        public Main_form()
        {
            InitializeComponent();
            render = new Render(ref graphics);
        }
        Render render;

        private void bClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            render.drawCircle(0, 0);
        }
    }
}
