using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterFace.FlowChart.Icons
{
    public partial class Logic : UserControl 
    {
        public NIcon Data { get; set; }
        public Flowchart Flowchart { get; set; }
        public Logic()
        {
            InitializeComponent();
        }
    }
}
