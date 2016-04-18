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
        private static int x1, y1;
        private static bool switcher = false;

        private void bClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void graphics_MouseClick(object sender, MouseEventArgs e)
        {
            //render.drawText("123", e.X, e.Y);
            if (!switcher)
            {
                x1 = e.X;
                y1 = e.Y;
                switcher = true;
            }
            else
            {
                render.drawArc(x1, y1, e.X, e.Y);
                switcher = false;
            }
        }
    }
}
