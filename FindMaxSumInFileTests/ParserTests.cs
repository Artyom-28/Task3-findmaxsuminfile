using Microsoft.VisualStudio.TestTools.UnitTesting;
using FindMaxSumInFile;
using System;
using System.Collections.Generic;
using System.Text;

namespace FindMaxSumInFile.Tests
{
	[TestClass()]
	public class ParserTests
	{
		private string NewLine = Environment.NewLine;
		private static List<int> UnCorrectNumbersRowsList;
		private static void InitializeUnCorrectNumbersRowsList()
		{
			UnCorrectNumbersRowsList = new List<int>();
			UnCorrectNumbersRowsList.Add(1);
			UnCorrectNumbersRowsList.Add(3);
		}


		[TestMethod()]
		public void GetNumberRowWithMaxSumTest()
		{
			string dataStr = $@"1,2.08,3{NewLine}2,1,-1{NewLine}3,f,-9";
			Parser p = new Parser(dataStr);
			int actual = p.GetNumberRowWithMaxSum();
			int expected = 1;

			Assert.AreEqual(actual: actual, expected: expected);
		}


		[TestMethod()]
		public void GetNumberRowWithMaxSumTest1()
		{
			InitializeUnCorrectNumbersRowsList();
			string dataStr = $@",10,8,-7{NewLine}2,1,-1{NewLine}3,3.14,0o";
			Parser p = new Parser(dataStr);
			List<int> actual = p.GetNumbersUncorrectRows();

			CollectionAssert.AreEqual(actual: actual, expected: UnCorrectNumbersRowsList);
		}
	}
}