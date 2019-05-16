using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Rhino.Geometry;

namespace dots_dev
{
    public class BSP
    {
        public Plane BasePlane = Plane.WorldXY;
        List<string> AdjObjLi = new List<string>(); // final adj obj list
        private List<string> GeomObjLiStr = new List<string>(); // final geom object list 
        private List<Point3d> ptList = new List<Point3d>();
        private List<LineCurve> displayLine = new List<LineCurve>();

        public BSP(List<string> adjobjli, List<string> geomobjliStr)
        {
            AdjObjLi = new List<string>();
            GeomObjLiStr = new List<string>();
            GeomObjLiStr = geomobjliStr;
            AdjObjLi = adjobjli;
        }

        public List<LineCurve> ComputeGeom(double le, double wi)
        {
            Point3d a = BasePlane.Origin + (BasePlane.XAxis * 10) + (BasePlane.YAxis * 10) + (BasePlane.ZAxis * 10);
            Point3d b = BasePlane.Origin + (BasePlane.XAxis * (10+le)) + (BasePlane.YAxis * 10) + (BasePlane.ZAxis * 10);
            Point3d c = BasePlane.Origin + (BasePlane.XAxis * (10+le)) + (BasePlane.YAxis * (10+wi)) + (BasePlane.ZAxis * 10);
            Point3d d = BasePlane.Origin + (BasePlane.XAxis * 10) + (BasePlane.YAxis * (10+wi)) + (BasePlane.ZAxis * 10);

            displayLine = new List<LineCurve>
            {
                new LineCurve(a, b),
                new LineCurve(b, c),
                new LineCurve(c, d),
                new LineCurve(d, a)
            };

            ptList = new List<Point3d> {a,b,c,d,a};
            return displayLine;
        }

        public List<Point3d> GetComputePoints()
        {
            return ptList;
        }

        public PolylineCurve GetPolyLineCrv()
        {
            List<double> dim=ComputeSquare();
            ComputeGeom(dim[0], dim[1]);
            PolylineCurve crv = new PolylineCurve(ptList);

            PolyCurve poly = new PolyCurve();
            for(int i=0; i<displayLine.Count; i++)
            {
                poly.Append(displayLine[i]);
            }
            return crv;
        }

        public List<double> ComputeSquare()
        {
            double maxLe=0.0;
            double maxWi=0.0;
            List<double> SqDim = new List<double>();
            double sumArea = 0.0;
            for(int i=0; i< GeomObjLiStr.Count; i++)
            {
                //name, parent, area, length, width, number
                string[] obj = GeomObjLiStr[i].Split(',');
                //string name = obj[0];
                double area = Convert.ToDouble(obj[2]);
                int number = Convert.ToInt32(obj[5]);
                sumArea+=(Math.Sqrt(area*number));
            }
            maxLe = Math.Sqrt(sumArea);
            maxWi = Math.Sqrt(sumArea);
            SqDim.Add(maxLe);
            SqDim.Add(maxWi);
            return SqDim;
        }
    } // class definition end
} // namespace definition end

