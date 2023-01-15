using System.Diagnostics;

namespace Dna.Tool.Common
{
    internal class Utils
    {
        static public void DeleteAllFilesAndDirectories(List<FileInfo> files, List<DirectoryInfo> directories, bool recursiveDirectories = false)
        {
            List<string> f = files.ConvertAll(file => file.FullName);
            List<string> d = directories.ConvertAll(directory => directory.FullName);

            DeleteAllFilesAndDirectories(f, d, recursiveDirectories);
        }


        static public void DeleteAllFilesAndDirectories(List<string> files, List<string> directories, bool recursiveDirectories = false)
        {
            try
            {
                // Remove files first
                foreach (string fileName in files)
                {

                    try
                    {
                        File.Delete(fileName);
                    }
                    catch (Exception exception)
                    {
                        Debug.WriteLine(exception.Message);
                    }
                }

                // Now the directories
                foreach (string directoryName in directories)
                {
                    try
                    {
                        Directory.Delete(directoryName, recursiveDirectories);
                    }
                    catch (Exception exception)
                    {
                        Debug.WriteLine(exception.Message);
                    }
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
            }
        }


    }
}
