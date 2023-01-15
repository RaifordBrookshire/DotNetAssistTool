using Dna.Tool.Commands;

namespace Dna.Tool.Tests
{
	public class CommandBaseTests
	{
		[Fact]
		public void StartProcess_Usage()
		{
			CommandBase command = new CommandBase("test", "test");

			command.StartProcess("dir");

		}
	}
}