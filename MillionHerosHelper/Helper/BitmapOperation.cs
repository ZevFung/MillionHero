using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace MillionHerosHelper
{
    static class BitmapOperation
    {
        public static byte[] CutImage(string fileName, Point location, Size size)
        {
            Bitmap bitmap = new Bitmap(fileName);
            Rectangle rectangle = new Rectangle(location, size);
            Bitmap newBitmap;
            try
            {
                newBitmap = bitmap.Clone(rectangle, bitmap.PixelFormat);
            }
            catch(Exception ex)
            {
                bitmap.Dispose();
                throw ex;
            }
            

            //将新位图写到内存流中
            MemoryStream memoryStream = new MemoryStream();
            newBitmap.Save(memoryStream, bitmap.RawFormat);
            byte[] res = new byte[memoryStream.Length];
            memoryStream.Seek(0, SeekOrigin.Begin);
            memoryStream.Read(res, 0, (int)memoryStream.Length);

            bitmap.Dispose();
            newBitmap.Dispose();
            memoryStream.Close();

            return res;
        }

        public static byte[] CutImage(Bitmap bitmap, Point location, Size size)
        {
            Rectangle rectangle = new Rectangle(location, size);
            Bitmap newBitmap = bitmap.Clone(rectangle, bitmap.PixelFormat);

            //将新位图写到内存流中
            MemoryStream memoryStream = new MemoryStream();
            newBitmap.Save(memoryStream, bitmap.RawFormat);
            byte[] res = new byte[memoryStream.Length];
            memoryStream.Seek(0, SeekOrigin.Begin);
            memoryStream.Read(res, 0, (int)memoryStream.Length);

            newBitmap.Dispose();
            memoryStream.Close();

            return res;
        }

        public static byte[] CutScreen(Point location, Size size)
        {
            Bitmap bitmap = new Bitmap(size.Width, size.Height);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.CopyFromScreen(location, new Point(0, 0), size);
            graphics.Dispose();



            MemoryStream memoryStream = new MemoryStream();
            bitmap.Save(memoryStream, ImageFormat.Png);
            byte[] res = new byte[memoryStream.Length];
            memoryStream.Seek(0, SeekOrigin.Begin);
            memoryStream.Read(res, 0, (int)memoryStream.Length);

            memoryStream.Dispose();
            bitmap.Dispose();
            return res; 
        }
    }
}
