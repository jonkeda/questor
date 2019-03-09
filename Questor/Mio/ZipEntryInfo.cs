﻿using ICSharpCode.SharpZipLib.Zip;

namespace Questor.Mio
{
    public class ZipEntryInfo
    {
        public string Name { get; }
        public ZipEntry Entry { get; }

        public ZipEntryInfo(ZipEntry entry, string name)
        {
            Entry = entry;
            Name = name;
        }
    }
}