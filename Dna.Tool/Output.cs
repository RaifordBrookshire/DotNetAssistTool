namespace Dna.Tool
{
	static public class Output
	{
		static public void WriteLine(string output)
		{
			Console.WriteLine(output);
			#if DEBUG
			Trace.WriteLine(output);
			Debug.WriteLine(output);
			#endif

		}
	}
}
