using System.Reflection;

namespace Dna.Tool.Services
{
	internal class VersionService
	{
		public string GetToolVersion()
		{
			string version = Assembly.GetExecutingAssembly()?.GetName()?.Version?.ToString() ?? "Unknown";
			return version;
		}
	}	
}
