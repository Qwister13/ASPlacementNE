using Siticone.UI.HtmlRenderer.Adapters.Entities;
using Siticone.UI.WinForms.Suite;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static Interface1.MyPoints;
using static Siticone.UI.Native.WinApi;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ToolTip = System.Windows.Forms.ToolTip;

namespace Interface1
{
    internal class PointStorage
    {
            private List<Point> points = new List<Point>();

            public void AddPoint(Point p)
            {
                points.Add(p);
            }

            public void RemovePoint(Point p)
            {
                points.Remove(p);
            }

            public List<Point> GetPoints()
            {
                return points;
            }

            public void Clear()
            {
                points.Clear();
            }
       
    }
}
