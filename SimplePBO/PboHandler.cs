using System.IO;
using Mac.Arma.Files;

namespace Beowulf.SimplePBO
{
    public static class PboHandler
    {
        /// <summary>
        /// Creates and writes a PBO from a given folder
        /// </summary>
        /// <param name="input">Folder to create from</param>
        public static bool CreateAndWritePbo(DirectoryInfo input)
        {
            return CreateAndWritePbo(input, input.Parent);
        }

        /// <summary>
        /// Creates and writes a PBO from a folder to the given output
        /// </summary>
        /// <param name="input">Folder to create from</param>
        /// <param name="output">Folder to output ot</param>
        public static bool CreateAndWritePbo(DirectoryInfo input, DirectoryInfo output)
        {
            PboFile pbo = CreatePboFromFolder(input);
            pbo.WriteAsPboIn(output.FullName);
            return File.Exists(Path.Combine(output.FullName,pbo.FileName));
        }

        /// <summary>
        /// Creates a PBO from a folder
        /// </summary>
        /// <param name="input">Folder to create from</param>
        /// <returns></returns>
        public static PboFile CreatePboFromFolder(DirectoryInfo input)
        {
            var pbo = new PboFile();

            foreach (FileInfo f in input.EnumerateFiles("*.*", SearchOption.AllDirectories))
            {
                string path = f.FullName.Replace(input.FullName, "").TrimStart('\\');
                if (!path.StartsWith(".git"))
                {
                    var entry = new PboEntry(path, f.FullName);
                    entry.Path = entry.Path.Replace('/', '\\'); // Fix for building PBOs on Linux
                    if (entry.Path.StartsWith(@"\"))
                    {
                        // Further fix for linux
                        entry.Path = entry.Path.TrimStart('\\');
                    }
                    pbo.Add(entry);
                }

            }
            pbo.FileName = input.Name;
            pbo.MissionName = input.Name;
            return pbo;
        }

        /// <summary>
        /// Unpacks a PBO into a given folder
        /// </summary>
        /// <param name="pbo">Path to PBO</param>
        /// <param name="output">Path to unpack in</param>
        public static void UnPackPbo(FileInfo pbo, DirectoryInfo output)
        {
            if (!pbo.Exists) return;

            PboFile.FromPbo(pbo.FullName).ExtractTo(output.FullName);
        }
        /// <summary>
        /// Unpacks a PBO
        /// </summary>
        /// <param name="pbo">Path to PBO</param>
        public static void UnPackPbo(FileInfo pbo)
        {
            UnPackPbo(pbo, pbo.Directory);
        }
    }
}