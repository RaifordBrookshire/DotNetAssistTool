using Dna.Tool.Commands;

namespace Dna.Tool
{
	internal class Program
	{
		async static Task<int> Main(string[] args)
		{
			Output.WriteLine("Starting Tools...");

			MyRootCommand rootCommand = new MyRootCommand();
			rootCommand.AddCommand(new CleanCommand("clean", "shor tsec", rootCommand));
			rootCommand.AddCommand(new VersionCommand("version", "The Version of .net components"));
			return await rootCommand.InvokeAsync(args);
		}	
	}
}