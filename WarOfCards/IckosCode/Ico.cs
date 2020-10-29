using System;


public static class Ico
{
	public static void StartGame() {
		Console.WriteLine("Another game of WAR");
		Console.WriteLine();
	}
}

// Code dump from Ico's original code
/*Random rand = new Random();
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
		}*/
/*static Queue<Card> player1 = new Queue<Card>(), computer = new Queue<Card>();

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

		//Battle(last3PlayerCards[2], last3ComputerCards[2]);
	}

	return;
}*/