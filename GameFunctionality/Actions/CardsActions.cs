/*
 * Created by SharpDevelop.
 * User: zala2
 * Date: 10/27/2020
 * Time: 10:29 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace Cards.GameFunctionality.Actions
{
	/// <summary>
	/// Description of CardsActions.
	/// </summary>
	public class CardsActions
	{
		private Queue<Card> player1 = new Queue<Card>(), computer = new Queue<Card>();
		
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
		
		public static void ShuffleCards()
		{
			Random rand = new Random();

			int randomCard;
			
			int player1Cards = 0;
			
			for (int i = 0; i < 16; i++)
			{
				if (rand.Next(0,2) == 0 && player1Cards != 16)
				{
					player1.Enqueue(new Card(7 + i % 8, 1 + i / 8));
					
					player1Cards ++;
				}
				else
					computer.Enqueue(new Card(7 + i % 8, 1 + i / 8));
			}
			for (int i = 31; i > 15; i ++)
			{
				if (rand.Next(0,2) == 0 && player1Cards != 16 || player1Cards == i-15)
				{
					player1.Enqueue(new Card(7 + i % 8, 1 + i / 8));
					
					player1Cards ++;
				}
				else
					computer.Enqueue(new Card(7 + i % 8, 1 + i / 8));
			}
		}
	}
}
