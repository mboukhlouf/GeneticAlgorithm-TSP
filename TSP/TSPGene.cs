using GeneticAlgorithm.Engine;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticAlgorithm.TSP
{
    public class TSPGene : Gene
    {
        private City city;

        public TSPGene(City city)
        {
            this.city = city;
        }

        public TSPGene(TSPGene gene)
        {
            city = gene.city;
        }

        public City City => city;

        public override void Mutate()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return city.ToString();
        }
    }
}
