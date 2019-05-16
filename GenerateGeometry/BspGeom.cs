using System;
using System.Collections.Generic;

using Grasshopper;
using Grasshopper.Kernel;
using Rhino.Geometry;

namespace dots_dev
{
    public class BspGeom 
    {
        private PolylineCurve Poly;
        private List<Point3d> Pts;
        List<string> GeomCalcLi = new List<string>();

        public BspGeom (PolylineCurve poly, List<string> geomCalcLi)
        {
            Poly = poly;
            GeomCalcLi = geomCalcLi;
        }

        public List<Point3d> GetPoints()
        {
            Pts = new List<Point3d>();
            Poly.TryGetPolyline(out Polyline poly);
            IEnumerable<Point3d> pts = poly;
            foreach(Point3d pt in pts)
            {
                Pts.Add(pt);
            }
            return Pts;
        }
    }
}
