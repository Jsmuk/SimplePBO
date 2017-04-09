using EntryPoint;

namespace Beowulf.SimplePBO
{
    class Program
    {
        static void Main(string[] args)
        {
            Cli.Execute<CliCommands>(args);
        }
    }
}