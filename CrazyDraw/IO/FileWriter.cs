using System.IO;
using System.Collections.Generic;
using CrazyDraw.Figures;
using System.Text;

namespace CrazyDraw.IO
{
    class FileWriter
    {
        private string filename;

        public FileWriter(string filename){this.filename = filename;}

        public void Write(ref List<IFigure> figures)
        {
            using (var file = new FileStream(filename, FileMode.Open))
            {
                file.Write(Encoding.UTF8.GetBytes("group " + figures.Count + "\n"));

                foreach(var fig in figures)
                    file.Write(Encoding.UTF8.GetBytes(fig.ToString() + "\n"));
            }
        }
    }
}
