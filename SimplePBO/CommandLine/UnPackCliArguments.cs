using EntryPoint;

namespace Beowulf.SimplePBO.CommandLine
{
    public class UnPackCliArguments : BaseCliArguments
    {
        public UnPackCliArguments() : base("Unpack PBO") { }

        [Required]
        [Operand(Position: 1)]
        [Help("Input File")]
        public string InputFile { get; set; }

        [Operand(Position: 2)]
        [Help("Output Folder")]
        public string OutputFolder { get; set; }
    }
}