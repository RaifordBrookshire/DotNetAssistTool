using System.CommandLine.Invocation;

namespace Dna.Tool.Commands
{
	public  class CleanAllSubCommand : CommandBase
	{
		public CleanAllSubCommand(string name, string? description, Command? parentCommand = null) : base(name, description)
		{
			// We have not option in this Command
			//this.Set
			// Set the Clean Command Handler
			this.SetHandler(CommandHandler);
		}

		public void CommandHandler(InvocationContext context)
		{			
			if (context != null)
			{
				Output.WriteLine(context.ToString());
			}
			else
			{
				Output.WriteLine("Error: context is null");
			}

		}

		//private Action CommandHandler()
		//{
		//	Console.WriteLine("Inside CleanSubCommand -> CommandHandler");
		//}
	}
}
