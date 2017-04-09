using System;
using System.IO;
using Beowulf.SimplePBO.CommandLine;
using EntryPoint;

namespace Beowulf.SimplePBO
{
    public class CliCommands : BaseCliCommands
    {
        /// <summary>
        /// Packs a folder into a PBO
        /// </summary>
        /// <param name="args"></param>
        [Command("pack")]
        [Help("Packs a folder into a PBO")]
        public void Pack(string[] args)
        {
            var c = Cli.Parse<PackCliArguments>(args);

            bool result;
            if (c.OutputFolder == null)
            {
                result = PboHandler.CreateAndWritePbo(new DirectoryInfo(c.InputFolder));

            }
            else
            {
                result = PboHandler.CreateAndWritePbo(new DirectoryInfo(c.InputFolder), new DirectoryInfo(c.OutputFolder));
            }

            if (result)
            {
                Console.WriteLine("PBO created");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Failed to make PBO");
                Environment.Exit(1);
            }

        }

        [Command("unpack")]
        [Help("Unpacks a PBO into a folder")]
        public void Unpack(string[] args)
        {
            var c = Cli.Parse<UnPackCliArguments>(args);

            if (c.OutputFolder == null)
            {
                PboHandler.UnPackPbo(new FileInfo(c.InputFile));

            }
            else
            {
                PboHandler.UnPackPbo(new FileInfo(c.InputFile),new DirectoryInfo(c.OutputFolder));
            }
        }
    }
}