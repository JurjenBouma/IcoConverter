using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace IcoConverter
{
    public static class IcoFileConverter
    {
        public static void ConvertToIco(string[] pngPaths,string savePath)
        {
            List<byte[]> pngBytes = new List<byte[]>();
            for (int i = 0; i < 4; i++)
            {
                if (pngPaths[i] != null)
                {
                    Stream readStream = new FileStream(pngPaths[i], FileMode.Open);
                    BinaryReader reader = new BinaryReader(readStream);
                    pngBytes.Add(reader.ReadBytes((int)readStream.Length));
                    readStream.Close();
                }
            }

            Stream saveStream = new FileStream(savePath, FileMode.Create);
            BinaryWriter writer = new BinaryWriter(saveStream);
      
            writer.Write((UInt16)0);//constant
            writer.Write((UInt16)1);//1=ico 2=cur (cursor .CUR)
            writer.Write((UInt16)pngBytes.Count);//number of images
            //foreach image
            int offset = 6 + 16 * pngBytes.Count;
            for (int i = 0; i < pngBytes.Count; i++)
            {
                Bitmap bitmap = new Bitmap(pngPaths[i]);
                writer.Write((byte)bitmap.Width);//imageWidth
                writer.Write((byte)bitmap.Height);//ImageHeight
                writer.Write((byte)0);//number of palette colors
                writer.Write((byte)0);//constant
                writer.Write((UInt16)0);//Color planes?
                writer.Write((UInt16)32);//bits per pixel
                writer.Write((int)pngBytes[i].Length);//data lenght
                writer.Write((int)offset);//data offset
                offset += pngBytes[i].Length;
            }
            for (int i = 0; i < pngBytes.Count; i++)
            {
                writer.Write(pngBytes[i]);//data offset
            }
            saveStream.Close();
        }
    }
}
