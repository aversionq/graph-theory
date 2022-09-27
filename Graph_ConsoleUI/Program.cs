using System;
using System.Collections.Generic;
using GraphLibrary;

namespace Graph_ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<GraphNode<int>> graphNodes = new List<GraphNode<int>>
            {
                new GraphNode<int>(1, new List<int>
                {
                    1,
                    2,
                    4,
                    6
                }),
                new GraphNode<int>(2, new List<int>
                {
                    1,
                    4,
                    3,
                    5
                }),
                new GraphNode<int>(3, new List<int>
                {
                    2,
                    4,
                    5,
                    6
                }),
                new GraphNode<int>(4, new List<int>
                {
                    1,
                    2,
                    3,
                }),
                new GraphNode<int>(5, new List<int>
                {
                    2,
                    3
                }),
                new GraphNode<int>(6, new List<int>
                {
                    1,
                    3
                })
            };

            Graph<int> graph = new Graph<int>(graphNodes, false, false);
            Console.WriteLine(graph);

            graph.AddNode(new GraphNode<int>(7, new List<int>
            {
                1,
                3,
                5,
                2
            }));
            Console.WriteLine(graph);

            graph.AddEdge(5, 6);
            Console.WriteLine(graph);

            graph.RemoveEdge(1, 6);
            Console.WriteLine(graph);

            graph.RemoveNode(2);
            Console.WriteLine(graph);

            var graphNew = new Graph<int>(@"C:\prog\CODE\C#\GraphTheory_L1\graph1.txt");
            Console.WriteLine(graphNew);
            Console.WriteLine(graphNew.IsDirected);
            Console.WriteLine(graphNew.IsWeighted);

            graph.WriteGraph("test123.txt");

            var graphTest = new Graph<int>(graph);
            Console.WriteLine(graphTest);
            Console.WriteLine(graph);

            Console.WriteLine("removed 3-4 from graphTest. Graph:");
            graphTest.RemoveEdge(3, 4);
            Console.WriteLine(graph);
            Console.WriteLine(graphTest);
        }
    }
}
