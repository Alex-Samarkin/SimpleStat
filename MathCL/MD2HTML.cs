using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MathCL
{
    public class MD2HTML
    {
        public string MDText { get; set; } = "";
        public string HTMLText => Markdig.Markdown.ToHtml(MDText);

        public string NewParagraph => Environment.NewLine+Environment.NewLine;
        public string NP => NewParagraph;

        public void AddHeader(string s, int level = 1)
        {
            if (level<1)
            {
                level = 1;
            }

            if (level>8)
            {
                level = 8;
            }

            string res = new string('#', level);
            res += " " + s + Environment.NewLine + NP;
            MDText += res;
        }

        public void H1(string s) => AddHeader(s, 1);
        public void H2(string s) => AddHeader(s, 2);
        public void H3(string s) => AddHeader(s, 3);
        public void H4(string s) => AddHeader(s, 4);

        public void AddParagraph(string s)
        {
            MDText += s + NP;
        }

        public void P(string s) => AddParagraph(s);
        public void HR() => P("---");

        public void P(string[] strings)
        {
            foreach (string s in strings)
            {
                P(s);
            }
        }

        public void P(IEnumerable<string> strEnumerable)
        {
            foreach (string s in strEnumerable)
            {
                P(s);
            }
        }

    }
}
