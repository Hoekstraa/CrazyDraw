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
            using (StreamWriter file = new StreamWriter(filename, false))
            //using (var file = new FileStream(filename, FileMode.Open))
            {
                file.WriteLine("group " + figures.Count);

                foreach(var fig in figures)
                    file.WriteLine(fig.ToString(1));
            }
        }
    }
}
