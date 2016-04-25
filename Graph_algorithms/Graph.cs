using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao.Platform.Windows;
using System.Linq;
using System;

namespace Graph_algorithms
{
    enum algorithms { BFS, DFS }

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

        public abstract class Algorithm
        {
            public class BFS : Algorithm
            {
                public BFS(Graph graph, Node start, Node goal) : base (graph)
                {
                    queue = new Queue<Node>();
                    opened = new List<Node>();
                    startNode = start;
                    goalNode = goal;
                    queue.Enqueue(startNode);
                }
                private Queue<Node> queue;
                private List<Node> opened;
                private Node startNode;
                private Node goalNode;

                public override async Task make()
                {
                    var u = queue.Dequeue();
                    opened.Add(u);
                    graph.highlightNode(u);
                    if (u == goalNode)
                    {
                        MessageBox.Show("Вузол " + u.name + " знайдений!");
                        success = true;
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
                }
                private List<Node> opened;
                private Node startNode;
                private Node goalNode;

                public async Task make(Node u)
                {
                    opened.Add(u);
                    graph.highlightNode(u);
                    if (u == goalNode)
                    {
                        MessageBox.Show("Вузол " + u.name + " знайдений!");
                        success = true;
                    }
                    foreach (var w in u.connections)
                        if (!opened.Contains(w.Key))
                        {
                            if (success)
                                break;
                            else
                            {
                                await Task.Delay(1000);
                                await make(w.Key);
                            }
                        }
                }

                public override async Task make()
                {
                    await make(startNode);
                }

            }

            public class Kruskal : Algorithm
            {
                public Kruskal(Graph graph) : base(graph)
                {
                    arcs = new Dictionary<KeyValuePair<Node, Node>, double>();
                    sets = new List<List<Node>>();
                    foreach (var node in graph.nodes)
                    {
                        var list = new List<Node>();
                        list.Add(node);
                        sets.Add(list);
                    }
                    foreach (var node in graph.nodes)
                        foreach (var arc in node.connections)
                            if (!arcs.ContainsKey(new KeyValuePair<Node, Node>(node, arc.Key))
                             && !arcs.ContainsKey(new KeyValuePair<Node, Node>(arc.Key, node)))
                                arcs.Add(new KeyValuePair<Node, Node>(node, arc.Key),arc.Value);
                }
                private Dictionary<KeyValuePair<Node, Node>, double> arcs;
                private List<List<Node>> sets;

                public override async Task make()
                {
                    List<Node> setLeft = null;
                    List<Node> setRight = null;
                    foreach (var arc in arcs.OrderBy(pair => pair.Value))
                    {
                        setLeft = sets.Find(set => set.Contains(arc.Key.Key));
                        setRight = sets.Find(set => set.Contains(arc.Key.Value));
                        if (setLeft != setRight)
                        {
                            setLeft.AddRange(setRight);
                            sets.Remove(setRight);
                            graph.highlightNode(arc.Key.Key);
                            await Task.Delay(1000);
                            graph.highlightArc(arc.Key.Key.x, arc.Key.Key.y,
                                               arc.Key.Value.x, arc.Key.Value.y);
                            graph.highlightNode(arc.Key.Value);
                            await Task.Delay(1000);
                        }
                    }
                    if (sets.Count == 1)
                        MessageBox.Show("Мінімальне остовне дерево побудовано!");
                    else
                        MessageBox.Show("Мінімальне остовне дерево не існує!");
                }
            }

            public class Prim : Algorithm
            {
                public Prim(Graph graph) : base (graph)
                {
                    MST = new List<Node>();
                    MST.Add(graph.nodes.First());
                }
                List<Node> MST;

                public override async Task make()
                {
                    await make(MST.First());
                }

                private async Task make(Node node)
                {
                    //graph.highlightNode(node);
                    //await Task.Delay(1000);
                }

                //private Node min(Dictionary<Node,double> arcs)
                //{
                //    KeyValuePair<Node, double> min = arcs.First();
                //    foreach (var arc in arcs)
                //    {
                //        if (arc.Value <= min.Value)
                //            min = arc;
                //    }
                //    return min.Key;
                //}

                //private Node minAcceptable()
                //{
                //    foreach (var node in MST)
                //        if (!MST.Contains(min(node.connections)))
                //            return min(node.connections);
                //    return null;
                //}
            }

            public Algorithm(Graph graph)
            {
                this.graph = graph;
            }
            protected Graph graph;
            protected bool success = false;

            public abstract Task make();
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
                tempLeft = nodes.Find(node => node.x == render.pickedNode.x 
                                   && node.y == render.pickedNode.y);
            if (render.checkAreaEnter(new Point(x, y)))
            {
                if (tempLeft != null)
                {
                    tempRight = nodes.Find(node => node.x == render.pickedNode.x
                                   && node.y == render.pickedNode.y);
                    if (!isConnected(tempLeft, tempRight) && tempLeft != tempRight)
                    {
                        connect(tempLeft, tempRight, Main_form.weight);
                        render.clearAllHighlights();
                        return true;
                    }
                }
                render.clearAllHighlights();
                render.addNodeHighlight();
                return true;
            }
            return false;
        }

        public void highlightNode(Node node)
        {
            render.addNodeHighlight(node.x,node.y);
        }

        public void highlightArc(int x, int y, int x1, int y1)
        {
            render.addArcHighlight(x,y,x1,y1);
        }

        public bool connect(int x, int y)
        {
            Node left = null;
            Node right = nodes.Find(node => node.x == x && node.y == y);
            if (render.hasHighlightedNode())
            {
                left = nodes.Find(node => node.x == render.pickedNode.x
                                   && node.y == render.pickedNode.y);
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
            await algorithm.make();
            Program.enableForm();

        }

    }
}
