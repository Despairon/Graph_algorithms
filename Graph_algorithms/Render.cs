using System;
using System.Collections.Generic;
using Tao.OpenGl;
using Tao.FreeGlut;
using Tao.Platform.Windows;
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

            geometrics = new List<Shape>();
        }
        private SimpleOpenGlControl graphics;
        private List<Shape> geometrics;
        public Highlight highlightedNode { get; private set; }

        public class Shape
        {
            public Shape (int x, int y)
            {
                this.x = x;
                this.y = y;
            }
            public int x { get;}
            public int y { get;}
        }

        public class Arc : Shape
        {
            public Arc(int x, int y, int x1, int y1) : base(x,y)
            {
                this.x1 = x1;
                this.y1 = y1;
            }
            public int x1 { get;}
            public int y1 { get;}
        }

        public class Text : Shape
        {
            public Text(int x, int y) : base(x,y)
            {
                text = i.ToString();
                i++;
            }
            public Text(int x, int y,string text) : base(x, y)
            {
                this.text = text;
            }
            public string text { get;}
            private static int i = 1;

            public static void clear()
            {
                i = 1;
            } 
        }

        public class Circle : Shape
        {
            public Circle(int x, int y, Rectangle edges) : base(x,y)
            {
                this.edges = edges;
            }
            public Rectangle edges { get;}
        }

        public class Highlight : Shape
        {
            public Highlight(int x, int y) : base (x,y)
            {
            }
        }

        private void drawShape(Shape shape)
        {
            if (shape is Circle)
            {
                const int R = 15;
                const int SEGMENTS = 100;
                const float PI = 3.1415926f;
                Gl.glLoadIdentity();
                Gl.glColor3f(0.0f, 0.0f, 0.0f);
                Gl.glBegin(Gl.GL_TRIANGLE_FAN);
                Gl.glVertex2d(shape.x, shape.y);
                for (int i = 0; i <= SEGMENTS; i++)
                {
                    float a = (float)i / (float)SEGMENTS * PI * 2.0f;
                    float x = (float)(R * Math.Cos(a));
                    float y = (float)(R * Math.Sin(a));
                    Gl.glVertex2d(x + shape.x, y + shape.y);
                }
                Gl.glEnd();
            }

            if (shape is Arc)
            {
                Gl.glLoadIdentity();
                Gl.glBegin(Gl.GL_LINES);
                Gl.glPushMatrix();
                Gl.glTranslated(0, 0, -1);
                Gl.glColor3f(0.0f, 0.0f, 0.0f);
                Gl.glVertex2d(shape.x, shape.y);
                Gl.glVertex2d((shape as Arc).x1, (shape as Arc).y1);
                Gl.glPopMatrix();
                Gl.glEnd();
            }

            if (shape is Text)
            {
                Gl.glLoadIdentity();
                Gl.glPushMatrix();
                Gl.glTranslated(0, 0, 1);
                Gl.glColor3f(0.0f, 1.0f, 0.0f);
                Gl.glRasterPos2d(shape.x - 8, shape.y+5);
                Glut.glutBitmapString(Glut.GLUT_BITMAP_HELVETICA_18, (shape as Text).text);
                Gl.glPopMatrix();
            }

            if (shape is Highlight)
            {
                const int R = 20;
                const int SEGMENTS = 100;
                const float PI = 3.1415926f;
                Gl.glLoadIdentity();
                Gl.glColor3f(1.0f, 0.0f, 0.0f);
                Gl.glBegin(Gl.GL_TRIANGLE_FAN);
                Gl.glVertex2d(shape.x, shape.y);
                for (int i = 0; i <= SEGMENTS; i++)
                {
                    float a = (float)i / (float)SEGMENTS * PI * 2.0f;
                    float x = (float)(R * Math.Cos(a));
                    float y = (float)(R * Math.Sin(a));
                    Gl.glVertex2d(x + shape.x, y + shape.y);
                }
                Gl.glEnd();
            }
        }

        public bool checkAreaEnter(Point pt)
        {
            foreach (Shape shape in geometrics)
                if (shape is Circle)
                    if ((pt.X >= (shape as Circle).edges.Left && pt.X <= (shape as Circle).edges.Right)
                     && (pt.Y >= (shape as Circle).edges.Top && pt.Y <= (shape as Circle).edges.Bottom))
                    {
                        highlightedNode = new Highlight(shape.x, shape.y);
                        return true;
                    }
            return false;
        }

        private void addText(int x, int y)
        {
            geometrics.Add(new Text(x, y));
        }

        private void addText(int x, int y, string text)
        {
            geometrics.Add(new Text(x, y, text));
        }

        public void addHighlight()
        {
            geometrics.Add(highlightedNode);
        }

        public void addHighlight(int x, int y)
        {
            geometrics.Add(new Highlight(x, y));
        }

        public void addArc(int x, int y, int x1, int y1, string text)
        {
            geometrics.Add(new Arc(x,y,x1,y1));
            geometrics.Add(new Text((x + x1)/2,(y + y1)/2,text));
        }

        public void addCircle(int x, int y)
        {
            Rectangle edges = new Rectangle(x - 15, y - 15, 30, 30);
            geometrics.Add(new Circle(x, y, edges));
            geometrics.Add(new Text(x, y));
        }

        public void clearAllHighlights()
        {
            for (int i = 0; i < geometrics.Count; i++)
            {
                if (geometrics[i] is Highlight)
                {
                    geometrics.RemoveAt(i);
                    i--;

                }
            }
        }

        public bool hasHighlightedNode()
        {
            if (geometrics.FindAll(shape => shape is Highlight).Count > 0)
                return true;
            return false;
        }

        public void clearAll()
        {
            geometrics.Clear();
            Text.clear();
        }

        public void drawAll()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            foreach (Shape shape in geometrics)
                drawShape(shape);

            Gl.glFlush();
            graphics.Invalidate();
        }
    }
}
