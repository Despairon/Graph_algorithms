using System;
using System.Collections.Generic;
using Tao.OpenGl;
using Tao.FreeGlut;
using Tao.Platform.Windows;
using System.Drawing;
using System.Windows.Forms;

namespace Graph_algorithms
{
    public enum colors { RED, GREEN, BLUE }
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
        public NodeHighlight pickedNode { get; private set; }

        public abstract class Shape
        {
            public Shape (int x, int y)
            {
                this.x = x;
                this.y = y;
            }
            public int x { get;}
            public int y { get;}
            public abstract void draw();
        }

        public class Arc : Shape
        {
            public Arc(int x, int y, int x1, int y1) : base(x,y)
            {
                this.x1 = x1;
                this.y1 = y1;
            }
            private int x1;
            private int y1;

            public override void draw()
            {
                Gl.glLoadIdentity();
                Gl.glBegin(Gl.GL_LINES);
                Gl.glPushMatrix();
                Gl.glTranslated(0, 0, -1);
                Gl.glColor3f(0.0f, 0.0f, 0.0f);
                Gl.glVertex2d(x, y);
                Gl.glVertex2d(x1, y1);
                Gl.glPopMatrix();
                Gl.glEnd();
            }

        }

        public class Text : Shape
        {
            public Text(int x, int y) : base(x,y)
            {
                text = i.ToString();
                i++;
                color = (int)colors.GREEN;
            }

            public Text(int x, int y,string text, int color) : base(x, y)
            {
                this.text = text;
                this.color = color;
            }
            private string text;
            private static int i = 1;
            public int color { get; }

            public static void clear()
            {
                i = 1;
            }

            public override void draw()
            {
                IntPtr font = Glut.GLUT_BITMAP_9_BY_15;
                Gl.glLoadIdentity();
                Gl.glPushMatrix();
                Gl.glTranslated(0, 0, 1);
                switch (color)
                {
                    case (int)colors.RED:
                        Gl.glColor3f(1.0f, 0.0f, 0.0f);
                        font = Glut.GLUT_BITMAP_HELVETICA_18;
                        break;
                    case (int)colors.GREEN:
                        Gl.glColor3f(0.0f, 1.0f, 0.0f);
                        break;
                    case (int)colors.BLUE:
                        Gl.glColor3f(0.0f, 0.0f, 1.0f);
                        break;
                }
                Gl.glRasterPos2d(x - 8, y + 5);
                Glut.glutBitmapString(font, text);
                Gl.glPopMatrix();
            }
        }

        public class Circle : Shape
        {
            public Circle(int x, int y, Rectangle edges) : base(x,y)
            {
                this.edges = edges;
            }
            public Rectangle edges { get;}

            public override void draw()
            {
                const int R = 15;
                const int SEGMENTS = 100;
                const float PI = 3.1415926f;
                Gl.glLoadIdentity();
                Gl.glColor3f(0.0f, 0.0f, 0.0f);
                Gl.glBegin(Gl.GL_TRIANGLE_FAN);
                Gl.glVertex2d(x, y);
                for (int i = 0; i <= SEGMENTS; i++)
                {
                    float a = (float)i / (float)SEGMENTS * PI * 2.0f;
                    float x = (float)(R * Math.Cos(a));
                    float y = (float)(R * Math.Sin(a));
                    Gl.glVertex2d(this.x + x, this.y + y);
                }
                Gl.glEnd();
            }
        }

        public class NodeHighlight : Shape
        {
            public NodeHighlight(int x, int y) : base (x,y)
            {
            }

            public override void draw()
            {
                const int R = 20;
                const int SEGMENTS = 100;
                const float PI = 3.1415926f;
                Gl.glLoadIdentity();
                Gl.glColor3f(1.0f, 0.0f, 0.0f);
                Gl.glBegin(Gl.GL_TRIANGLE_FAN);
                Gl.glVertex2d(x, y);
                for (int i = 0; i <= SEGMENTS; i++)
                {
                    float a = (float)i / (float)SEGMENTS * PI * 2.0f;
                    float x = (float)(R * Math.Cos(a));
                    float y = (float)(R * Math.Sin(a));
                    Gl.glVertex2d(this.x + x, this.y + y);
                }
                Gl.glEnd();
            }
        }

        public class ArcHighlight : Shape
        {
            public ArcHighlight(int x, int y, int x1, int y1) : base(x,y)
            {
                this.x1 = x1;
                this.y1 = y1;
            }
            private int x1;
            private int y1;

            public override void draw()
            {
                Gl.glLoadIdentity();
                Gl.glBegin(Gl.GL_QUADS);
                Gl.glPushMatrix();
                Gl.glColor3f(0.0f, 0.0f, 1.0f);
                Gl.glVertex2d(x1 + 3, y1+3);
                Gl.glVertex2d(x1 - 3, y1-3);
                Gl.glVertex2d(x - 3, y-3);
                Gl.glVertex2d(x + 3, y+3);
                Gl.glPopMatrix();
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
                        pickedNode = new NodeHighlight(shape.x, shape.y);
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
            geometrics.Add(new Text(x, y, text,(int)colors.RED));
        }

        public void addText(int x, int y, string text, int color)
        {
            geometrics.Add(new Text(x, y, text, color));
        }

        public void removeText(int x, int y)
        {
            geometrics.Remove(geometrics.Find(txt => txt.x == x && txt.y == y));
        }

        public void addNodeHighlight()
        {
            geometrics.Add(pickedNode);
        }

        public void addNodeHighlight(int x, int y)
        {
            geometrics.Add(new NodeHighlight(x, y));
        }

        public void addArcHighlight(int x, int y, int x1, int y1)
        {
            geometrics.Add(new ArcHighlight(x,y,x1,y1));
        }
        public void addArc(int x, int y, int x1, int y1, string text)
        {
            geometrics.Add(new Arc(x,y,x1,y1));
            addText( (x + x1) / 2, (y + y1) / 2, text );
        }

        public void addCircle(int x, int y)
        {
            Rectangle edges = new Rectangle(x - 15, y - 15, 30, 30);
            geometrics.Add(new Circle(x, y, edges));
            addText(x, y);
        }

        public void clearAllHighlights()
        {
            for (int i = 0; i < geometrics.Count; i++)
            {
                if (geometrics[i] is NodeHighlight || geometrics[i] is ArcHighlight
                 || (geometrics[i] is Text && (geometrics[i] as Text).color == (int)colors.BLUE) )
                {
                    geometrics.RemoveAt(i);
                    i--;
                }
            }
        }

        public bool hasHighlightedNode()
        {
            if (geometrics.FindAll(shape => shape is NodeHighlight).Count > 0)
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
                shape.draw();

            Gl.glFlush();
            graphics.Invalidate();
        }
    }
}
