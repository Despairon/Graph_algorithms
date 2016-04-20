using System.Collections.Generic;
using System.Drawing;
using Tao.Platform.Windows;

namespace Graph_algorithms
{
    class Graph
    {
        public Graph(ref SimpleOpenGlControl graphics)
        {
            nodes = new List<Node>();
            render = new Render(ref graphics);
        }

        public class Node
        {
            public Node(int x, int y)
            {
                this.x = x;
                this.y = y;
                name = i;
                connections = new Dictionary<Node, double>();
                i++;
               
            }

            public int name { get; }
            private static int i = 1;
            public Dictionary<Node,double> connections { get; }
            public int x { get; }
            public int y { get; }
           
        }
       
        private Node lastAddedNode;
        public List<Node> nodes { get; }
        private Render render;

        public void drawAll()
        {
            render.drawAll();
        }

        public void clearAll()
        {
            render.clearAll();
            nodes.Clear();
        }

        public void deleteHighlights()
        {
            render.clearAllHighlights();
        }
        public void addNode(int x, int y)
        {
            Node node = new Node(x, y);
            nodes.Add(node);
            render.addCircle(x,y);
            lastAddedNode = node;
        }

        public void addNode(Node node)
        {
            nodes.Add(node);
            render.addCircle(node.x, node.y);
            render.clearAllHighlights();
        }

        public void connect(Node left, Node right, double weight)
        {
            render.addArc(left.x, left.y, right.x, right.y, weight.ToString());
            left.connections.Add(right,weight);
            right.connections.Add(left,weight);
        }

        public void connect(Node node, double weight)
        {
            render.addArc(lastAddedNode.x, lastAddedNode.y, node.x, node.y, weight.ToString());
            lastAddedNode.connections.Add(node,weight);
            node.connections.Add(lastAddedNode,weight);
        }

        public bool highlightNode(int x, int y)
        {
            Node tempLeft = null, tempRight = null;
            if (render.hasHighlightedNode())
                tempLeft = nodes.Find(node => node.x == render.highlightedNode.x 
                                   && node.y == render.highlightedNode.y);
            if (render.checkAreaEnter(new Point(x, y)))
            {
                if (tempLeft != null)
                {
                    tempRight = nodes.Find(node => node.x == render.highlightedNode.x
                                   && node.y == render.highlightedNode.y);
                    if (!connected(tempLeft, tempRight) && tempLeft != tempRight)
                    {
                        connect(tempLeft, tempRight, Main_form.weight);
                        render.clearAllHighlights();
                        return true;
                    }
                }
                render.clearAllHighlights();
                render.addHighlight();
                return true;
            }
            return false;
        }

        public bool connect(int x, int y)
        {
            Node left = null;
            Node right = nodes.Find(node => node.x == x && node.y == y);
            if (render.hasHighlightedNode())
            {
                left = nodes.Find(node => node.x == render.highlightedNode.x
                                   && node.y == render.highlightedNode.y);
                connect(left, right, Main_form.weight);
                render.clearAllHighlights();
                return true;
            }
            else
                return false;
        }
        public bool connected(Node left, Node right)
        {
            if (left.connections.ContainsKey(right))
               return true;
            return false;
        }

    }
}
