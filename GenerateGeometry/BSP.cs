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
        List<string> GeomObjLi = new List<string>(); // final geom object list 

        public BSP(List<string> adjobjli, List<string> geomobjli)
        {
            AdjObjLi = new List<string>();
            GeomObjLi = new List<string>();
            AdjObjLi = adjobjli;
            GeomObjLi = geomobjli;
        }

        public List<LineCurve> ComputeDisplayLines()
        {
            Point3d a = BasePlane.Origin + (BasePlane.XAxis * 10) + (BasePlane.YAxis * 10) + (BasePlane.ZAxis * 10);
            Point3d b = BasePlane.Origin + (BasePlane.XAxis * 20) + (BasePlane.YAxis * 10) + (BasePlane.ZAxis * 10);
            Point3d c = BasePlane.Origin + (BasePlane.XAxis * 20) + (BasePlane.YAxis * 20) + (BasePlane.ZAxis * 10);
            Point3d d = BasePlane.Origin + (BasePlane.XAxis * 10) + (BasePlane.YAxis * 20) + (BasePlane.ZAxis * 10);

            List<LineCurve> displayLine = new List<LineCurve>();

            displayLine.Add(new LineCurve(a, b));
            displayLine.Add(new LineCurve(b, c));
            displayLine.Add(new LineCurve(c, d));
            displayLine.Add(new LineCurve(d, a));

            

            return displayLine;
        }
        // git connected to mac and windows
        // git connected to windows and mac
    }
}