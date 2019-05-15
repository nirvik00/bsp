﻿using System;
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
        List<Point3d> ptList = new List<Point3d>();
        List<LineCurve> displayLine = new List<LineCurve>();

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

        public PolyCurve GetPolyLineCrv()
        {
            PolyCurve poly = new PolyCurve();
            for(int i=0; i<displayLine.Count; i++)
            {
                poly.Append(displayLine[i]);
            }
            return poly;
        }
    }
}