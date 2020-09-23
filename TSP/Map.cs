using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticAlgorithm.TSP
{
    public static class Map
    {
        private static readonly List<City> cities;
        private static readonly int[][] distances;

        static Map()
        {
            cities = new List<City>()
            {
                new City("Paris"),
                new City("Lyon"),
                new City("Marseille"),
                new City("Nantes"),
                new City("Bordeaux"),
                new City("Toulouse"),
                new City("Lille")
            };

            distances = new int[cities.Count][];
            distances[0] = new int[] { 0, 462, 772, 379, 546, 678, 215 };       // Paris
            distances[1] = new int[] { 462, 0, 326, 598, 842, 506, 664 };       // Lyon
            distances[2] = new int[] { 772, 326, 0, 909, 555, 407, 1005 };      // Marseille
            distances[3] = new int[] { 379, 598, 909, 0, 338, 540, 584 };       // Nantes
            distances[4] = new int[] { 546, 842, 555, 338, 0, 250, 792, 33 };   // Bordeaux
            distances[5] = new int[] { 678, 506, 407, 540, 250, 0, 926 };       // Toulouse
            distances[6] = new int[] { 215, 664, 1005, 584, 792, 926, 0 };      // Lille
        }

        public static IReadOnlyList<City> Cities => cities;

        public static int GetDistance(City city1, City city2)
        {
            return distances[cities.IndexOf(city1)][cities.IndexOf(city2)];
        }
    }
}
