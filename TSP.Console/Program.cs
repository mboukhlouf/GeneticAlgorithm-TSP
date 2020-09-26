using System;
using GeneticAlgorithm.Engine;

namespace GeneticAlgorithm.TSP.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Parameters.CrossoverRate = 0.0; 
            Parameters.MutationRate = 0.3;
            Parameters.MutationAddRate = 0.0;
            Parameters.MutationDeleteRate = 0.0;
            Parameters.MinimumFitness = 0;
            Parameters.GenerationsMaxNumber = 1000;

            var tspIndividualFactory = new TSPIndividualFactory();
            var evolutionaryProcessTSP = new EvolutionaryProcess<TSPIndividual>(tspIndividualFactory);
            evolutionaryProcessTSP.OnGenerationDone += EvolutionaryProcessTSP_OnGenerationDone;
            evolutionaryProcessTSP.Run();
        }

        private static void EvolutionaryProcessTSP_OnGenerationDone(object sender, GenerationEventArgs<TSPIndividual> e)
        {
            Console.WriteLine($"{e.Generation} -> {e.Best}");
        }
    }
}
