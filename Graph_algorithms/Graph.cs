using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao.Platform.Windows;
using System.Linq;
using System;

namespace Graph_algorithms
{
    enum algorithms { BFS, DFS, KRUSKAL, PRIM, DIJKSTRAS, FLOYD_WARSH,
                      BELL_FORD, JOHNSON }

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
                public BFS(Graph graph, Node start, Node goal) : base(graph)
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

                protected override bool success
                {
                    get { return _success; }
                    set
                    {
                       if (value)
                            MessageBox.Show("Цільовий вузол знайдений!");
                       else
                            MessageBox.Show("Цільовий вузол неможливо досягти з початкового вузла!");
                        _success = value;
                    }
                }


                public override async Task make()
                {
                    var u = queue.Dequeue();
                    opened.Add(u);
                    graph.highlightNode(u);
                    if (u == goalNode)
                    {
                        success = true;
                        return;
                    }
                    else
                        foreach (var node in u.connections)
                            if (!opened.Contains(node.Key))
                                queue.Enqueue(node.Key);
                    if (queue.Count == 0)
                    {
                        success = false;
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

                protected override bool success
                {
                    get { return _success; }


                    set
                    {
                        if (value)
                            MessageBox.Show("Цільовий вузол знайдений!");
                        else
                            MessageBox.Show("Цільовий вузол неможливо досягти з початкового вузла!");
                        _success = value;
                    }
                }

                public async Task make(Node u)
                {
                    opened.Add(u);
                    graph.highlightNode(u);
                    if (u == goalNode)
                        success = true;
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
                                arcs.Add(new KeyValuePair<Node, Node>(node, arc.Key), arc.Value);
                }
                private Dictionary<KeyValuePair<Node, Node>, double> arcs;
                private List<List<Node>> sets;

                protected override bool success
                {
                    get { return _success; }

                    set
                    {
                        if (value)
                            MessageBox.Show("Мінімальне остовне дерево побудовано!");
                        else
                            MessageBox.Show("Мінімальне остовне дерево не існує!");
                        _success = value;
                    }
                }

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
                            await Task.Delay(1000);
                            setLeft.AddRange(setRight);
                            sets.Remove(setRight);
                            graph.highlightNode(arc.Key.Key);
                            graph.highlightArc(arc.Key.Key.x, arc.Key.Key.y,
                                               arc.Key.Value.x, arc.Key.Value.y);
                            graph.highlightNode(arc.Key.Value);
                        }
                    }
                    if (sets.Count == 1)
                        success = true;
                    else
                        success = false;
                }
            }

            public class Prim : Algorithm
            {
                public Prim(Graph graph) : base(graph)
                {
                    MST = new List<Node>();
                    MST.Add(graph.nodes.First());
                }
                private List<Node> MST;

                protected override bool success
                {
                    get { return _success; }

                    set
                    {
                        if (value)
                            MessageBox.Show("Мінімальне остовне дерево побудовано!");
                        else
                            MessageBox.Show("Мінімальне остовне дерево не існує!");
                        _success = value;
                    }
                }

                public override async Task make()
                {
                    try
                    {
                        var nodes = new List<Node>(graph.nodes);
                        nodes.Remove(MST.First());
                        graph.highlightNode(MST.First());
                        while (nodes.Count > 0)
                        {
                            await Task.Delay(1000);
                            var next = minAcceptable();
                            nodes.Remove(next);
                            MST.Add(next);
                            graph.highlightNode(next);
                        }
                        success = true;
                    }
                    catch (Exception)
                    {
                        success = false;
                    }
                }

                private Node minAcceptable()
                {
                    var acceptables = new List<KeyValuePair<Node,double>>();
                    foreach (var node in MST)
                        foreach (var arc in node.connections)
                            if (!MST.Contains(arc.Key))
                                acceptables.Add(new KeyValuePair<Node, double>(arc.Key, arc.Value));
                    return min(acceptables);
                }

                private Node min(List<KeyValuePair<Node, double>> arcs)
                {
                    KeyValuePair<Node, double> min = arcs.First();
                    foreach (var arc in arcs)
                        if (arc.Value < min.Value)
                            min = arc;

                    var left = graph.nodes.Find(node => node.connections.ContainsKey(min.Key) 
                                          && node.connections.ContainsValue(min.Value));
                    graph.highlightArc(left.x,left.y,min.Key.x,min.Key.y);

                    return min.Key;
                }
            }

            public class Bell_Ford : Algorithm
            {
                public Bell_Ford(Graph graph, Node start, Node goal) : base (graph)
                {
                    this.start = start;
                    this.goal = goal;
                    d = new double[graph.nodes.Count];
                }
                private Node start;
                private Node goal;
                private double[] d;

                protected override bool success
                {
                    get { return _success; }

                    set
                    {
                        if (value)
                        {
                            MessageBox.Show("Найкоротший шлях між "
                                           + start.name.ToString() + " та "
                                           + goal.name.ToString()
                                           + " = "
                                           + d[goal.name-1].ToString());
                        }
                        else
                            MessageBox.Show("Найкоротшого шляху між "
                                           + start.name.ToString() + " та "
                                           + goal.name.ToString()
                                           + " не існує!");
                    }
                }

                public override async Task make()
                {
                    try
                    {
                        foreach (var node in graph.nodes)
                            d[node.name - 1] = INF;
                        d[start.name - 1] = 0;
                        for (int i = 1; i < graph.nodes.Count - 1; i++)
                            foreach (var node in graph.nodes)
                                foreach (var arc in node.connections)
                                    if (d[arc.Key.name - 1] > d[node.name - 1] + arc.Value)
                                        d[arc.Key.name - 1] = d[node.name - 1] + arc.Value;
                        success = true;
                    }
                    catch (Exception)
                    {
                        success = false;
                    }
                }

            }

            public class Dijkstras : Algorithm
            {
                public Dijkstras(Graph graph, Node start, Node goal) : base (graph)
                {
                    this.start = start;
                    this.goal = goal;
                    marks = new Dictionary<Node, double>();
                    opened = new List<Node>();
                }
                private Node start;
                private Node goal;
                private Dictionary<Node, double> marks;
                private List<Node> opened;

                protected override bool success
                {
                    get { return _success; }

                    set
                    {
                        if (value)
                        {
                            double road = marks.FirstOrDefault(pair => pair.Key == goal).Value;
                            MessageBox.Show("Найкоротший шлях між "
                                           + start.name.ToString() + " та "
                                           + goal.name.ToString()
                                           + " = "
                                           + road.ToString());
                        }
                        else
                            MessageBox.Show("Найкоротшого шляху між "
                                           + start.name.ToString() + " та "
                                           + goal.name.ToString()
                                           + " не існує!");
                        _success = value;
                    }
                }

                public override async Task make()
                {
                    try
                    {
                        marks.Add(start, 0);
                        var currMark = marks.First();
                        graph.changeMark(start.x, start.y, "0");
                        foreach (var node in graph.nodes)
                            if (node != start)
                            {
                                marks.Add(node, INF);
                                graph.changeMark(node.x, node.y, "INF");
                            }
                        graph.highlightNode(start);
                        while (opened.Count != graph.nodes.Count)
                        {
                            opened.Add(currMark.Key);
                            foreach (var arc in currMark.Key.connections.OrderBy(arc => arc.Value))
                            {
                                if (!opened.Contains(arc.Key))
                                {
                                    var possibleNode = marks.FirstOrDefault(pair => pair.Key == arc.Key);
                                    if ((arc.Value + currMark.Value) < possibleNode.Value)
                                    {
                                        marks[possibleNode.Key] = arc.Value + currMark.Value;
                                        await Task.Delay(1000);
                                        graph.highlightArc(currMark.Key.x, currMark.Key.y, possibleNode.Key.x, possibleNode.Key.y);
                                        graph.changeMark(possibleNode.Key.x, possibleNode.Key.y, marks[possibleNode.Key].ToString());
                                    }
                                }
                            }
                            currMark = min();
                            await Task.Delay(1000);
                            graph.highlightNode(currMark.Key);
                        }
                        success = true;
                    }
                    catch (Exception)
                    {
                        success = false;
                    }
                }

                private KeyValuePair<Node,double> min()
                {
                    KeyValuePair<Node, double> min = max();
                    foreach (var mark in marks)
                    {
                        if ((mark.Value < min.Value) && !(opened.Contains(mark.Key)))       
                            min = mark;
                    }
                    return min;
                }

                private KeyValuePair<Node,double> max()
                {
                    KeyValuePair<Node, double> max = marks.First();
                    foreach (var mark in marks)
                    {
                        if ((mark.Value > max.Value) && !(opened.Contains(mark.Key)))
                            max = mark;
                    }
                    return max;
                }

            }

            public class Floyd_Warsh : Algorithm
            {
                public Floyd_Warsh(Graph graph, Node start, Node goal) : base (graph)
                {
                    this.start = start;
                    this.goal = goal;
                    d = new double[graph.nodes.Count, graph.nodes.Count];
                    foreach (var node in graph.nodes)
                        foreach (var arc in node.connections)
                            d[node.name-1, arc.Key.name-1] = arc.Value;
                    for (int i = 0; i < graph.nodes.Count; i++)
                        for (int j = 0; j < graph.nodes.Count; j++)
                            if (i != j && d[i, j] == 0)
                                d[i, j] = INF;
                }
                private Node start;
                private Node goal;
                private double[,] d;

                protected override bool success
                {
                    get { return _success; }

                    set
                    {
                        if (value)
                        {
                            MessageBox.Show("Найкоротший шлях між "
                                           + start.name.ToString() + " та "
                                           + goal.name.ToString()
                                           + " = "
                                           + d[start.name-1,goal.name-1]);
                        }
                        else
                            MessageBox.Show("Найкоротшого шляху між "
                                           + start.name.ToString() + " та "
                                           + goal.name.ToString()
                                           + " не існує!");
                        _success = value;
                    }
                }

                public override async Task make()
                {
                    try
                    {
                        int[,] next = new int[graph.nodes.Count, graph.nodes.Count];
                        for (int i = 0; i < graph.nodes.Count; i++)
                            for (int j = 0; j < graph.nodes.Count; j++)
                                next[i, j] = INF;

                        for (int i = 0; i < graph.nodes.Count; i++)
                            for (int j = 0; j < graph.nodes.Count; j++)
                                for (int k = 0; k < graph.nodes.Count; k++)
                                    if (d[j, k] > (d[j, i] + d[i, k]))
                                    {
                                        d[j, k] = d[j, i] + d[i, k];
                                        next[j, k] = i;
                                        /*** почему-то оно неправильно восстанавливает путь...
                                         *   понятия не имею что такое...
                                        ***/
                                    }
                        if (d[start.name-1, goal.name-1] == INF)
                            throw new Exception();
                        else
                            success = true;
                        //int c = start.name-1;
                        // while (c != goal.name-1)
                        // {
                        //     await Task.Delay(1000);
                        //     graph.highlightNode(graph.nodes.Find(node => node.name == c+1));
                        //     c = next[c, goal.name-1];
                        // }
                    }
                    catch (Exception)
                    {
                        success = false;
                    }
                }

            }

            public class Johnson : Algorithm
            {
                public Johnson(Graph graph, Node start, Node goal) : base(graph)
                {
                    this.start = start;
                    this.goal = goal;
                    _d = new double[graph.nodes.Count, graph.nodes.Count];
                }
                private Node start;
                private Node goal;
                private double[,] _d;

                protected override bool success
                {
                    get { return _success; }

                    set
                    {
                        if (value)
                        {
                            MessageBox.Show("Найкоротший шлях між "
                                           + start.name.ToString() + " та "
                                           + goal.name.ToString()
                                           + " = "
                                           + _d[start.name-1,goal.name-1]);
                        }
                        else
                            MessageBox.Show("Найкоротшого шляху між "
                                           + start.name.ToString() + " та "
                                           + goal.name.ToString()
                                           + " не існує!");
                        _success = value;
                    }
                }

                public override async Task make()
                {
                    int s;
                    int[] _g;
                    double[,] _w;
                    double[] h;
                    double[] dBellmanFord;
                    double[,] dDijkstra;

                    buildNewGraph(out s, out _g, out _w);
                    h = new double[_g.Length];
                    dDijkstra = new double[graph.nodes.Count, graph.nodes.Count];

                    if (!bellman_ford(_g, _w, s, out dBellmanFord))
                    {
                        success = false;
                        return;
                    }

                    Array.Copy(dBellmanFord, h, h.Length);

                    for (int u = 0; u < _g.Length; u++)
                        for (int v = 0; v < _g.Length; v++)
                            _w[u, v] += h[u] - h[v];

                    foreach (var u in graph.nodes)
                    {
                        dijkstra(_g, _w, u.name - 1, ref dDijkstra);
                        foreach (var v in graph.nodes)
                            _d[u.name - 1, v.name - 1] = dDijkstra[u.name - 1, v.name - 1] + h[v.name - 1] - h[u.name - 1];
                    }

                    success = true;
                }

                private bool bellman_ford(int[] g, double[,] w, int s, out double[] d)
                {
                    d = new double[g.Length];
                    foreach (var u in g)
                        d[u-1] = INF;
                    d[s-1] = 0;
                    for (int i = 1; i < d.Length - 1; i++)
                        for (int u = 0; u < d.Length; u++)
                            for (int v = 0; v < d.Length; v++)
                                if (d[v] > d[u] + w[u, v])
                                    d[v] = d[u] + w[u, v];
                    for (int u = 0; u < d.Length; u++)
                        for (int v = 0; v < d.Length; v++)
                            if (d[v] > d[u] + w[u, v])
                                return false;
                    return true;                    
                }

                private void dijkstra(int[] g, double[,] w ,int s, ref double[,] d) // и тут может быть проблема
                {
                    List<int> visited = new List<int>();
                    d[s, s] = 0;
                    for (int u = 0; u < g.Length-1; u++)
                        for (int v = 0; v < g.Length-1; v++)
                            if (u != v)
                                d[u, v] = INF;
                    while (visited.Count != g.Length-1)  // особенно тут!
                    {
                        int v = min(ref g, s, d);
                        visited.Add(v);
                        for (int u = 0; u < g.Length-1; u++)
                            if (!visited.Contains(u))
                            if (d[v, u] > d[u, v] + w[v, u])
                                d[v, u] = d[u, v] + w[v, u];
                    }
                }

                private int min(ref int[] g, int u, double[,] d) // тут может быть проблема
                {
                    double _min = INF;
                    for (int v = 0; v < g.Length-1; v++)
                        if (d[u, v] < _min)
                            _min = d[u, v];
                    for (int v = 0; v < g.Length-1; v++)
                        if (d[u, v] == _min)
                            return v;
                    return -1;
                }

                private void buildNewGraph(out int s, out int[] g, out double[,] w )
                {
                    s = graph.nodes.Last().name + 1;
                    g = new int[graph.nodes.Count + 1];
                    w = new double[graph.nodes.Count + 1, graph.nodes.Count + 1];
                    int i = 0;
                    foreach (var node in graph.nodes)
                    {
                        g[i] = node.name;
                        i++;
                    }
                    g[i] = s;
                    for (int j = 0; j < graph.nodes.Count; j++)
                        for (int k = 0; k < graph.nodes.Count; k++)
                            if (j != k)
                                w[j, k] = INF;
                            else
                                w[j, k] = 0;
                    foreach (var node in graph.nodes)
                        foreach (var arc in node.connections)
                            w[node.name - 1, arc.Key.name - 1] = arc.Value;
                    foreach (var node in graph.nodes)
                    {
                        w[s - 1, node.name - 1] = 0;
                        w[node.name - 1, s - 1] = 0;
                    }
                }

            }
            public Algorithm(Graph graph)
            {
                this.graph = graph;
            }
            protected Graph graph;
            protected  bool _success;
            protected abstract bool success { get; set; }
            protected const int INF = 1000000000;

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

        public void changeMark(int x, int y, string text)
        {
            render.removeText(x, y-20);
            render.addText(x,y-20,text,(int)colors.BLUE);
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
            deleteHighlights();
            await algorithm.make();
            Program.enableForm();

        }

    }
}
