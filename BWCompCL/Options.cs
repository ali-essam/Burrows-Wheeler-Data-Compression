using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using CommandLine.Text;

namespace BWCompCL
{
    class Options
    {
        [Option('a', null, HelpText = "Add files to archive", MutuallyExclusiveSet = "Add")]
        public bool AddToArchive { get; set; }

        [Option('e', null, HelpText = "Extract files from archive", MutuallyExclusiveSet = "Extract")]
        public bool ExtractFromArchive { get; set; }

        [ValueOption(0)]
        public string ArchivePath { get; set; }

        [ValueList(typeof(List<string>))]
        public IList<string> Files { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            HelpText help = HelpText.AutoBuild(this,
                (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
            help.AddPreOptionsLine("Sample usage:");
            help.AddPreOptionsLine("Add to archive: \"bwc.exe -a archive.bwc filename.txt\"");
            help.AddPreOptionsLine("Extract from archive: \"bwc.exe -a archive.bwc filename.txt\"");
            return help;
        }
    }
}
