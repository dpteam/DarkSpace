using System;
using System.Collections.Generic;
using System.Text;

namespace DarkSpace.Helpers
{
	internal static class RandomHelper
	{
		private static System.Random r;

		public static int NextNumber()
		{
			if (r == null)
				Seed();

			return r.Next();
		}

		public static int NextNumber(int ceiling)
		{
			if (r == null)
				Seed();

			return r.Next(ceiling);
		}

		public static void Seed()
		{
			r = new System.Random();
		}

		public static void Seed(int seed)
		{
			r = new System.Random(seed);
		}
	}
}
