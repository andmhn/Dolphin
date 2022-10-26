namespace Dolphin;

class FileAction
{
	private string _fileUri;
	private string _content = "";

	public FileAction(string fileUri)
	{
		_fileUri = fileUri;
		_content = File.ReadAllText(_fileUri);
	}

	public void AllAction()
	{
		CountAlphaN();
		CountChars();
		CountWords();
		CountLines();	
	}

	public void CountAlphaN()
	{
		int counter = 0;
		foreach (char c in _content){
			if ((c >= 'A' && c <= 'Z') ||
				(c >= 'a' && c <= 'z') ||
				(c >= '0' && c <= '9'))
			{
				counter++;
			}
		}
		Console.WriteLine($"Total Letters in file {_fileUri} : {counter}");
	}

	public void CountChars()
	{
		int number = _content.Length;
		Console.WriteLine($"Total Characters in file {_fileUri} : {number}");
	}

	public void CountWords()
	{
		string[] split_text = _content.Split(' ');
		string new_text = "";

		foreach(string av in split_text)
		{
			if (av != "")
			{ 
				new_text = new_text  + av + ",";
			}
		}
		new_text = new_text.TrimEnd(',');
		split_text = new_text.Split(',');
		Console.WriteLine($"Total Words in file {_fileUri} : {split_text.Length}");
	}
	
	public void CountLines()
	{
		int counter = 0;	
		foreach(char c in _content)
		{
			if (c == '\n')
			{
				counter++;
			}
		}
		Console.WriteLine($"Total Lines in file {_fileUri} : {counter}");
	}
}