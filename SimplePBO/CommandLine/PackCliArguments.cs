using EntryPoint;

namespace Beowulf.SimplePBO.CommandLine
{
    public class PackCliArguments : BaseCliArguments
    {
        public PackCliArguments() : base("Pack PBO") { }

        [Required]
        [Operand(Position:1)]
        [Help("Input Folder")]
        public string InputFolder { get; set; }

        [Operand(Position: 2)]
        [Help("Output Folder")]
        public string OutputFolder { get; set; }
    }
}