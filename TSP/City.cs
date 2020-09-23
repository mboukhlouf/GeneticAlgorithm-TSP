using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticAlgorithm.TSP
{
    public struct City
    {
        string name;

        public City(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
