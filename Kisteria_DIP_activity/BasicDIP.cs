using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kisteria_DIP_activity
{
    static class BasicDIP
    {
        public static void Histogram(ref Bitmap a, ref Bitmap b)
        {
            Color sample;
            Color gray;
            Byte graydata;

            //step 1: convert to grayscale
            for (int x = 0; x < a.Width; x++)
                for (int y = 0; y < a.Height; y++)
                {
                    sample = a.GetPixel(x, y);
                    graydata = (byte)((sample.R + sample.G + sample.B) / 3);
                    gray = Color.FromArgb(graydata, graydata, graydata);
                    a.SetPixel(x, y, gray);
                }

            int[] histdata = new int[256];
            
            //loop para ibutang inside sa array ang data
            for (int x = 0; x < a.Width; x++)
                for (int y = 0; y < a.Height; y++)
                {
                    sample = a.GetPixel(x, y);
                    histdata[sample.R]++;
                }

            b = new Bitmap(256, 800);
            for(int x = 0; x < 256; x++)
                for (int y = 0;y < 800; y++)
                {
                    b.SetPixel(x,y, Color.White);
                }

            //plot the points based on the data
            for (int x = 0; x < 256; x++)
                for (int y = 0; y < Math.Min(histdata[x] / 5, b.Height - 1); y++)
                {
                    b.SetPixel(x, (b.Height - 1), Color.Black);
                }

        }
    }
}
