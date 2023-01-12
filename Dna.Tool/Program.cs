

using Dna.Tool.Commands;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Diagnostics;
using System.IO;
using System.Net.Security;

namespace Dna.Tool
{
	internal class Program
	{
		async static Task<int> Main(string[] args)
		{
			var projectOption = new Option<string>(new[] { "-p", "--project" }, "This is an example Option -p ProjectOption");
			var fileOption = new Option<FileInfo>(new[] { "-f", "--file" }, "This is an example Option -f fileOption");
			var option = new Option<bool>(new[] { "-o", "--option" }, "This is an example Option");
			var boolOption = new Option<bool>(new[] { "-b", "--bool" }, "This is an example bool Option");
			var argument = new Argument<string>("-arg | --argument");

			projectOption.SetDefaultValue("not set value");

			//var rootCommand = new RootCommand("dna")
			//{
			//	//fileOption,
			//	//boolOption,
			//	//projectOption
			//	//option
			//	//new Option<int>(new[]{ "-o", "--option" }, "This is an example Option" )

			//};


			RootCommand rootCommand = new RootCommand();
			rootCommand.AddCommand(new CleanCommand("clean", "shor tsec", rootCommand));



			return await rootCommand.InvokeAsync(args);

			//Console.WriteLine("Hello, World!");
		}

		private static void HandleRootCommand(FileInfo fileInfo, bool version, string project)
		{
			Console.WriteLine($"Inside HandleRootCommand Project: {project}");
			Console.WriteLine($"Inside HandleRootCommand File: {fileInfo.Name}");
			Console.WriteLine($"Inside HandleRootCommand Version: {version}");
			if (true)
			{
				Console.WriteLine("v1.0.0");
			}
			//return 0;
		}
		private static void HandleRootCommand2(bool version, FileInfo fileInfo)
		{
			Console.WriteLine("Inside Handle Root Command");
			if (version)
			{
				Console.WriteLine("v1.0.0");
			}
			//return 0;
		}

		private static void HandleCleanCommand(int level, bool hard)
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

		private static int HandleDumpCommand()
		{
			Console.WriteLine("Dumping current state...");
			return 0;
		}
	}
}