using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ionic.Zip;
using System.IO;

namespace ConsoleAppFileBackup
{
    class Program
    {
        int globalCount;

        static void Main(string[] args)
        {
            Program program = new Program();
            string backupFile = string.Empty;
            string outputFile = string.Empty;

            backupFile = @"Backup File Path";
            outputFile = @"OutPut File Path";


            program.zipFile(backupFile, outputFile);
        }

        /// <summary>
        /// Klasörü ve altında ki tüm dosyları zipler.
        /// </summary>
        /// <param name="_filePath"></param>
        /// <param name="_outputFilePath"></param>
        public void zipFile(string _filePath, string _outputFilePath)
        {
            string day, month, year;

            day = DateTime.UtcNow.Day.ToString();
            month = DateTime.UtcNow.Month.ToString();
            year = DateTime.UtcNow.Year.ToString();

            try
            {
                if (_outputFilePath != "")
                {
                    globalCount = 0;

                    //Klasör altında ki dosyaları listeler
                    DirectoryInfo dirInfoFile = new DirectoryInfo(_outputFilePath);
                    FileInfo[] files = dirInfoFile.GetFiles();

                    foreach (FileInfo fi in files)
                    {
                        globalCount++;
                    }
                }

                ZipFile zip = new ZipFile();
                zip.AddItem(_filePath);
                globalCount += 1;
                FileStream fs = File.Create(_outputFilePath + "\\" + day + "-" + month + "-" + year + "- BackupFile-" + globalCount + ".zip");
                fs.Close();

                zip.Save(_outputFilePath + "\\" + day +"-" + month + "-"+ year + "- BackupFile-" + globalCount + ".zip");

                Console.Write("Sıkıştırma işlemi başarılı.");
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }
    }
}
