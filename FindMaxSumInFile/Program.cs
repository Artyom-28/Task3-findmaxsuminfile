using System;
using System.Collections.Generic;
using System.IO;

namespace FindMaxSumInFile
{
	class Program
	{
		static void Main(string[] args)
		{
			string path = String.Empty;
			string newLine = Environment.NewLine;

			if(args.Length != 0 && !string.IsNullOrEmpty(args[0]))
			{
				path = args[0];
			}
			else
			{
				Console.Write("Enter path file: ");
				path = Console.ReadLine();
			}

			try
			{
				using (StreamReader sr = new StreamReader(path))
				{
					string fileStr = sr.ReadToEnd();
					Parser p = new Parser(fileStr);

					int numberRowWithMaxValue = p.GetNumberRowWithMaxSum();
					List<int> uncorrectRows = p.GetNumbersUncorrectRows();

					if (!string.IsNullOrEmpty(fileStr))
					{
						Console.WriteLine($"Data in file:{newLine}{newLine}{fileStr}{newLine}");
					}

					Console.WriteLine(numberRowWithMaxValue == 0 ? "Any correct rows not found" : $"Number row with Max Sum value: {numberRowWithMaxValue}");
					Console.WriteLine(uncorrectRows != null && uncorrectRows.Count > 0 ? $"Uncorrect number rows: {string.Join(", ", uncorrectRows)}" : "");
				}
			}
			catch(Exception e)
			{
				throw e;
			}
		}
	}
}
