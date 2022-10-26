using System;
using Dolphin;

class Program
{
	static void Main(string[] args)
	{
		if (args.Length > 0)
		{
			ParseArg(args);
		}
		else
		{
			PrintHelp();
		}
		//Console.ReadKey();
	}

	static void PrintHelp()
	{
		string helpText = "" +
		"Usage: Dolphin [arguments]\n\n" +
		"arguments:\n" +
		"   --letters <file>       count AlphaNumeric\n" +
		"   --chars  <file>        count all characters\n" +
		"   --words <file>         count Words\n" +
		"   --lines <file>         count Lines\n" +
		"   <file>                 calculate all above\n"+
		"   --help                 print help\n";
		
		Console.WriteLine(helpText);
	}

	static void ParseArg(string[] args)
	{
		string[] options = {"--letters", "--chars", "--words", "--lines"};

		string Arg1 = args[0];
		// TODO fix this
		string Arg2 = "";
		if(args.Length > 1)
		{
			Arg2 = args[1];
		}

		if(Arg1 == "--help")
		{
			PrintHelp();
			return;
		}

		// Part 1 Where We only have File.
		if(File.Exists(Arg1))
		{
			FileAction file = new FileAction(Arg1);
			file.AllAction();
			return;
		}
		// Part 2 where we have Arguments and File.
		else if(options.Contains(Arg1) && File.Exists(Arg2))
		{
			FileAction file = new FileAction(Arg2);
			switch(Arg1)
			{
			case "--letters":
				file.CountAlphaN();
				break;
			case "--chars":
				file.CountChars();
				break;
			case "--words":
				file.CountWords();
				break;
			case "--lines":
				file.CountLines();
				break;
			}
		}		
		else
		{
			Console.WriteLine("Invalid Arguments!!");
			PrintHelp();
		}
	}
}