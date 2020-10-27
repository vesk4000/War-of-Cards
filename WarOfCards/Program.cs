using System;
using System.Collections.Generic;


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
static class Program
{
	
		
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
	
  public static void PrintHelp(string[] command) {
		Console.WriteLine("List of possible commands:");
		Console.WriteLine("help - Show this list of commands");
		Console.WriteLine("stop - Exit the program");
	}
	
	public static void Start(string[] args) {
		foreach(string arg in args) {
        if(arg.IndexOf('=') != -1) {}}}
  
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
    //Ico
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
    //End Ico
		Console.WriteLine("Welcome to War of Cards!");
		Console.WriteLine("Type help to see the list of commands.");
		string command = "";
		while((command = Console.ReadLine().ToLower()) != "stop") {
			switch(command.get_args()[0]) {
				case "help":
					PrintHelp(command.get_args());
				break;
				case "start":
					string[] cmd = command.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
					foreach(string arg in cmd) {
						Console.WriteLine(arg);
					}
				break;
			}
		}
		
		/*Console.Write("Press any key to continue . . . ");
		Console.ReadKey(true);*/
	}
	
	public static string[] get_args(this string s) {
		return s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
	}
}