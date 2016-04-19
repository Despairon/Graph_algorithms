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

        private void bClear_Click(object sender, EventArgs e)
        {
            render.clearAll();
            switcher = false;
        }

        private void graphics_MouseClick(object sender, MouseEventArgs e)
        {
            if (render.checkBoundsEnter(new Point(e.X, e.Y)))
            {
                render.clearAllHighlights();
                render.geometrics.Add(Render.highlightedCircle);
            }
            else
                if (!switcher)
                {
                    Rectangle bounds = new Rectangle(e.X - 15, e.Y - 15, 30, 30);
                    render.geometrics.Add(new Render.Circle(e.X, e.Y, bounds));
                    render.geometrics.Add(new Render.Text(e.X, e.Y));
                    x1 = e.X;
                    y1 = e.Y;
                    switcher = true;
                }
                else
                {
                    Rectangle bounds = new Rectangle(e.X - 15, e.Y - 15, 30, 30);
                    render.geometrics.Add(new Render.Circle(e.X, e.Y, bounds));
                    render.geometrics.Add(new Render.Text(e.X, e.Y));
                    render.geometrics.Add(new Render.Arc(x1, y1, e.X, e.Y));
                    switcher = false;
                }
        }
    }
}
