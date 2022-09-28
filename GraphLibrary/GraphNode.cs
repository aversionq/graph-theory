using System;
using System.Collections.Generic;
using System.Text;

namespace GraphLibrary
{
    public class GraphNode<T>
    {
        internal T Name { get; set; }
        internal List<Dictionary<T, int>> Related { get; set; }

        public GraphNode()
        {
            Related = new List<Dictionary<T, int>>();
        }
        public GraphNode(T name) : this()
        {
            this.Name = name;
        }
        public GraphNode(T name, List<Dictionary<T, int>> related) : this(name)
        {
            Related = related;
        }
    }
}
