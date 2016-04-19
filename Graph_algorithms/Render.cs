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
    class Render
    {
        public Render(ref SimpleOpenGlControl openGL)
        {
            graphics = openGL;
            graphics.InitializeContexts();
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_SINGLE | Glut.GLUT_DEPTH);
            Gl.glClearColor(1, 1, 1, 1);
            Gl.glViewport(0, 0, graphics.Width, graphics.Height);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluOrtho2D(0.0, graphics.Width, graphics.Height, 0.0);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            circles = new List<Point>();
            highlights = new List<Point>();
            texts = new List<Text>();
            arcs = new List<Arc>();
        }

        public struct Arc
        {
            public int x1, y1, x2, y2;
            public Arc(int x1,int y1,int x2,int y2)
            {
                this.x1 = x1;
                this.x2 = x2;
                this.y1 = y1;
                this.y2 = y2;
            }
        }

        public struct Text
        {
            private static int i = 1;
            public string text;
            public int x, y;
            public Text(int x, int y)
            {
                this.x = x;
                this.y = y;
                text = i.ToString();
                i++;
            }
        }

        private SimpleOpenGlControl graphics;
        public List<Point> circles { get; private set; }
        public List<Point> highlights { get; private set; }
        public List<Arc> arcs { get; private set; }
        public List<Text> texts { get; private set; }

        private void drawCircle(Point c)
        {
            const int R = 15;
            const int SEGMENTS = 100;
            const float PI = 3.1415926f;
            Gl.glLoadIdentity();
            Gl.glColor3f(0.0f, 0.0f, 0.0f);
            Gl.glBegin(Gl.GL_TRIANGLE_FAN);
            Gl.glVertex2d(c.X, c.Y);
            for (int i = 0; i <= SEGMENTS; i++)
            {
                float a = (float)i / (float)SEGMENTS * PI * 2.0f;
                float x = (float)(R * Math.Cos(a));
                float y = (float)(R * Math.Sin(a));
                Gl.glVertex2d(x+c.X, y+c.Y);
            }
            Gl.glEnd();
        }

        private void drawArc(Arc arc)
        {
            Gl.glLoadIdentity();
            Gl.glBegin(Gl.GL_LINES);
            Gl.glPushMatrix();
            Gl.glTranslated(0,0,-1);
            Gl.glColor3f(0.0f, 0.0f, 0.0f);
            Gl.glVertex2d(arc.x1, arc.y1);
            Gl.glVertex2d(arc.x2, arc.y2);
            Gl.glPopMatrix();
            Gl.glEnd();
        }

        private void drawText(Text txt)
        {
            Gl.glLoadIdentity();
            Gl.glPushMatrix();
            Gl.glTranslated(0, 0, 1);
            Gl.glColor3f(0.0f, 1.0f, 0.0f);
            Gl.glRasterPos2d(txt.x-5,txt.y+5);
            Glut.glutBitmapString(Glut.GLUT_BITMAP_9_BY_15, txt.text);
            Gl.glPopMatrix();
        }

        private void highlight(Point point)
        {
            Gl.glLoadIdentity();
            Gl.glColor3f(1.0f, 0, 0);
            
        }

        public void drawAll()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            foreach (Point circle in circles)
                drawCircle(circle);
            foreach (Arc arc in arcs)
                drawArc(arc);
            foreach (Text txt in texts)
                drawText(txt);
            foreach (Point hl in highlights)
                highlight(hl);

            Gl.glFlush();
            graphics.Invalidate();
        }
    }
}
