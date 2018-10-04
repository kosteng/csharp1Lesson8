using System;
using System.Collections.Generic;
using System.IO;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WinLesson8
{
    public class Questions
    {
        private string text;
        private bool trueOrFalse;

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public bool TrueOrFalse
        {
            get { return trueOrFalse; }
            set { trueOrFalse = value; }
        }

        public Questions()
        { }

        public Questions(string text, bool trueOrFalse)
        {
            this.text = text;
            this.trueOrFalse = trueOrFalse;
        }

    }

    class TrueOrFalse
    {
        private string fileName;
        private List<Questions> list;
        void l()
        {
        }

        public List<Questions> List
        {
            get { return list; }
            set { list = value; }
        }

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        public TrueOrFalse(string fileName)
        {
            this.fileName = fileName;
            list = new List<Questions>();
        }

        public void Add(string text, bool trueOrFalse)
        {
            list.Add(new Questions(text, trueOrFalse));
        }

        public void Remove(int index)
        {
            if (list != null && index < list.Count && index >= 0) list.RemoveAt(index);
            else throw new IndexOutOfRangeException("Error");
        }

        public Questions this[int index]
        {
            get { return list[index]; }
            set { list[index] = value; }
        }

        public void Save()
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Questions>));
            Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            xmlFormat.Serialize(fStream, List);
            fStream.Close();
            
        }

        public void Load()
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Questions>));
            Stream fStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            list = (List<Questions>)xmlFormat.Deserialize(fStream);
            fStream.Close();
        }

        public int Count
        {
            get { return list.Count; }
        }
    }
}
