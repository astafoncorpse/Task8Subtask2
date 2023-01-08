using System;
using System.IO;
using System.Linq;

namespace FileScaner
{
    class Program
    {
        static void Main(string[] args)
        {
            DriveInfo[] drivers = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drivers.Where(d => d.DriveType == DriveType.Fixed))
            {
                WriteDriveInfo(drive);
                DirectoryInfo root = drive.RootDirectory;
                var folders = root.GetDirectories();

                WriteFileInfo(root);
                WriteFolderInfo(folders);


                Console.WriteLine();
                Console.WriteLine();
            }
        }
        public static void WriteDriveInfo(DriveInfo drive)
        {
            Console.WriteLine($"Название: {drive.Name}");
            Console.WriteLine($"Тип: {drive.DriveType}");
            if (drive.IsReady)
            {
                Console.WriteLine($"Oбъём: {drive.TotalSize}");
                Console.WriteLine($"Свободно: {drive.TotalFreeSpace}");
                Console.WriteLine($"Метка: {drive.VolumeLabel}");

            }
        }
        public static void WriteFolderInfo(DirectoryInfo[] folders)
        {
            Console.WriteLine();
            Console.WriteLine("Папки: ");
            Console.WriteLine();

            foreach (var folder in folders)
            {
                try
                {
                    Console.WriteLine(folder.Name + $"{DirectoryExtention.DirSize(folder)}байт");
                }
                catch (Exception e)
                {

                    Console.WriteLine(folder.Name + $"Не удалось рассчитать размер: {e.Message}");
                }

            }


        }
        public static void WriteFileInfo(DirectoryInfo rootFolder)
        {
            Console.WriteLine();
            Console.WriteLine("Файлы: ");
            Console.WriteLine();

            foreach (var file in rootFolder.GetFiles())
            {
                Console.WriteLine(file.Name + $"{file.Length}байт");
            }
        }
    }
}
