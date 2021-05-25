// SimpleStat
// MathCL
// TFrame.cs
// ---------------------------------------------
// Alex Samarkin
// Alex
// 
// 2:35 24 05 2021

using System;
using System.Collections.Generic;

namespace MathCL
{
    public class TFrame
    {
        public string Header { get; set; } = "Frame";
        public string Comment { get; set; } = "";

        public List<TVector> Vectors { get; set; } = new List<TVector>();
        public List<string> Headers = new List<string>();
        // split strings by vertical columns
        public void FromStringsV(string[] strings,bool HasHeader  = true, int skip = 0, string[]separatorStrings = null, string NA = "0")
        {
            // if no separator set it as ";" "," and "\t"
            if (separatorStrings==null)
            {
                separatorStrings = new[] {";", ",", "\t"};
            }
            // read first string as header or as data, and count columns
            string[] h = strings[0].Split(separatorStrings, StringSplitOptions.None);
            Headers.Clear();
            Headers.AddRange(h);
            // create empty vectors
            foreach (string header in Headers)
            {
                TVector v = new TVector() {Header = header};
                Vectors.Add(v);
            }
            // skip stings after header
            int start = 1 + skip;
            for (int i = start; i < strings.Length; i++)
            {
                // split each string
                List<string> dataList = new List<string>();
                string[] data = strings[i].Split(separatorStrings, StringSplitOptions.None);
                dataList.AddRange(data);
                // add default value if data NA
                while (dataList.Count<Vectors.Count)
                {
                    dataList.Add(NA);
                }
                // write it to vectors
                for (int j = 0; j < Vectors.Count; j++)
                {
                    Vectors[j].SData.Add(dataList[j]);
                }
            }
            // convert SData to DData in all vectors
            foreach (TVector vector in Vectors)
            {
                vector.ToDData();
            }

        }
        // split strings by horisontal columns
        public void FromStringsH(string[] strings,bool HasHeader  = true, int skip = 0, string[] separatorStrings = null, string NA = "0")
        {
            // if no separator set it as ";" "," and "\t"
            // read all strings and create vectors
            // split every strings
            // set first substring as Header
            // skip other
            // write substrings to vectors
            // convert SData to DData in all vectors

        }

        public List<string> GetHead(int count = 10)
        {
            if (count<1)
            {
                count = 1;
            }

            if (count > Vectors[0].SData.Count) count = Vectors[0].SData.Count;
            List<string> res = new List<string>();
            res.Add(Header);
            res.Add(Comment);
            string h = "";
            foreach (string header in Headers)
            {
                h += header + " |  ";
            }
            res.Add(h);
            res.Add("Vectors");
            string v = "";
            foreach (TVector vector in Vectors)
            {
                v += vector.Header + " | ";
            }
            res.Add(v);
            for (int i = 0; i < count; i++)
            {
                string d = "";
                foreach (TVector vector in Vectors)
                {
                     d+= vector.SData[i] + " | ";
                }
                res.Add(d);
            }
            return res;
        }


    }
}