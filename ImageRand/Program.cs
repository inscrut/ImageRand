using System;
using System.Drawing;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace ImageRand
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter size (ex. 500x250): ");
            string[] buf;
            Size size = new Size();
            try
            {
                buf = Console.ReadLine().Split('x');
                size.Width = Convert.ToInt32(buf[0]);
                size.Height = Convert.ToInt32(buf[1]);
            }
            catch
            {
                MessageBox.Show("ERR: Неверно введен размер изображения!\r\nИспользуйте формат (пример): 100x100");
                Environment.Exit(1);
            }

            Bitmap img = new Bitmap(size.Width, size.Height);
            //Random rnd = new Random();
            for (int i = 0; i < size.Width; i++)
            {
                for (int j = 0; j < size.Height; j++)
                {
                    img.SetPixel(i, j, /*rnd.Next(0, 2) == 0 ? Color.Black : Color.Transparent*/ GenerateRandomNumber(0, 2) == 0 ? Color.Black : Color.Transparent);
                }
            }
            img.Save("maked.png", System.Drawing.Imaging.ImageFormat.Png);

            Console.WriteLine("Complete! Press any key . . .");
            Console.Read();
        }
        static int GenerateRandomNumber(int min, int max)
        {
            RNGCryptoServiceProvider c = new RNGCryptoServiceProvider();
            byte[] randomNumber = new byte[4]; // Integer 4 Byte
            c.GetBytes(randomNumber);
            int result = Math.Abs(BitConverter.ToInt32(randomNumber, 0));
            
            // Max. randomnumber Min. randomnumber
            return result % max + min;
        }
    }
}
