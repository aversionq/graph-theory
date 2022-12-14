using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GraphLibrary;

namespace Graph_ConsoleUI
{
    internal class Program
    {
        private static Graph<int> graph;

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

            while (true)
            {
                Console.WriteLine("Input graph file name: ");
                var userInput = Console.ReadLine();
                var filePath = @$"C:\prog\CODE\C#\GraphTheory_L1\Graph_ConsoleUI\bin\Debug\netcoreapp3.1\{userInput}.txt";
                if (File.Exists(filePath))
                {
                    graph = new Graph<int>(filePath);
                    Console.WriteLine("Graph loaded!");
                    break;
                }
                else
                {
                    Console.WriteLine("Error! File not found. Try again.");
                }
            }

            var welcomeString = "Choose one of the options:" + Environment.NewLine +
                    "1. Print Graph adjacent list" + Environment.NewLine +
                    "2. Add Node" + Environment.NewLine + "3. Add Edge" +
                    Environment.NewLine + "4. Remove Node" + Environment.NewLine +
                    "5. Remove Edge" + Environment.NewLine + "6. Write graph to .txt file"
                    + Environment.NewLine + "7. Print graph edge list" + Environment.NewLine +
                    "Tasks:" + Environment.NewLine + "8. Calculate inclination degree" +
                    Environment.NewLine + "9. Find isolated nodes" + Environment.NewLine +
                    "10. Union with another directed graph" + Environment.NewLine + 
                    "11. Check if graph is acyclic" + Environment.NewLine + 
                    "12. Get strongly connected components" + Environment.NewLine + 
                    "13. Kruskal's algorithm" + Environment.NewLine + "14. Weight sum <= P"
                    + Environment.NewLine + "15. Shortest paths from node" + Environment.NewLine +
                    "16. N-periphery for node" + Environment.NewLine + "17. Find max flow (Ford Fulkerson)"
                    + Environment.NewLine + "18. Exit";
            var test = GraphHelper.Dijkstra(graph.AdjacentList, 1);
            Console.WriteLine();
            foreach (var item in test)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();

            var test2 = GraphHelper.Floyd(graph.AdjacentList);
            Console.WriteLine();
            foreach (var item in test2)
            {
                foreach (var val in item)
                {
                    Console.Write($"{val} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            var test3 = GraphHelper.BellmanFord(graph.AdjacentList, 1).Keys.ToList();
            Console.WriteLine();
            foreach (var item in test3[0])
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine(welcomeString);
                int choice;
                var res = int.TryParse(Console.ReadLine(), out choice);

                if (res)
                {

                    if (choice == 1)
                    {
                        Console.WriteLine(graph);
                    }

                    else if (choice == 2)
                    {
                        try
                        {
                            Console.WriteLine("Input node name: ");
                            var nodeName = int.Parse(Console.ReadLine());

                            var related = new Dictionary<int, int>();
                            Console.WriteLine("Input amount of related nodes: ");
                            var relAmount = int.Parse(Console.ReadLine());
                            for (int i = 0; i < relAmount; i++)
                            {
                                Console.WriteLine("Input related node name: ");
                                int nodeRel = int.Parse(Console.ReadLine());
                                if (graph.IsNodeExists(nodeRel))
                                {
                                    Console.WriteLine($"Input weight for edge" +
                                        $"{nodeName} - {nodeRel}");
                                    var weight = int.Parse(Console.ReadLine());
                                    related.Add(nodeRel, weight);
                                }
                                else
                                {
                                    Console.WriteLine($"Error! There is no " +
                                        $"{nodeRel} node in this graph.");
                                }
                            }
                            var node = new GraphNode<int>(nodeName, related);
                            graph.AddNode(node);
                            Console.WriteLine($"Node {nodeName} added to the graph!");
                        }
                        catch
                        {
                            Console.WriteLine("This node already exists!");
                        }
                    }

                    else if (choice == 3)
                    {
                        try
                        {
                            Console.WriteLine("Input first node name (from which): ");
                            int node1 = int.Parse(Console.ReadLine());
                            if (!graph.IsNodeExists(node1))
                            {
                                Console.WriteLine($"Error! Node {node1} doesn't exist.");
                                break;
                            }
                            Console.WriteLine("Input second node name (to which): ");
                            int node2 = int.Parse(Console.ReadLine());
                            if (!graph.IsNodeExists(node2))
                            {
                                Console.WriteLine($"Error! Node {node2} doesn't exist.");
                                break;
                            }
                            Console.WriteLine($"Input weight for the " +
                                $"{node1} - {node2} edge: ");
                            int weight = int.Parse(Console.ReadLine());

                            graph.AddEdge(node1, node2, weight);
                            Console.WriteLine($"Edge {node1} - {node2} added");
                        }
                        catch
                        {
                            Console.WriteLine("This edge already exists!");
                            // break;
                        }
                    }

                    else if (choice == 4)
                    {
                        Console.WriteLine("Input node name: ");
                        int node = int.Parse(Console.ReadLine());
                        if (!graph.IsNodeExists(node))
                        {
                            Console.WriteLine($"Error! Node {node} doesn't" +
                                $" exist in this graph.");
                        }
                        else
                        {
                            graph.RemoveNode(node);
                            Console.WriteLine($"Node {node} removed from the graph!");
                        }
                    }

                    else if (choice == 5)
                    {
                        Console.WriteLine("Input first node name: ");
                        int node1 = int.Parse(Console.ReadLine());
                        if (!graph.IsNodeExists(node1))
                        {
                            Console.WriteLine($"Error! Node {node1} doesn't exist.");
                            break;
                        }
                        Console.WriteLine("Input second node name: ");
                        int node2 = int.Parse(Console.ReadLine());
                        if (!graph.IsNodeExists(node2))
                        {
                            Console.WriteLine($"Error! Node {node2} doesn't exist.");
                            break;
                        }

                        graph.RemoveEdge(node1, node2);
                        Console.WriteLine($"Edge {node1} - " +
                            $"{node2} removed from the graph!");
                    }

                    else if (choice == 6)
                    {
                        Console.WriteLine("Input file name: ");
                        var fileName = Console.ReadLine();

                        graph.WriteGraph($"{fileName}.txt");
                        Console.WriteLine("Done! You can see your .txt graph file at:" +
                            @"~GraphTheory_L1\Graph_ConsoleUI\bin\Debug\netcoreapp3.1");
                    }

                    else if (choice == 7)
                    {
                        graph.PrintEdgeList();
                        Console.WriteLine("End of work.");
                    }

                    else if (choice == 8)
                    {
                        Console.WriteLine("Input node name: ");
                        var name = int.Parse(Console.ReadLine());

                        if (graph.IsNodeExists(name))
                        {
                            var nodeDegree = GraphHelper.CalculateInclinationDegree(graph.AdjacentList, name);
                            Console.WriteLine($"Inclination degree of node {name} is {nodeDegree}.");
                        }
                        else
                        {
                            Console.WriteLine($"Error! Node {name} doesn't exist.");
                        }
                    }

                    else if (choice == 9)
                    {
                        var isolated = GraphHelper.FindIsolatedNodes(graph.AdjacentList);
                        if (isolated.Count > 0)
                        {
                            foreach (var node in isolated)
                            {
                                Console.WriteLine($"Node {node} is isolated in this graph.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("There are no isolated nodes in this graph.");
                        }
                    }

                    else if (choice == 10)
                    {
                        while (true)
                        {
                            Console.WriteLine("Input graph file name: ");
                            var userInput = Console.ReadLine();
                            var filePath = @$"C:\prog\CODE\C#\GraphTheory_L1\Graph_ConsoleUI\bin\Debug\netcoreapp3.1\{userInput}.txt";
                            if (File.Exists(filePath))
                            {
                                var graph2 = new Graph<int>(filePath);
                                Console.WriteLine("Graph loaded!");
                                Console.WriteLine("Input the weight for the connective edge: ");
                                var weight = int.Parse(Console.ReadLine());
                                GraphHelper.UnionDirectedGraphs(graph.AdjacentList, graph2.AdjacentList, weight);
                                Console.WriteLine("Union done!");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Error! File not found. Try again.");
                            }
                        }
                    }

                    else if (choice == 11)
                    {
                        var color = new List<int>();
                        color.AddRange(Enumerable.Repeat(0, graph.NodesAmount));
                        if (GraphHelper.IsCyclicGraph(1, graph.AdjacentList, color))
                        {
                            Console.WriteLine("This graph has at least 1 cycle.");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("This graph is acyclic.");
                            Console.WriteLine();
                        }
                    }

                    else if (choice == 12)
                    {
                        var components = GraphHelper.GetStronglyConnectedComponents(graph.AdjacentList);
                        Console.WriteLine();
                        foreach (var comp in components)
                        {
                            foreach (var node in comp)
                            {
                                Console.Write($"{node} ");
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine();
                    }

                    else if (choice == 13)
                    {
                        var carcass = GraphHelper.Kruskal(graph);
                        int? cost = 0;
                        foreach (var edge in carcass)
                        {
                            Console.WriteLine($"{edge.Key} : {edge.Value.Node1} <-> {edge.Value.Node2}");
                            cost += edge.Value.Weight;
                        }
                        Console.WriteLine($"Total carcass weight: {cost}");
                    }

                    else if (choice == 14)
                    {
                        Console.WriteLine("Input P: ");
                        var p = int.Parse(Console.ReadLine());

                        for (int i = 0; i < graph.NodesAmount; i++)
                        {
                            var nodeDist = GraphHelper.Dijkstra(graph.AdjacentList, i + 1);
                            var nodesSum = nodeDist.Sum();
                            if (nodesSum <= p)
                            {
                                Console.WriteLine($"Node {i + 1} sum weight: {nodesSum}");
                            }
                        }
                        Console.WriteLine();
                    }

                    else if (choice == 15)
                    {
                        Console.WriteLine("Input node name: ");
                        var nodeName = int.Parse(Console.ReadLine());

                        if (graph.IsNodeExists(nodeName))
                        {
                            var bellmaResult = GraphHelper.BellmanFord(graph.AdjacentList, nodeName);
                            var isNegCycle = bellmaResult.Values.ToList();
                            var dist = bellmaResult.Keys.ToList();
                            if (!isNegCycle[0])
                            {
                                foreach (var val in dist[0])
                                {
                                    Console.Write($"{val} ");
                                }
                            }
                            else
                            {
                                Console.WriteLine("There is no shortest path " +
                                    "in this graph because of negative cycle.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("This node does not exist.");
                        }
                        Console.WriteLine();
                        Console.WriteLine();
                    }

                    else if (choice == 16)
                    {
                        Console.WriteLine("Input N: ");
                        var n = int.Parse(Console.ReadLine());
                        Console.WriteLine("Input node name: ");
                        var nodeName = int.Parse(Console.ReadLine());

                        var nPeriphery = new List<int>();
                        if (graph.IsNodeExists(nodeName))
                        {
                            var distances = GraphHelper.Floyd(graph.AdjacentList);
                            for (int i = 0; i < distances.Count; i++)
                            {
                                if (distances[i][nodeName - 1] > n && (nodeName - 1) != i)
                                {
                                    nPeriphery.Add(i + 1);
                                }
                            }
                            if (nPeriphery.Count > 0)
                            {
                                Console.WriteLine($"N-Periphery for node {nodeName}: ");
                                foreach (var item in nPeriphery)
                                {
                                    Console.Write($"{item} ");
                                }
                            }
                            else
                            {
                                Console.WriteLine("There is no N-Periphery for this node.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("This node does not exist.");
                        }
                        Console.WriteLine();
                    }

                    else if (choice == 17)
                    {
                        Console.WriteLine(Environment.NewLine + "Input start node: ");
                        var startNode = int.Parse(Console.ReadLine());
                        Console.WriteLine("Input end node: ");
                        var endNode = int.Parse(Console.ReadLine());
                        var maxFlow = GraphHelper.FordFulkerson(startNode, endNode, graph.AdjacentList);
                        Console.WriteLine($"Maximum flow for this graph is: {maxFlow}" + Environment.NewLine);
                    }

                    else if (choice == 18)
                    {
                        Console.WriteLine("End of work.");
                        break;
                    }

                    else if (choice > 18 || choice < 1)
                    {
                        Console.WriteLine("Error! Wrong option number.");
                    }
                }
                else
                {
                    Console.WriteLine("Error! Input int value.");
                    break;
                }
            }
        }
    }
}
