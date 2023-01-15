
namespace Dna.Tool.Commands
{
	internal class MyRootCommand : RootCommand
	{
		public MyRootCommand() : base("My New Root Command in Commands/this command")
		{
			//var projectOption = new Option<string>(new[] { "-p", "--project" }, "This is an example Option -p ProjectOption");
			//projectOption.SetDefaultValue("not set value");			
			//var fileOption = new Option<FileInfo>(new[] { "-f", "--file" }, "This is an example Option -f fileOption");
			//var option = new Option<bool>(new[] { "-o", "--option" }, "This is an example Option");
			//var boolOption = new Option<bool>(new[] { "-b", "--bool" }, "This is an example bool Option");
			//var argument = new Argument<string>("-arg | --argument");

			// Create Options
			var versionOption = new Option<bool>(new[] { "-z", "--zersion" }, "Shows the version info for .Net Components");
			
			// Add Options
			AddOption(versionOption);

			// Create Handler
			this.SetHandler<bool>(CommandHandler, versionOption);

		}

		private void CommandHandler(bool version)
		{
			string output = "Welcome to Dot Net Assistant";
			
			if(version)
			{
				output = "1.2.1.1.1";
			}

			Console.WriteLine(output);
		}
	}
}
