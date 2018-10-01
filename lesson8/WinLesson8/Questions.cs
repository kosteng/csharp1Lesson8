using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinLesson8
{
    class Questions
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
        }
    }
}
