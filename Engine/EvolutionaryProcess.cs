using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneticAlgorithm.Engine
{
    public class EvolutionaryProcess<TIndividual> where TIndividual : Individual
    {
        public event GenerationHandler<TIndividual> OnGenerationDone;

        protected IndividualFactory<TIndividual> individualFactrory;
        protected List<TIndividual> population;
        protected int generationNumber = 0;
        protected double bestFitness;

        public EvolutionaryProcess(IndividualFactory<TIndividual> individualFactrory)
        {
            this.individualFactrory = individualFactrory;
            individualFactrory.Init();
            population = new List<TIndividual>();
            for(int i = 0; i < Parameters.IndividualsNumber; i++)
            {
                population.Add(individualFactrory.GetIndividual());
            }
        }

        private void Survival(List<TIndividual> newGeneration)
        {
            population = newGeneration;
        }

        private TIndividual Selection()
        {
            int totalRanks = (Parameters.IndividualsNumber * (Parameters.IndividualsNumber - 1)) / 2;
            int rand = Parameters.RandomGenerator.Next(totalRanks);

            int indIndex = 0;
            int numberParts = Parameters.IndividualsNumber;
            int totalParts = 0;

            while(totalParts < rand)
            {
                indIndex++;
                totalParts += numberParts;
                numberParts--;
            }

            return population.OrderBy(x => x.Fitness).ElementAt(indIndex);
        }

        public void Run()
        {
            bestFitness = Parameters.MinimumFitness + 1;
            while(generationNumber < Parameters.GenerationsMaxNumber
                && bestFitness > Parameters.MinimumFitness)
            {
                foreach(var individual in population)
                {
                    individual.Evaluate();
                }

                var bestIndividual = population
                    .OrderBy(x => x.Fitness)
                    .First();

                bestFitness = bestIndividual.Fitness;
                OnGenerationDone?.Invoke(this, new GenerationEventArgs<TIndividual>(generationNumber, bestIndividual));

                // Selection and reproduction
                var newGeneration = new List<TIndividual>();
                newGeneration.Add(bestIndividual);
                
                for(int i = 0; i < Parameters.IndividualsNumber - 1; i++)
                {
                    TIndividual child;
                    // Two parents or one parent
                    if(Parameters.RandomGenerator.NextDouble() < Parameters.CrossoverRate)
                    {
                        var father = Selection();
                        var mother = Selection();

                        child = individualFactrory.GetIndividual(father, mother);
                    }
                    else
                    {
                        var father = Selection();
                        child = individualFactrory.GetIndividual(father);
                    }
                    newGeneration.Add(child);
                }

                Survival(newGeneration);
                generationNumber++;
            }
        }
    }

    public delegate void GenerationHandler<TIndividual>(object sender, GenerationEventArgs<TIndividual> e) where TIndividual : Individual;

    public class GenerationEventArgs<TIndividual> : EventArgs where TIndividual : Individual
    {
        public int Generation { get; private set; }

        public TIndividual Best { get; private set; }

        public GenerationEventArgs(int generation, TIndividual best)
        {
            Generation = generation;
            Best = best;
        }
    }
}
