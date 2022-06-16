using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Attributes;

namespace Mod12
{
    public class Testing
    {
		[Benchmark]
		public void CreateMatrix()
		{
			int n = 10000;

			var matrix = new int[n][];

			for (int i = 0; i < n; i++)
			{
				matrix[i] = new int[n];
			}

			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < n; j++)
				{
					matrix[i][j] = i + j;
				}
			}
		}
	}
}
