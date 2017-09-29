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

            //Yedek alınacak dosya yolu belirtilir.Örneğin c:\Users\UserName\test
            backupFile = @"C:\Users\UserName\backupFileName";
            //Yedeğin nereye alınacağı belirtilir. Örneğin c:\Users\UserName\testOutput
            outputFile = @"C:\Users\Semih\OutPutfileName\";

            //zipleme yapılır.
            program.zipFile(backupFile, outputFile);
        }

        /// <summary>
        /// Klasörü ve altında ki tüm dosyları zipler.
        /// </summary>
        /// <param name="_filePath"></param>
        /// <param name="_outputFilePath"></param>
        public void zipFile(string _filePath, string _outputFilePath)
        {
            string day, month, year, hour, minute, second;

            day = DateTime.UtcNow.Day.ToString();
            month = DateTime.UtcNow.Month.ToString();
            year = DateTime.UtcNow.Year.ToString();
            hour = DateTime.Now.Hour.ToString();
            minute = DateTime.UtcNow.Minute.ToString();
            second = DateTime.Now.Second.ToString();

            try
            {
                //Zipleme işlemi başlatılır.
                ZipFile zip = new ZipFile();
                zip.AddItem(_filePath);
                globalCount += 1;
                FileStream fs = File.Create(_outputFilePath + "\\"
                                           + day + "-"
                                           + month + "-"
                                           + year + "-"
                                           + hour + "-"
                                           + minute + "-"
                                           + second +"- BackupFile.zip");
                fs.Close();

                zip.Save(_outputFilePath + "\\"
                        + day + "-"
                        + month + "-"
                        + year + "-"
                        + hour + "-"
                        + minute + "-"
                        + second + "- BackupFile.zip");

                Console.Write("Sıkıştırma işlemi başarılı.");
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }
    }
}
