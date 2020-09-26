using System;
using System.Collections.Generic;
using System.Text;

namespace GeneticAlgorithm.TSP
{
	public static class Map
	{
		private static readonly List<City> cities;
		private static readonly double[][] distances;

		static Map()
		{
			cities = new List<City>() {
				new City("Fès"),
				new City("Tanger"),
				new City("Casablanca"),
				new City("Tetouan"),
				new City("Chefchaouen"),
				new City("Marrakesh"),
				new City("Rabat"),
				new City("Beni-Mellal")
			};

			distances = new double[cities.Count][];
			distances[0] = new double[] {
				0,
				259.339,
				185.822,
				290.936,
				132.317,
				331.594,
				131.84,
				182.691
			}; // Fès

			distances[1] = new double[] {
				260.347,
				0,
				211.61,
				42.025,
				74.973,
				357.382,
				157.126,
				331.976
			}; // Tanger

			distances[2] = new double[] {
				186.67,
				211.986,
				0,
				243.583,
				212.984,
				151.674,
				55.544,
				126.268
			}; // Casablanca

			distances[3] = new double[] {
				292.414,
				48.682,
				243.677,
				0,
				37.428,
				389.449,
				189.192,
				364.043
			}; // Tetouan

			distances[4] = new double[] {
				132.254,
				81.512,
				213.188,
				37.225,
				0,
				358.96,
				158.703,
				333.554
			}; // Chefchaouen
			distances[5] = new double[] {
				331.701,
				357.017,
				151.722,
				388.614,
				358.015,
				0,
				200.575,
				126.024
			}; // Marrakesh
			distances[6] = new double[] {
				132.259,
				157.794,
				55.451,
				189.39,
				158.791,
				201.223,
				0,
				175.817
			}; // Rabat
			distances[7] = new double[] {
				182.691,
				331.976,
				126.268,
				364.043,
				333.554,
				126.024,
				175.817,
				0
			}; // Beni-Mellal
		}

		public static IReadOnlyList<City> Cities => cities;

		public static int GetDistance(City city1, City city2)
		{
			return (int)distances[cities.IndexOf(city1)][cities.IndexOf(city2)];
		}
	}
}