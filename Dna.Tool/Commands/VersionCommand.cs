using System.CommandLine;

namespace Dna.Tool.Commands
{
	internal class VersionCommand : CommandBase
	{
		public VersionCommand(string name, string? description) : base(name, description)
		{
			this.SetHandler(CommandHandler);
		}
		private async Task CommandHandler()
		{
			if (!File.Exists("dotnet.exe"))
			{
				Output.WriteLine("dotnet.exe not found, please install dotnet core runtime");
			}

			Output.WriteLine("-----------------------------------------------------------------------");
			Output.WriteLine("--------------------  DOTNET --INFO  ----------------------------------");
			Output.WriteLine("-----------------------------------------------------------------------");
			//StartProcess("dotnet.exe", "--info --verbosity diagnostics");
			await Task.Run(() => StartProcess("dotnet.exe", "--info --verbosity diagnostics"));


			Output.WriteLine("-----------------------------------------------------------------------");
			Output.WriteLine("--------------------   IPCONFIG      ----------------------------------");
			Output.WriteLine("-----------------------------------------------------------------------");			
			StartProcess("ipconfig", "");
		}
	}
}
