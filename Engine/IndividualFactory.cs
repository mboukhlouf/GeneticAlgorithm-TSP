using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticAlgorithm.Engine
{
    public abstract class IndividualFactory<TIndividual> where TIndividual : Individual
    {
        public abstract void Init();

        public abstract TIndividual GetIndividual();

        public abstract TIndividual GetIndividual(TIndividual father);

        public abstract TIndividual GetIndividual(TIndividual father, TIndividual mother);
    }
}
