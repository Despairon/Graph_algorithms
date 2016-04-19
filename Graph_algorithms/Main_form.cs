using System;
using System.Collections.Generic;
using System.Text;
using Tao.OpenGl;
using Tao.FreeGlut;
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
            render = new Render(ref graphics);
        }
        Render render;
        private static int x1, y1;
        private static bool switcher = false;

        private void bClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tDrawing_Tick(object sender, EventArgs e)
        {
            render.drawAll();
        }

        private void graphics_MouseClick(object sender, MouseEventArgs e)
        {
            if (!switcher)
            {
                render.circles.Add(new Point(e.X, e.Y));
                render.texts.Add(new Render.Text(e.X, e.Y));
                x1 = e.X;
                y1 = e.Y;
                switcher = true;
            }
            else
            {
                render.circles.Add(new Point(e.X, e.Y));
                render.texts.Add(new Render.Text(e.X, e.Y));
                render.arcs.Add(new Render.Arc(x1, y1, e.X, e.Y));
                switcher = false;
            }
        }
    }
}
