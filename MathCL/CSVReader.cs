using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Markdig;
using MathNet;
using MathNet.Numerics.LinearAlgebra;
using CSV = MathNet.Numerics.Data.Text;

namespace MathCL
{
    public class CSVReader
    {
        [Category("Путь и имя")]
        [DisplayName("Путь к файлу")]
        [Description("Путь к файлу")]
        // [TypeConverter(typeof(ExpandableObjectConverter))]
        [NotifyParentProperty(true)]
        public string Path { get; set; } = ".\\";
        [Category("Путь и имя")]
        [DisplayName("Имя файла")]
        [Description("Имя файла без расширения")]
        // [TypeConverter(typeof(ExpandableObjectConverter))]
        [NotifyParentProperty(true)]
        public string FileName { get; set; } = "data";
        [Category("Путь и имя")]
        [DisplayName("Расширение")]
        [Description("Расширение (без точки)")]
        // [TypeConverter(typeof(ExpandableObjectConverter))]
        [NotifyParentProperty(true)]
        public string Ext { get; set; } = "csv";
        [Category("Путь и имя")]
        [DisplayName("Полное имя")]
        [Description("Полное имя файла")]
        // [TypeConverter(typeof(ExpandableObjectConverter))]
        [NotifyParentProperty(true)]
        public string FullName { get=>Path+FileName+"."+Ext; }

        public bool FileExists()
        {
            return File.Exists(FullName);
        }
        [Category("Путь и имя")]
        [DisplayName("Существует?")]
        [Description("Существует ли файл")]
        // [TypeConverter(typeof(ExpandableObjectConverter))]
        [NotifyParentProperty(true)]
        public bool Exists { get=>FileExists(); }

        [Category("Содержание файла")]
        [DisplayName("Количество строк с начала файла")]
        [Description("Первые N строк")]
        // [TypeConverter(typeof(ExpandableObjectConverter))]
        [NotifyParentProperty(true)]
        public int NHead { get; set; } = 10;

        [Category("Содержание файла")]
        [DisplayName("Шапка")]
        [Description("Первые N строк")]
        // [TypeConverter(typeof(ExpandableObjectConverter))]
        [NotifyParentProperty(true)]
        public string Head {
            get
            {
                string res = "";
                List<string> str = GetHead(NHead);
                foreach (var s in str)
                {
                    res += s + Environment.NewLine+ Environment.NewLine;
                }

                return res;
            }
        }

        public List<string> GetHead(int count = 10)
        {
            List<string> str = new List<string>();
            if (Exists)
            {
                foreach (string s in File.ReadLines(FullName).Take(count))
                {
                    str.Add(s);
                }
            }
            return str;
        }

        public string[] Separators { get; set; } = {",",";","\t"};
        public string NewLine { get; set; } = Environment.NewLine;
        public List<string> Headers { get; set; } = new List<string>();



        public void ReadCSV()
        {
           //Matrix<double> m = CSV.DelimitedReader.Read<double>(FullName, false, ",;",true);
           string f = File.ReadAllText(FullName);
           Headers.Clear();
           Headers = GetHeaders(f);

        }

        public List<string> GetHeaders(string f)
        {
            List<string> res = new List<string>();
            string h = f.Split(new string[] { NewLine }, StringSplitOptions.None)[0];
            res.AddRange(h.Split(Separators, StringSplitOptions.None));
            return res;
        }


    }
}
