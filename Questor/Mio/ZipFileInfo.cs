using ICSharpCode.SharpZipLib.Zip;

namespace Questor.Mio
{
    public class ZipFileInfo : ZipEntryInfo
    {
        public ZipFileInfo(ZipEntry entry, string name) : base(entry, name) { }
    }
}