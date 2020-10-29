using System;
using System.Collections.Generic;

static class Program
{	
	public static void Main(string[] args)
	{
		Console.WriteLine("Welcome to War of Cards!");
		Console.WriteLine("Type help to see the list of commands.");
		while(true) {
			string command = Console.ReadLine();
			if (command.get_name() == "exit" || command.get_name() == "quit")
				return;
			switch (command.get_name()) {
				case "help":
					Commands.Help(command.get_args());
				break;
				case "start":
					Commands.Start(command.get_args());
				break;
				case "clear":
					Console.Clear();
				break;
				default:
					ConsoleColor old_console_color = Console.ForegroundColor;
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine(command.get_name() + " - " + "No such command exists!");
					Console.ForegroundColor = old_console_color;
					Console.WriteLine();
				break;
			}
		}
	}
}


public static class Commands {
	public static Dictionary<string, string> help_db = new Dictionary<string, string>() {
		{"help",
			"Shows the list of possible commands\n" +
			"Optional Flags:\n" +
			"Every possible command is a flag, which when given will print the full description of that command."},
		{"start", "Starts a new game"},
		{"exit", "Closes the program"},
		{"quit", "Closes the program"},
		{"clear", "Clears the console window"}
	};
	public static void Help(string[] args) {
		if (args.Length > 0) {
			foreach (string arg in args) {
				if (help_db.ContainsKey(arg))
				{
					Console.WriteLine(arg + " - " + help_db[arg]);
				}
				else {
					ConsoleColor old_console_color = Console.ForegroundColor;
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine(arg + " - " + "No such command exists!");
					Console.ForegroundColor = old_console_color;
				}
				Console.WriteLine();
			}
			return;
		}

		Console.WriteLine("List of possible commands:");
		Console.WriteLine("help - Show this list of commands");
		Console.WriteLine("help [command] - Show full description of a specific command");
		Console.WriteLine("start - Start a new game");
		Console.WriteLine("clear - Clear the console window");
		Console.WriteLine("quit/exit - Exit the program");
		Console.WriteLine();
	}

	public static void Start(string[] args) {
		Ico.StartGame();
	}
}


public static class Extentions {
	public static string[] get_words(this string s) {
		return s.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
	}

	public static string[] get_args(this string s) {
		return s.get_words().delete(0);
	}

	public static string get_name(this string s) {
		if (s.get_words().Length == 0)
			return "";
		return s.get_words()[0].ToLower();
	}

	public static T[] delete<T>(this T[] a, int index) {
		if (index >= a.Length || index < 0)
			return new T[0];
		T[] ans = new T[a.Length - 1];
		for (int i = 0; i < index; i++) {
			ans[i] = a[i];
		}
		for (int i = index; i < ans.Length; i++) {
			ans[i] = a[i + 1];
		}
		return ans;
	}
}