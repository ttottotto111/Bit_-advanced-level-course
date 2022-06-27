using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace _1019DC실습
{
    /// <summary>
    /// 도형의 타입을 정의한 열거형 타입
    /// </summary>
    public enum ShapeType
    {
        Rect = 0,
        Ellipse = 1,
        Triangle =2
    }

    /// <summary>
    /// 도형의 크기를 정의한 열거형 타입
    /// </summary>
    public enum ShapeSize
    {
        Size1 = 25,
        Size2 = 50,
        Size3 = 75,
        Size4 = 100
    }

    /// <summary>
    /// 도형 데이터 클래스
    /// </summary>
    public class Shape
    {
        public Point Pt { get; set; }
        public Color PenColor { get; set; }
        public Color BrushColor { get; set; }
        public ShapeSize Size { get; set; }
        public ShapeType Type { get; set; }

        public Shape() { }
        public Shape(Point pt, Color pencolor, Color brushcolor, ShapeSize size, ShapeType type)
        {
            Pt = pt;
            PenColor = pencolor;
            BrushColor = brushcolor;
            Size = size;
            Type = type;
        }
    }
}
