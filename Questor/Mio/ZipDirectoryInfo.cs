using ICSharpCode.SharpZipLib.Zip;

namespace Questor.Mio
{
    public class ZipDirectoryInfo : ZipEntryInfo
    {
        public ZipDirectoryInfo(ZipEntry entry, string name) : base(entry, name) { }
    }
}