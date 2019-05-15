using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dots_dev
{
    class GeomEntry
    {
        private string Name;
        private string Parent;
        private double Area;
        private double RatioA;
        private double RatioB;
        private double Length=0.00;
        private double Width=0.00;
        private int Number=1;

        string OPT = ""; // send option of the constructor

        public GeomEntry() { }
        public GeomEntry(string name, String parent, double area, double a, double b, int num)
        {
            Name = name;
            Parent = parent;
            Area = area;
            RatioA = a;
            RatioB = b;
            Length = Area * RatioA;
            Width = Area * RatioB;
            Number = num;
            OPT = "opt-0";
        }
        public GeomEntry(string name, string parent, double l, double w, int num)
        {
            Name = name;
            Parent = parent;
            Length = l;
            Width = w;
            Number = num;
            OPT = "opt-1";
        }
        public string displayString()
        {
            string s = Name + "," + Parent+ "," + Length + "," + Width + "," + Number + "," + OPT;
            return s;
        }
    }
    class MakeGeomObjList
    {
        private List<string> input;
        private List<string> geomObjLi;

        public MakeGeomObjList() { }

        public MakeGeomObjList(List<string> inputstrli)
        {
            geomObjLi = new List<string>();
            input = new List<string>();
            input = inputstrli;
        }

        public double GetDoubleFromString(string str)
        {
            double x = 0.00;
            string s = str.Trim();
            if (String.Equals(str, "")) return x;
            else return Convert.ToDouble(s);
        }

        public double GetInt16FromString(string str)
        {
            int x = 0;
            string s = str.Trim();
            if (String.Equals(str, "")) return x;
            else return Convert.ToInt16(s);
        }

        public List<string> GetGeomObjList()
        {
            for (int i = 1; i < input.Count; i++)
            {
                int opt = 0; // if 0, use area, ratio else use length, width

                // format of the inputs:
                /// name[0], area[1], ratio (a:b)[2], number[3], length[4], width[5]

                string name = input[i].Split(',')[0].Trim().ToUpper();

                string parent = input[i].Split(',')[1].Trim().ToUpper();
                if (string.Equals(parent, "") == true || parent == null) parent = "0";
              
                double area = GetDoubleFromString(input[i].Split(',')[2]);
                if (area < 0.01) opt++;

                double ratio = GetDoubleFromString(input[i].Split(',')[3]);
                double a = 0.0; double b = 0.0;
                if (ratio < 0.1) { opt++; }
                else
                {
                    a = 1 - ratio;
                    b = ratio;
                }

                int num = Convert.ToInt32(input[i].Split(',')[4]);

                double le = GetDoubleFromString(input[i].Split(',')[5]);
                double wi = GetDoubleFromString(input[i].Split(',')[6]);
                if (le > 0.0 && wi > 0.0) { opt = 0; }
                else { opt = 1; }

                if (num == 0) continue; // num =0, then continue - do not initialize

                GeomEntry geom;
                if (opt > 0) { geom = new GeomEntry(name, parent, area, a, b, num); }
                else { geom = new GeomEntry(name, parent, le, wi, num); }
                String str = geom.displayString();
                geomObjLi.Add(str);

            }
            return geomObjLi;
        }
    }
}
