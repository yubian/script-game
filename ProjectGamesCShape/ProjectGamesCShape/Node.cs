using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGamesCShape
{
    class Node
    {
        private String data;

        public String Data
        {
            get { return data; }
            set { data = value; }
        }

        private List<Node_neighbor> all_neighbor = new List<Node_neighbor>();

        public Node(String data)
        {
            this.Data = data;
        }

        public void add_myNeighbor(String data, int cost)
        {
            all_neighbor.Add(new Node_neighbor(data, cost));
        }

        public void getnodedata(List<Tuple<string,int>> neighbor)
        {
            foreach (var item in all_neighbor)
            {
                neighbor.Add(Tuple.Create(item.Data,item.Cost));
            }
        }

    }
}
