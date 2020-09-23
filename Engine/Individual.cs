using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticAlgorithm.Engine
{
    public abstract class Individual
    {
        protected double fitness = -1;

        public double Fitness => fitness;

        protected internal abstract void Mutate();

        protected internal abstract double Evaluate();
    }

    public abstract class Individual<TGene> : Individual where TGene : Gene
    {
        protected List<TGene> genome;

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(fitness)
                .Append(" : ")
                .Append(String.Join(" - ", genome));
            return stringBuilder.ToString();
        }
    }
}
