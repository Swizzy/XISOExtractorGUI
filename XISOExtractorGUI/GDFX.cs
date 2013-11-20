namespace XISOExtractorGUI
{
    class GDFX
    {

    }

    internal class GDFXHeader {
        public byte[] Magic; //0x14 bytes "MICROSOFT*XBOX*MEDIA"
        public uint RootSector;
        public uint RootSize;
    }

    internal class GDFXFileEntry {
        // In the file
        public uint Unkown;
        public uint Sector;
        public uint Size;
        public byte Attributes;
        public byte NameLen;
        public string Name;
        //Extra stuff
        public string FilePath;
        public bool IsFile;
    }
}
