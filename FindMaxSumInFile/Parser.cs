using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FindMaxSumInFile
{
	public class Parser
	{
		private Dictionary<int, double> CorrectStringsInfo { get; set; }
		private Dictionary<int, string> UnCorrectStringsInfo { get; set; }
		public Parser(string dataStr)
		{
			CorrectStringsInfo = new Dictionary<int, double>();
			UnCorrectStringsInfo = new Dictionary<int, string>();

			var rows = dataStr.Split(Environment.NewLine);
			for (int indexRow = 0; indexRow < rows.Length; indexRow++)
			{
				bool defectStringFlag = false;
				double sum = 0;
				var numbersStr = rows[indexRow].Split(',');

				foreach (var numberStr in numbersStr)
				{
					double number = 0;
					double.TryParse(numberStr.Replace('.',','), out number);
					if(number == 0)
					{
						if (string.IsNullOrEmpty(numberStr) || numberStr.ToCharArray().Where(e => !Char.IsDigit(e)).Count() > 0)
						{
							defectStringFlag = true;
							string uncorrectValue = (!string.IsNullOrEmpty(rows[indexRow]) && string.IsNullOrEmpty(numberStr) ? "," : numberStr);
							UnCorrectStringsInfo.Add(key: indexRow + 1, value: uncorrectValue);
							break;
						}
					}
					sum += number;
				}
				
				if (!defectStringFlag) 
				{ 
					CorrectStringsInfo.Add(key: indexRow + 1, value: sum); 
				}
			}
		}


		public int GetNumberRowWithMaxSum()
		{
			int numberRowWithMaxSum = 0;
			if(CorrectStringsInfo != null && CorrectStringsInfo.Count() > 0)
			{
				double maxValue = CorrectStringsInfo.Select(e => e.Value).Max();
				numberRowWithMaxSum = CorrectStringsInfo.FirstOrDefault(e => e.Value == maxValue).Key;
			}
			
			return numberRowWithMaxSum;
		}


		public List<int> GetNumbersUncorrectRows()
		{
			return UnCorrectStringsInfo == null ? new List<int>() : UnCorrectStringsInfo.Select(e => e.Key).ToList();
		}
	}
}
