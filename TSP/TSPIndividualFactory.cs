using GeneticAlgorithm.Engine;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticAlgorithm.TSP
{
    public class TSPIndividualFactory : IndividualFactory<TSPIndividual>
    {
        public override void Init()
        {
        }

        public override TSPIndividual GetIndividual()
        {
            return new TSPIndividual();
        }

        public override TSPIndividual GetIndividual(TSPIndividual father)
        {
            return new TSPIndividual(father);
        }

        public override TSPIndividual GetIndividual(TSPIndividual father, TSPIndividual mother)
        {
            return new TSPIndividual(father, mother);
        }
    }
}
