using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticAlgorithm.Engine
{
    public static class Parameters
    {
        public static int IndividualsNumber { get; set; } = 20;
        public static int GenerationsMaxNumber { get; set; } = 50;
        public static int InitialGenesNumber { get; set; } = 10;
        public static int MinimumFitness { get; set; } = 0;

        public static double MutationRate { get; set; } = 0.10;
        public static double MutationAddRate { get; set; } = 0.20;
        public static double MutationDeleteRate { get; set; } = 0.10;
        public static double CrossoverRate { get; set; } = 0.60;

        public static Random RandomGenerator { get; } = new Random();
    }
}
