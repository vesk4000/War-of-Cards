using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Card
{
	int n, m;

	public Card(int n, int m)
	{
		this.n = n;
		this.m = m;
	}

	public void ShowCard()
	{
		switch (n)
		{
			case 7: Console.Write("Seven"); break;
			case 8: Console.Write("Eight"); break;
			case 9: Console.Write("Nine"); break;
			case 10: Console.Write("Ten"); break;
			case 11: Console.Write("Jack"); break;
			case 12: Console.Write("Queen"); break;
			case 13: Console.Write("King"); break;
			case 14: Console.Write("Ace"); break;
		}

		Console.Write(" of ");

		switch (m)
		{
			case 1: Console.WriteLine("spades"); break;
			case 2: Console.WriteLine("clubs"); break;
			case 3: Console.WriteLine("diamonds"); break;
			case 4: Console.WriteLine("hearts"); break;
		}
	}
	public int BetterCardThan(Card other)
	{
		if (n > other.n)
		{
			Console.WriteLine("First player wins!");

			return 1;
		}
		else if (n < other.n)
		{
			Console.WriteLine("Second player wins!");

			return -1;
		}
		else
		{
			Console.WriteLine("War!!!");
			return 0;
		}
	}
}