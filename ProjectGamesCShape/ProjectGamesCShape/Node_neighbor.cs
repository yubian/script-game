using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGamesCShape
{
    class Node_neighbor
    {
        private String data;

        public String Data
        {
            get { return data; }
            set { data = value; }
        }

        private int cost;

        public int Cost
        {
            get { return cost; }
            set { cost = value; }
        }

        public Node_neighbor(String data, int cost)
        {
            this.Data = data;
            this.Cost = cost;
        }
    }
}
