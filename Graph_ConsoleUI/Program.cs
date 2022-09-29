using System;
using System.Collections.Generic;
using GraphLibrary;

namespace Graph_ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<GraphNode<int>> graphNodes = new List<GraphNode<int>>
            //{
            //    new GraphNode<int>(1, new List<int>
            //    {
            //        1,
            //        2,
            //        4,
            //        6
            //    }),
            //    new GraphNode<int>(2, new List<int>
            //    {
            //        1,
            //        4,
            //        3,
            //        5
            //    }),
            //    new GraphNode<int>(3, new List<int>
            //    {
            //        2,
            //        4,
            //        5,
            //        6
            //    }),
            //    new GraphNode<int>(4, new List<int>
            //    {
            //        1,
            //        2,
            //        3,
            //    }),
            //    new GraphNode<int>(5, new List<int>
            //    {
            //        2,
            //        3
            //    }),
            //    new GraphNode<int>(6, new List<int>
            //    {
            //        1,
            //        3
            //    })
            //};

            //Graph<int> graph = new Graph<int>(graphNodes, false, false);
            //Console.WriteLine(graph);

            //graph.AddNode(new GraphNode<int>(7, new List<int>
            //{
            //    1,
            //    3,
            //    5,
            //    2
            //}));
            //Console.WriteLine(graph);

            //graph.AddEdge(5, 6);
            //Console.WriteLine(graph);

            //graph.RemoveEdge(1, 6);
            //Console.WriteLine(graph);

            //graph.RemoveNode(2);
            //Console.WriteLine(graph);

            //var graphNew = new Graph<int>(@"C:\prog\CODE\C#\GraphTheory_L1\graphEdges1.txt", false);
            // Console.WriteLine(graphNew);
            //Console.WriteLine(graphNew.IsDirected);
            //Console.WriteLine(graphNew.IsWeighted);

            //graph.WriteGraph("test123.txt");

            //var graphTest = new Graph<int>(graph);
            //Console.WriteLine(graphTest);
            //Console.WriteLine(graph);

            //Console.WriteLine("removed 3-4 from graphTest. Graph:");
            //graphTest.RemoveEdge(3, 4);
            //Console.WriteLine(graph);
            //Console.WriteLine(graphTest);

            //--------------------------------------------------------------------------

            //var graphNodes = new List<GraphNode<int>>
            //{
            //    new GraphNode<int>(1, new Dictionary<int, int>
            //    {
            //        {1, 5},
            //        {2, 3},
            //        {4, 7},
            //        {6, 10}
            //    }),
            //    new GraphNode<int>(2, new Dictionary<int, int>
            //    {
            //        {1, 5},
            //        {4, 3},
            //        {3, 7},
            //        {5, 1}
            //    }),
            //    new GraphNode<int>(3, new Dictionary<int, int>
            //    {
            //        {2, 7},
            //        {4, 3},
            //        {5, 4},
            //        {6, 12}
            //    }),
            //    new GraphNode<int>(4, new Dictionary<int, int>
            //    {
            //        {1, 7},
            //        {2, 3},
            //        {3, 3}
            //    }),
            //    new GraphNode<int>(5, new Dictionary<int, int>
            //    {
            //        {2, 1},
            //        {3, 4}
            //    }),
            //    new GraphNode<int>(6, new Dictionary<int, int>
            //    {
            //        {1, 3},
            //        {3, 12}
            //    })
            //};
            //Graph<int> graph = new Graph<int>(graphNodes, false, true);
            //Console.WriteLine(graph);

            //GraphNode<int> node1 = new GraphNode<int>(7, new Dictionary<int, int>
            //{
            //    {1, 8},
            //    {4, 15},
            //    {7, 0}
            //});
            //graph.AddNode(node1);
            //Console.WriteLine(graph);

            //graph.AddEdge(7, 2, 50);
            //Console.WriteLine(graph);

            //graph.RemoveEdge(1, 6);
            //Console.WriteLine(graph);

            //graph.RemoveNode(4);
            //Console.WriteLine(graph);

            //var graphNew = new Graph<int>(@"C:\prog\CODE\C#\GraphTheory_L1\graphNew.txt");
            //Console.WriteLine(graphNew);

            //graphNew.WriteGraph("newtg.txt");

            //var graphTest = new Graph<int>(graph);
            //Console.WriteLine(graph);
            //Console.WriteLine(graphTest);

            //graphTest.RemoveEdge(2, 5);
            //Console.WriteLine(graph);
            //Console.WriteLine(graphTest);

            Console.WriteLine("Input graph file name: ");
            var userInput = Console.ReadLine();
            var filePath = @$"C:\prog\CODE\C#\GraphTheory_L1\{userInput}.txt";
            try
            {
                var graph = new Graph<int>(filePath);
                Console.WriteLine("Graph loaded!");
            }
            catch (Exception)
            {

            }

            var welcomeString = "Choose one of the options:" + Environment.NewLine +
                                "1. Print Graph adjacent list" + Environment.NewLine +
                                "2. Add Node" + Environment.NewLine + "3. Add Edge" +
                                Environment.NewLine + "4. Remove Node" + Environment.NewLine +
                                "5. Remove Edge" + Environment.NewLine + "6. Write graph to .txt file"
                                + Environment.NewLine + "7. Exit";
        }
    }
}
