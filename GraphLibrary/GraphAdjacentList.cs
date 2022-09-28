﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GraphLibrary
{
    public class GraphAdjacentList<T>
    {
        internal Dictionary<T, List<Dictionary<T, int>>> _adjList;

        public GraphAdjacentList()
        {
            _adjList = new Dictionary<T, List<Dictionary<T, int>>>();
        }
        public GraphAdjacentList(List<GraphNode<T>> graphNodes) : this()
        {
            foreach (var node in graphNodes)
            {
                _adjList.Add(node.Name, node.Related);
            }
        }

        //internal GraphAdjacentList(Dictionary<T, List<T>> adj) : this()
        //{
        //    foreach (var kvp in adj)
        //    {
        //        _adjList.Add(kvp.Key, kvp.Value);
        //    }
        //}

        internal void AddNode(GraphNode<T> node, bool isDirected)
        {
            if (!isDirected)
            {
                foreach (var value in node.Related)
                {
                    foreach (var kvp in value)
                    {
                        _adjList[kvp.Key].Add(value);
                    }
                }
            }
            _adjList.Add(node.Name, node.Related);
        }

        internal void AddEdge(T name1, T name2, bool isDirected, int weight)
        {
            _adjList[name1].Add(new Dictionary<T, int>
            {
                {name2, weight},
            });
            if (!isDirected)
            {
                _adjList[name2].Add(new Dictionary<T, int>
                {
                    {name1, weight},
                });
            }
        }

        internal void RemoveNode(T name)
        {
            foreach (var value in _adjList.Values)
            {
                if (value.Contains(name))
                {
                    value.Remove(name);
                }
            }
            _adjList.Remove(name);
        }

        internal void RemoveEdge(T name1, T name2, bool isDirected)
        {
            _adjList[name1].Remove(name2);
            if (!isDirected)
            {
                _adjList[name2].Remove(name1);
            }
        }

        internal string GraphToTxt()
        {
            StringBuilder adj = new StringBuilder();

            foreach (var kvp in _adjList)
            {
                adj.Append($"{kvp.Key}: ");
                foreach (var node in kvp.Value)
                {
                    adj.Append($"{node} ");
                }
                adj.Append(Environment.NewLine);
            }

            return adj.ToString();
        }

        //internal Dictionary<T, List<T>> CopyAdjList()
        //{
        //    Dictionary<T, List<T>> adjListCopy = new Dictionary<T, List<T>>();

        //    foreach (var kvp in _adjList)
        //    {
        //        adjListCopy.Add(kvp.Key, kvp.Value);
        //    }

        //    return adjListCopy;
        //}

        internal bool IsNodeExists(T name) => _adjList.ContainsKey(name);

        internal string Print()
        {
            StringBuilder adjListPrint = new StringBuilder("Graph adjacent list:");
            foreach (var kvp in _adjList)
            {
                adjListPrint.Append(Environment.NewLine + $"{kvp.Key} : ");
                foreach (var value in kvp.Value)
                {
                    adjListPrint.Append($"{value} ");
                }
            }
            return adjListPrint.ToString();
        }
    }
}
