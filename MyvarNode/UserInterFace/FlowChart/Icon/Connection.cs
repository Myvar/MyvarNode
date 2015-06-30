using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterFace.FlowChart.Icon
{
    public class Connection
    {
        public Point Location { get; set; }
        public bool Connected { get; set; }
        public Brush Brush { get; set; }
        public int ConnectedToUID { get; set; }
        public bool IsInput { get; set; }
        public bool IsMouseDown { get; set; }
        public int UID { get; set; }

        public Connection()
        {
            IsInput = true;
            ConnectedToUID = -1;
        }
    }
}
