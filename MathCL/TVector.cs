using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCL
{
    public class TVector
    {
        public string Header { get; set; } = "";
        public string Comment { get; set; } = "";

        public enum KindOfData
        {
            StringValue,
            DoubleValue,
            FactorValue
        }

        public KindOfData Kind { get; set; } = KindOfData.StringValue;

        public List<string> SData { get; set; } = new List<string>();
        public List<double> DData { get; set; } = new List<double>();

        public SortedDictionary<string, int> SDData { get; set; } = new SortedDictionary<string, int>();

        public void ToDData()
        {
            Kind = KindOfData.DoubleValue;
            DData.Clear();
            if (SData.Count > 0)
            {
                foreach (string s in SData)
                {
                    double d = 0;
                    bool b = double.TryParse(s, out d);
                    DData.Add(d);
                }
            }
        }

        public void ToSDData()
        {
            Kind = KindOfData.FactorValue;
            DData.Clear();
            SDData.Clear();
            if (SData.Count > 0)
            {
                // add keys with 0 value
                foreach (string s in SData)
                {
                    try
                    {
                        SDData.Add(s, 0);
                    }
                    catch (Exception e)
                    {
                    }
                }

                // renumber keys with new values
                int i = 0;
                foreach (KeyValuePair<string, int> pair in SDData)
                {
                    i++;
                    SDData[pair.Key] = i;
                }

                // write values to DData
                foreach (string s in SData)
                {
                    DData.Add(SDData[s]);
                }
            }
        }

        public void ToSDataFromDData()
        {
            Kind = KindOfData.StringValue;
            SDData.Clear();
            if (DData.Count > 0)
            {
                foreach (double d in DData)
                {
                    SData.Add(d.ToString());
                }
            }
        }

        public double[] ToDoubles()
        {
            return DData.ToArray();
        }
        public string[] ToStrings()
        {
            return SData.ToArray();
        }

        public void FromDoubles(double[] doubles)
        {
            DData.Clear();
            DData.AddRange(doubles);
            ToSDataFromDData();
        }
        public void FromStrings(string[] s)
        {
            SData.Clear();
            SData.AddRange(s);
            ToDData();
        }

        void FromValue(double value,int Count)
        {
            if (Count < 1) Count = 1;
            FromDoubles(MathNet.Numerics.Generate.Repeat(Count, value));
        }

        void Null(int Count)
        {
            FromValue(0.0,Count);
        }
        void Ones(int Count)
        {
            FromValue(1.0, Count);
        }

    }
}
