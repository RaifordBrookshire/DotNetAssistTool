using System.CommandLine;

namespace Dna.Tool.Commands
{
	internal class CleanCommand : CommandBase
	{
		public CleanCommand(string name, string? description, Command parentCommand) : base(name, description)
		{
			// Create Clean Command Options
			var cleanOptionLevel = new Option<int>(new[] { "-l", "--level" }, "This is an example Option -p CleanOptionLevel");
			var cleanOptionHard = new Option<bool>(new[] { "-h" }, "This is an example Option -p CleanOptionHard");
			var noPromptOption = new Option<bool>(new[] { "--no-prompt" }, "Prevents a prompt before executing.");
			var rootFolderOption = new Option<FileInfo?>(new[] { "--root-folder" }, "The root folder you want to clean. Default is the working directory.");

			// Add Options to Clean Command
			AddOption(cleanOptionLevel);
			AddOption(cleanOptionHard);
			AddOption(noPromptOption);
			AddOption(rootFolderOption);	

			// Add Sub Command
			AddCommand(new CleanAllSubCommand("all", "clean ALL of the stuff"));

			// Set the Clean Command Handler
			this.SetHandler<int, bool, bool, FileInfo>(CommandHandler, cleanOptionLevel, cleanOptionHard, noPromptOption, rootFolderOption);
		}

		private void CommandHandler(int level, bool hard, bool noPrompt, FileInfo? rootFolder)
		{
			Output.WriteLine("-----------------------------------------------------------------------");
			Output.WriteLine("--------------------   Cleaning Folders -------------------------------");
			Output.WriteLine("-----------------------------------------------------------------------");

			string rootPath;

			if (rootFolder != null)
			{
				rootPath = Path.GetDirectoryName(rootFolder.FullName);
				Output.WriteLine($"Processing Folder: {rootPath}");

				if (!Directory.Exists(rootPath))
				{
					Output.WriteLine($"Path does not exist {rootPath}...Defaulting to working directory");
					rootPath = Directory.GetCurrentDirectory();
					Output.WriteLine($"Root path reset to {rootPath}");
				}
			}
			else
			{
				rootPath = Directory.GetCurrentDirectory();
			}
			// This is here when you need to debug in the ide
			//	rootPath = "C:\\temp\\temp";

			Output.WriteLine($"Removing bin / obj files from  {rootPath} ...");
			StartProcess("powershell", $"Get-ChildItem -Path '{rootPath}' -Recurse -Force -Include bin, obj -Directory | Remove-Item -Recurse -Force -Verbose");
		
			if (hard)
			{
				// Add code here to a hard clean	
				// this Could remove the .vs file for example	
			}

			Output.WriteLine("Cleaning Process Complete.");
		}
	}
}
