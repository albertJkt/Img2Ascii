using System.IO;
using System.Drawing;
using System;

namespace IMG_TO_ASCII
{
    class Program
    {
        private static string imgLocation;
        private static string pixels = " .-+*wGHM#&%";
        private static string saveLocation;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the IMG TO ASCII App :)");
            Console.WriteLine("Please, enter path to the image: \n");
            imgLocation = Console.ReadLine();
            Console.WriteLine("Please, enter path where ASCII file should be saved: \n");
            saveLocation =  Console.ReadLine();
            try
            {
                ConvertPixelsToAscii();
                Console.WriteLine("Image was succesfully converted into ASCII symbols");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        public static void ConvertPixelsToAscii()
        {
            var img = new Bitmap(imgLocation);
            using (var writer = new StreamWriter(saveLocation))
            {
                for (var x=0; x < img.Height; x++)
                {
                    for (var y = 0; y<img.Width; y++ )
                    {
                        var color = img.GetPixel(y,x);
                        var brightness = Brightness(color);
                        var index = brightness / 255 * (pixels.Length - 1);
                        var pixel = pixels[pixels.Length - (int)Math.Round(index) -1 ];
                        writer.Write(pixel);
                    }
                    writer.WriteLine();
                }
            }
        }
        private static double Brightness(Color c)
        {
            return Math.Sqrt(
               c.R * c.R * .241 +
               c.G * c.G * .691 +
               c.B * c.B * .068);
        }

    }
}
