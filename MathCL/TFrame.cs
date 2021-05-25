// SimpleStat
// MathCL
// TFrame.cs
// ---------------------------------------------
// Alex Samarkin
// Alex
// 
// 2:35 24 05 2021

using System.Collections.Generic;

namespace MathCL
{
    public class TFrame
    {
        public List<TVector> Vectors { get; set; } = new List<TVector>();
        public List<string> Headers = new List<string>();
        // split strings by vertical columns
        public void FromStringsV(string[] strings,bool HasHeader  = true, int skip = 0, string[]separatorStrings = null, string NA = "0")
        {
            // if no separator set it as ";" "," and "\t"
            // read first string as header or as data, and count columns
            // create empty vectors
            // skip stings after header
            // split each string
            // write it to vectors and add default value if data NA
            // convert SData to DData in all vectors


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


    }
}