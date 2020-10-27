/*
 * Created by SharpDevelop.
 * User: zala2
 * Date: 10/26/2020
 * Time: 9:36 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
static class Program
{
	public static void PrintHelp(string[] command) {
		Console.WriteLine("List of possible commands:");
		Console.WriteLine("help - Show this list of commands");
		Console.WriteLine("stop - Exit the program");
	}
	
	public static void Start(string[] args) {
		foreach(string arg in args) {
			if(arg.IndexOf('=') != -1) {
				string[] carg = arg.Split(' ');
				if(carg.Length() != 2) {
					Console.WriteLine();
				}
			}
			else {
				
			}
		}
	}
	
	public static void Main(string[] args)
	{
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