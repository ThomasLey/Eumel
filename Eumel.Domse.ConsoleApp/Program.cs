using Eumel.ImageProcessing;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using MyNamespace;

namespace Eumel.Domse.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var foo = new Client("https://localhost:44380/", new HttpClient());
            var tsk = foo.UploadAsync(new FileParameter(File.OpenRead("Eumel.Domse.ConsoleApp.exe")));
            tsk.Wait();
            //if (string.Compare(args[0], "add", true) == 0)
            //    AddPicturesFrom(args[1]);
        }

        private static void AddPicturesFrom(string v)
        {
            DateTime dat;
            string album;

            var di = new DirectoryInfo(v);
            var name = di.Name;
            ParseName(name, out dat, out album);

            var images = Directory.GetFiles(v);

            foreach (var file in images)
            {
                var ef = new ExifWrapper(file);
                ef.AddDescription(album, dat);
            }
        }

        private static void ParseName(string name, out DateTime dat, out string album)
        {
            var parts = name.Split(new char[] { '_','-'});
            dat = new DateTime(Convert.ToInt32(parts[0]), Convert.ToInt32(parts[1]), Convert.ToInt32(parts[2]));
            album = name.Substring(11);
        }
    }
}
