using System;
using System.Collections.Generic;
using System.CommandLine;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dna.Tool.Commands
{
	internal class CleanCommand : Command
	{
		public CleanCommand(string name, string? description, Command parentCommand) : base(name, description)
		{
			// Create Clean Command Options
			var cleanOptionLevel = new Option<int>(new[] { "-l", "--level" }, "This is an example Option -p CleanOptionLevel");
			var cleanOptionHard = new Option<bool>(new[] { "-h" }, "This is an example Option -p CleanOptionHard");

			// Add Options to Clean Command
			AddOption(cleanOptionLevel);
			AddOption(cleanOptionHard);

			// Set the Clean Command Handler
			//SetHandler<int, bool>(HandleCleanCommand, cleanOptionLevel, cleanOptionHard);

			this.SetHandler<int, bool>(HandleCleanCommand, cleanOptionLevel, cleanOptionHard);

			//parentCommand.AddCommand(this);
		}

		private void HandleCleanCommand(int level, bool hard)
		{
			Console.WriteLine($"HandleCleanCommand: Level Int: {level}");
			Console.WriteLine($"HandleCleanCommand: hardBool: {hard}");
			//Console.WriteLine($"Inside HandleRootCommand File: {fileInfo.Name}");

			if (hard)
			{
				Console.WriteLine("Performing a hard clean...");
			}
			else
			{
				Console.WriteLine("Performing a regular clean...");
			}
			//return 0;
		}
	}
}
