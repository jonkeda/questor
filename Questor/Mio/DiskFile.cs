using System.Diagnostics;
using System.IO;
using System.Windows.Media;
using Questor.Extensions;

namespace Questor.Mio
{
    public class DiskFile : VirtualFile
    {
        public DiskPath DiskPath { get; }

        public DiskFile()
        { }

        public DiskFile(string filename)
            : base(filename, System.IO.Path.GetFileName(filename))
        { }

        public DiskFile(DiskPath diskPath, string path, string name)
            : base(path, name)
        {
            DiskPath = diskPath;
        }

        public DiskFile(DiskPath diskPath, string filename)
            : base(filename, System.IO.Path.GetFileName(filename))
        {
            DiskPath = diskPath;
        }

        public DiskFile(DiskPath diskPath, FileData file)
            : base(file.Path, file.Name)
        {
            DiskPath = diskPath;
            LastWriteTime = file.LastWriteTime;
        }

//        public DiskFile(DiskPath diskPath, FileInfo file)
//            : base(file.FullName, file.Label)
//        {
//            DiskPath = diskPath;
//            LastWriteTime = file.LastWriteTime;
//        }

        public override VirtualPath Directory
        {
            get { return new DiskPath(System.IO.Path.GetDirectoryName(Path)); }
        }

        public override VirtualFileKind Kind { get { return VirtualFileKind.Disk; } }

        public override Stream OpenRead()
        {
            return File.OpenRead(Path);
        }

        public override Stream OpenWrite()
        {
            return File.OpenWrite(Path);
        }

        public override VirtualFile ChangeExtension(string oldExtension, string newExtension)
        {
            string fullname = Path.Replace(oldExtension, newExtension);

            return DiskPath.GetFile(fullname);
        }

        public override void Delete()
        {
            File.Delete(Path);
        }

        public override VirtualFile Copy(VirtualPath fromFolder, VirtualPath toFolder, bool overwrite)
        {
            int l = fromFolder.Path.Length;
            string filename = Path.Substring(l).TrimStart('/', '\\');
            VirtualFile tofile = toFolder.CombineToFile(filename);
            return Copy(tofile, overwrite);
        }

        public override VirtualFile Copy(VirtualFile tofile, bool overwrite)
        {
            FileEx.Copy(Path, tofile.Path, overwrite);
            return tofile;
        }

        public override VirtualFile GetNetworkPath()
        {
            string networkPath = W32FileHelpers.GetNetworkPath(Path);

            return new DiskFile(DiskPath, networkPath);
        }

        public override bool Exists()
        {
            return File.Exists(Path);
        }

        public override string ReadAllText()
        {
            return FileEx.ReadAllText(Path);
        }

        public override void WriteAllText(string contents)
        {
            File.WriteAllText(Path, contents);
        }

        public override void StartProcess()
        {
            Process.Start(Path);
        }

        private static readonly ImageSourceConverter Converter = new ImageSourceConverter();

        public override ImageSource ToImageSource()
        {
            return Converter.ConvertFrom(Path) as ImageSource;            
        }
    }
}