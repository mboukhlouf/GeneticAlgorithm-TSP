using GeneticAlgorithm.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneticAlgorithm.TSP
{
    public class TSPIndividual : Individual<TSPGene>
    {
        public TSPIndividual()
        {
            genome = new List<TSPGene>();
            var cities = new List<City>(Map.Cities);
            while(cities.Count != 0)
            {
                int index = Parameters.RandomGenerator.Next(cities.Count);
                var city = cities[index];
                genome.Add(new TSPGene(city));
                cities.RemoveAt(index);
            }
        }

        public TSPIndividual(TSPIndividual father)
        {
            genome = new List<TSPGene>();
            foreach (var gene in father.genome)
            {
                genome.Add(new TSPGene(gene));
            }
            Mutate();
        }

        public TSPIndividual(TSPIndividual father, TSPIndividual mother)
        {
            genome = new List<TSPGene>();
            int cuttingPoint = Parameters.RandomGenerator.Next(father.genome.Count);
            foreach (var gene in father.genome.Take(cuttingPoint))
            {
                genome.Add(new TSPGene(gene));
            }
            foreach(var gene in mother.genome)
            {
                if(!genome.Contains(gene))
                {
                    genome.Add(gene);
                }
            }
            Mutate();
        }

        protected override double Evaluate()
        {
            int totalDistance = 0;
            TSPGene oldGene = null;
            foreach(var gene in genome)
            {
                if(oldGene != null)
                {
                    totalDistance += Map.GetDistance(oldGene.City, gene.City);
                }
                oldGene = gene;
            }
            totalDistance += Map.GetDistance(oldGene.City, genome.First().City);
            fitness = totalDistance;
            return fitness;
        }

        protected override void Mutate()
        {
            if(Parameters.RandomGenerator.NextDouble() < Parameters.MutationRate)
            {
                int index1 = Parameters.RandomGenerator.Next(genome.Count);
                var gene = (TSPGene)genome[index1];
                genome.RemoveAt(index1);
                int index2 = Parameters.RandomGenerator.Next(genome.Count);
                genome.Insert(index2, gene);
            }
        }
    }
}
