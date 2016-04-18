using System;
using System.Collections.Generic;
using System.Text;
using Tao.OpenGl;
using Tao.FreeGlut;
using Tao.Platform.Windows;
using System.Windows.Forms;

namespace Graph_algorithms
{
    class Render
    {
        public Render(ref SimpleOpenGlControl openGL)
        {
            graphics = openGL;
            graphics.InitializeContexts();
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);
            Gl.glClearColor(255, 255, 255, 1);
            Gl.glViewport(0, 0, graphics.Width, graphics.Height);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluOrtho2D(0.0, graphics.Width, graphics.Height, 0.0);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
        }
        SimpleOpenGlControl graphics;

        public void drawCircle(int x, int y)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glLoadIdentity(); 
            Gl.glPushMatrix();
            Gl.glTranslated(0, 0, 1);
            //... implementation here
            Gl.glPopMatrix();
            Gl.glFlush();
            graphics.Invalidate();
        }

        public void drawArc(int x1, int y1, int x2, int y2)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glLoadIdentity();
            Gl.glBegin(Gl.GL_LINES);
            Gl.glColor3f(1.0f, 0, 0);
            Gl.glVertex2d(x1,y1);
            Gl.glVertex2d(x2, y2);
            Gl.glEnd();
            Gl.glFlush();
            graphics.Invalidate();
        }

        public void drawText(string txt,int x, int y)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glLoadIdentity();
            Gl.glColor3f(1.0f, 0, 0);
            Gl.glRasterPos2d(x,y);
            Glut.glutBitmapString(Glut.GLUT_BITMAP_TIMES_ROMAN_24, txt);
            Gl.glFlush();
            graphics.Invalidate();
                
        }

    }
}
