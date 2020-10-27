/*
 * Created by SharpDevelop.
 * User: zala1
 * Date: 10/26/2020
 * Time: 9:13 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace Cards
{	
	class Card 
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
			
			switch(m)
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
	
	class Program
	{
		static Queue<Card> player1 = new Queue<Card>(), computer = new Queue<Card>();
		
		public static void Battle(Card currentPlayerCard, Card currentComputerCard, Queue<Card> cardsForWinner)
		{
			Console.Write("Your Card: "); currentPlayerCard.ShowCard();
			Console.Write("Computer's Card: "); currentComputerCard.ShowCard();
			
			int battleResult = currentPlayerCard.BetterCardThan(currentComputerCard);
			Card[] last3PlayerCards = new Card[3], last3ComputerCards = new Card[3];
			
			if (battleResult == 1)
			{
				player1.Enqueue(currentPlayerCard);
				player1.Enqueue(currentComputerCard);
			}
			else if (battleResult == -1)
			{
				computer.Enqueue(currentComputerCard);
				computer.Enqueue(currentPlayerCard);
			}
			else
			{
				for (int i = 0; i < 3; i++)
				{
					cardsForWinner.Enqueue(player1.Peek());
					last3PlayerCards[i] = player1.Dequeue();
				}
				
				for (int i = 0; i < 3; i++)
				{
					cardsForWinner.Enqueue(computer.Peek());
					last3ComputerCards[i] = computer.Dequeue();
				}
				
				Battle(last3PlayerCards[2], last3ComputerCards[2]);
			}
			
			return;
		}
		
		public static void Main(string[] args)
		{
			Random rand = new Random();

			int randomCard;
			
			int player1Cards = 0;
			
			for (int i = 0; i < 32; i++)
			{
				if (rand.Next(0,2) == 0 && player1Cards != 16)
				{
					player1.Enqueue(new Card(7 + i % 8, 1 + i / 8));
					
					player1Cards ++;
				}
				else
					computer.Enqueue(new Card(7 + i % 8, 1 + i / 8));
			}
			
			Card currentPlayerCard, currentComputerCard;
			
			while (player1.Count != 0 && computer.Count != 0)
			{
				currentPlayerCard = player1.Dequeue();
				currentComputerCard = computer.Dequeue();
				
				Console.ReadLine();
				
				Battle(currentPlayerCard, currentComputerCard);
			}
				
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}