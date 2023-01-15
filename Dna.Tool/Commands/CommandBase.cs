using System.CommandLine;
using System.Diagnostics;
using System.Text;

namespace Dna.Tool.Commands
{
	public class CommandBase : Command
	{
		public CommandBase(string name, string? description): base(name, description)
		{		
		}
		public void StartProcess(string fileName, string arguments = "")
		{		
			Process exe = new Process();
			exe.StartInfo.FileName = fileName;
			exe.StartInfo.UseShellExecute = false;
			exe.StartInfo.Arguments = arguments;
			exe.StartInfo.RedirectStandardOutput = true;
			//exe.OutputDataReceived += new DataReceivedEventHandler(( s, e) => {
			//	Console.WriteLine(e.Data);
			//});
			exe.Start();
			StringBuilder builder = new StringBuilder();
			builder.Append(exe.StandardOutput.ReadToEnd());
			Output.WriteLine(builder.ToString());			
		}	
	}
}
