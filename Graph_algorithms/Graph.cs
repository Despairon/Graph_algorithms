using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao.Platform.Windows;

namespace Graph_algorithms
{
    public enum algorithms { BFS, DFS };

    public class Graph
    {
        public Graph(ref SimpleOpenGlControl graphics)
        {
            nodes = new List<Node>();
            render = new Render(ref graphics);
        }
        private Node lastAddedNode;
        public List<Node> nodes { get; }
        private Render render;

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
            public static void resetNames()
            {
                i = 1;
            }
           
        }

        public class Algorithm
        {
            public class BFS : Algorithm
            {
                public BFS(Graph graph, Node start, Node goal) : base (graph)
                {
                    queue = new Queue<Node>();
                    opened = new List<Node>();
                    startNode = start;
                    goalNode = goal;
                    identificator = (int)algorithms.BFS;
                    queue.Enqueue(startNode);
                }
                Queue<Node> queue;
                List<Node> opened;
                private Node startNode;
                private Node goalNode;

                public async Task make()
                {
                    var u = queue.Dequeue();
                    opened.Add(u);
                    graph.highlightNode(u);
                    if (u == goalNode)
                    {
                        MessageBox.Show("Вузол " + u.name + " знайдений!");
                        return;
                    }
                    else
                        foreach (var node in u.connections)
                        if (!opened.Contains(node.Key))
                            queue.Enqueue(node.Key);
                    if (queue.Count == 0)
                    {
                        MessageBox.Show("Вузол" + goalNode.name + "неможливо досягти з початкового вузла!");
                        return;
                    }
                    await Task.Delay(1000);
                    await make();
                }

            }

            public class DFS : Algorithm
            {
                public DFS(Graph graph, Node start, Node goal) : base(graph)
                {
                    opened = new List<Node>();
                    startNode = start;
                    goalNode = goal;
                    identificator = (int)algorithms.DFS;
                }
                List<Node> opened;
                private Node startNode;
                private Node goalNode;

                public async Task make(Node u)
                {
                    if (u == goalNode)
                    {
                        MessageBox.Show("Вузол " + u.name + " знайдений!");
                        return;
                    }
                    opened.Add(u);
                    graph.highlightNode(u);
                    foreach (var w in u.connections)
                        if (!opened.Contains(w.Key))
                        {
                            await Task.Delay(1000);
                            await make(w.Key);
                        }
                }
                public async Task make()
                {
                    await make(startNode);
                }

            }

            public Algorithm(Graph graph)
            {
                this.graph = graph;
            }
            protected Graph graph;
            public int identificator;
        }

        public void drawAll()
        {
            render.drawAll();
        }

        public void clearAll()
        {
            render.clearAll();
            nodes.Clear();
            Node.resetNames();
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
            Node tempLeft = null;
            Node tempRight = null;
            if (render.hasHighlightedNode())
                tempLeft = nodes.Find(node => node.x == render.highlightedNode.x 
                                   && node.y == render.highlightedNode.y);
            if (render.checkAreaEnter(new Point(x, y)))
            {
                if (tempLeft != null)
                {
                    tempRight = nodes.Find(node => node.x == render.highlightedNode.x
                                   && node.y == render.highlightedNode.y);
                    if (!isConnected(tempLeft, tempRight) && tempLeft != tempRight)
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

        public void highlightNode(Node node)
        {
            render.addHighlight(node.x,node.y);
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

        private bool isConnected(Node left, Node right)
        {
            if (left.connections.ContainsKey(right))
               return true;
            return false;
        }

        public async Task doAlgorithm (Algorithm algorithm)
        {
            Program.disableForm();
            switch (algorithm.identificator)
            {
                case (int)algorithms.BFS:
                    await (algorithm as Algorithm.BFS).make();
                    break;
                case (int)algorithms.DFS:
                    await (algorithm as Algorithm.DFS).make();
                    break;
            }
            Program.enableForm();

        }

    }
}
