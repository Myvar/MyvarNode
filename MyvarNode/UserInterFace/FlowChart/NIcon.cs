using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserInterFace.FlowChart.Icon;

namespace UserInterFace.FlowChart
{
    public class NIcon
    {
        public Point ptOffset;
        public Point Location { get; set; }
        public bool isDragged { get; set; }
        public bool isSelected { get; set; }
        public Size Size { get; set; }
        public bool IsFocused { get; set; }
        public List<Point> DrawPoints { get; set; }
        public Pen aColor { get; set; }
        public List<Connection> ConnectionPoints { get; set; }
        public string ID { get; set; }
        public int UID { get; set; }
        public object Data { get; set; }
        public Control OptionsControl { get; set; }
    }
}
