using System;
using System.Collections.Generic;
using System.Text;

namespace GraphLibrary
{
    public class GraphNode<T>
    {
        internal T Name { get; set; }
        internal List<T> Related { get; set; }

        public GraphNode()
        {
            Related = new List<T>();
        }
        public GraphNode(T name) : this()
        {
            this.Name = name;
        }
        public GraphNode(T name, List<T> related) : this(name)
        {
            Related = related;
        }
    }
}
