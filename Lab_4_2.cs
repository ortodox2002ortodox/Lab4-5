using System;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;

namespace Lab_4_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"((.jmp)|(.gif)|(.png)|(.jpeg)|(.bmp))$";
            string path;
            Console.Write("Please enter path to folder: ");
            path = Console.ReadLine();
            var files = Directory.GetFiles(path);
            foreach (var file in files)
            {
                if (Regex.IsMatch(file, regex))
                {
                    Image img = Bitmap.FromFile(file);
                    img.RotateFlip(RotateFlipType.Rotate180FlipY);
                    img.Save(Regex.Replace(file, regex, "") + "-mirrored.gif");
                }
            }
        }
    }
}