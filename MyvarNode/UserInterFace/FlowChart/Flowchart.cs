using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace UserInterFace.FlowChart
{
    public partial class Flowchart : UserControl
    {
        public List<NIcon> Icons = new List<NIcon>();
        public int UIDC = 0;
        public int cpUIDC = 0;
        public int cAddpoint = 0;
        private Point Mousepos = new Point(0, 0);
        private List<Point> pt1 = new List<Point>();
        private List<Point> pt2 = new List<Point>();
        private Point startselect = new Point(0 ,0);
        private bool inselect = false;
        public Flowchart()
        {
            InitializeComponent();

        }

        private void Flowchart_Load(object sender, EventArgs e)
        {

            DoubleBuffered = true;
        }

        public void ReDraw()
        {
            Refresh();


        }



        public void AddIcon(NIcon icon)
        {
            Icons.Add(icon);
        }

        private void DrawTimer_Tick(object sender, EventArgs e)
        {
            List<int> drawnUIDs = new List<int>();
            
            foreach (var Icon in Icons)
            {


                foreach (var cpoint in Icon.ConnectionPoints)
                {
                    if (cpoint.IsMouseDown)
                    {

                        pt1.Add(new Point(cpoint.Location.X + 5 + Icon.Location.X,
                            cpoint.Location.Y + 5 + Icon.Location.Y));
                        pt2.Add(new Point(Mousepos.X, Mousepos.Y));
                    }
                    if (cpoint.ConnectedToUID != -1 && !drawnUIDs.Contains(cpoint.UID))
                    {
                        pt1.Add(new Point(cpoint.Location.X + 5 + Icon.Location.X,
                            cpoint.Location.Y + 5 + Icon.Location.Y));
                       
                        
                        var oth = new Point();
                        var oth1 = new Point();
                        foreach (var nIcon in Icons)
                        {
                            foreach (var connectionPoint in nIcon.ConnectionPoints)
                            {
                                if (connectionPoint.UID == cpoint.ConnectedToUID && cpoint.Connected)
                                {
                                    drawnUIDs.Add(connectionPoint.UID);
                                    oth = connectionPoint.Location;
                                    oth1 = nIcon.Location;
                                   pt2.Add(new Point(oth.X + 5 + oth1.X,
                                    oth.Y + 5 + oth1.Y));
                                    break;
                                }
                            }
                        }
                        
                        
                        

                    }

                }

            }
            ReDraw();
            

        }

        private void Flowchart_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;

            foreach (var Icon in Icons)
            {
                //draw icon it self

                #region DrawIcons

                var x = Icon.DrawPoints.Count;
                for (int index = 0; index < x; index++)
                {
                    var point0 = Icon.DrawPoints[index];
                    point0.X += Icon.Location.X;
                    point0.Y += Icon.Location.Y;
                    if (index != Icon.DrawPoints.Count - 1)
                    {
                        var point1 = Icon.DrawPoints[index + 1];
                        point1.X += Icon.Location.X;
                        point1.Y += Icon.Location.Y;
                        g.DrawLine(Icon.aColor, point0, point1);

                    }
                    else
                    {
                        var point1 = Icon.DrawPoints[0];
                        point1.X += Icon.Location.X;
                        point1.Y += Icon.Location.Y;
                        g.DrawLine(Icon.aColor, point0, point1);
                    }
                }

                #endregion

                foreach (var point in Icon.ConnectionPoints)
                {
                    g.FillEllipse(point.Brush, point.Location.X + Icon.Location.X, point.Location.Y + Icon.Location.Y,10, 10);
                }

            }
            for (int index = 0; index < pt1.Count; index++)
            {
                g.DrawLine(Pens.Black, pt1[index], pt2[index]);
            }
            pt1.Clear();
            pt2.Clear();
            for (int index = Icons.Count; index > 0; index--)
            {
                var Icon = Icons[index - 1];
                var r1 = new Rectangle(Icon.Location, Icon.Size);
                var r2 = new Rectangle(Mousepos.X, Mousepos.Y, 1, 1);

                if (r2.IntersectsWith(r1) || Icon.isSelected)
                {
                    var r3 = new Rectangle(r1.X - 2, r1.Y - 2, r1.Width + 4, r1.Height + 4);
                    g.DrawRectangle(Pens.Blue, r3);
                    Icon.IsFocused = true;
                    //break;
                }
                if (!r2.IntersectsWith(r1))
                {
                    Icon.IsFocused = false;
                }
            }

            if (inselect)
            {
             
                SolidBrush br = new SolidBrush(Color.FromArgb(100, 0, 0, 255));
                var finar = getRectangleForPoints(startselect, Mousepos);
                
                g.FillRectangle(br, finar);
                g.DrawRectangle(Pens.Blue, finar);
                for (int index = Icons.Count; index > 0; index--)
                {
                    var Icon = Icons[index - 1];

                    var r2 = new Rectangle(Icon.Location, Icon.Size);

                    if (r2.IntersectsWith(finar))
                    {
                        Icon.isSelected = true;
                    }
                    else
                    {
                        Icon.isSelected = false;
                    }

                }
            }

        }
        private Rectangle getRectangleForPoints(Point beginPoint, Point endPoint)
        {
            int top = beginPoint.Y < endPoint.Y ? beginPoint.Y : endPoint.Y;
            int bottom = beginPoint.Y > endPoint.Y ? beginPoint.Y : endPoint.Y;
            int left = beginPoint.X < endPoint.X ? beginPoint.X : endPoint.X;
            int right = beginPoint.X > endPoint.X ? beginPoint.X : endPoint.X;

            Rectangle rect = new Rectangle(left, top, (right - left), (bottom - top));
            return rect;
        }
        private void Flowchart_MouseMove(object sender, MouseEventArgs e)
        {
            Mousepos = new Point(e.X, e.Y);
            foreach (var Icon in Icons)
            {

                if (Icon.isDragged && Icon.IsFocused)
                {
                    Icon.isSelected = false;
                    Point newPoint = new Point((e.X - Icon.Location.X) + Icon.Location.X,
                        (e.Y - Icon.Location.Y) + Icon.Location.Y);
                    newPoint.Offset(Icon.ptOffset);
                    Icon.Location = newPoint;
                    inselect = false;
                }
               
            }

            



        }

        private void Flowchart_MouseDown(object sender, MouseEventArgs e)
        {
            bool inbtersected = false;

            foreach (var Icon in Icons)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (Icon.IsFocused)
                    {
                        Icon.isDragged = true;
                        Point ptStartPosition = new Point((e.X - Icon.Location.X) + Icon.Location.X,
                            (e.Y - Icon.Location.Y) + Icon.Location.Y);
                        // Point ptStartPosition = Icon.Location;
                        Icon.ptOffset = new Point();
                        Icon.ptOffset.X = Icon.Location.X - ptStartPosition.X;
                        Icon.ptOffset.Y = Icon.Location.Y - ptStartPosition.Y;
                    }
                    foreach (var cpoint in Icon.ConnectionPoints)
                    {
                        var r1 = new Rectangle(new Point(cpoint.Location.X + Icon.Location.X, cpoint.Location.Y + Icon.Location.Y), new Size(10, 10));
                        var r2 = new Rectangle(Mousepos.X, Mousepos.Y, 1, 1);

                        if (r2.IntersectsWith(r1))
                        {
                            cpoint.IsMouseDown = true;
                            inbtersected = true;
                        }
                        else
                        {
                            cpoint.IsMouseDown = false;
                        }
                    }

                }
                else
                {
                    Icon.isDragged = false;
                }

            }
            for (int index = Icons.Count; index > 0; index--)
            {
                var Icon = Icons[index - 1];
                var r1 = new Rectangle(Icon.Location, Icon.Size);
                var r2 = new Rectangle(Mousepos.X, Mousepos.Y, 1, 1);

                if (r2.IntersectsWith(r1))
                {
                    Icon.isSelected = true;
                    foreach (var Icon1 in Icons)
                    {
                        if (Icon1.UID != Icon.UID)
                        {
                            Icon1.isSelected = false;
                            inbtersected = true;
                        }
                    }
                }

            }
            if (!inbtersected)
            {
                startselect = new Point(e.X,e.Y);
                inselect = true;
            }

        }

        private void Flowchart_MouseUp(object sender, MouseEventArgs e)
        {
            inselect = false;
            List<int> doneuids = new List<int>();
            foreach (var Icon in Icons)
            {
                if (Icon.IsFocused)
                {
                    Icon.isDragged = false;
                    
                }
                foreach (var cpoint in Icon.ConnectionPoints)
                {
                    var done = false;
                    foreach (var Icon1 in Icons)
                    {
                        if (Icon != Icon1)
                        {
                            foreach (var cpoint1 in Icon1.ConnectionPoints)
                            {
                                var r1 =
                                    new Rectangle(
                                        new Point(cpoint1.Location.X + Icon1.Location.X,
                                            cpoint1.Location.Y + Icon1.Location.Y),
                                        new Size(10, 10));
                                var r2 = new Rectangle(Mousepos.X, Mousepos.Y, 1, 1);

                                if (r2.IntersectsWith(r1) && cpoint.IsMouseDown == true && !doneuids.Contains(cpoint1.UID) && !doneuids.Contains(cpoint.UID))
                                {
                                    if (!done)
                                    {
                                        cpoint.ConnectedToUID = cpoint1.UID;
                                        cpoint1.ConnectedToUID = cpoint.UID;
                                        doneuids.Add(cpoint1.UID); 
                                        doneuids.Add(cpoint.UID);
                                        cpoint.Connected = true;
                                        cpoint1.Connected = true;
                                        done = true;
                                        break;
                                    }
                                }
                            }
                            if (done)
                            {
                                break;
                            }
                        }
                    }
                    cpoint.IsMouseDown = false;
                }
            }
        }

        private void Flowchart_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            for (int index = Icons.Count; index > 0; index--)
            {
                var Icon = Icons[index - 1];
                var r1 = new Rectangle(Icon.Location, Icon.Size);
                var r2 = new Rectangle(Mousepos.X, Mousepos.Y, 1, 1);

                if (r2.IntersectsWith(r1))
                {
                    if (Icon.OptionsControl != null)
                    {
                        Form f = new Form();
                        var op = Icon.OptionsControl;
                        op.Dock = DockStyle.Fill;
                        op.GetType().GetProperty("Data").SetValue(op, Icon, null);
                        op.GetType().GetProperty("Flowchart").SetValue(op, this, null);
                        f.Controls.Add(op);
                        f.Text = Icon.ID + @" Settings";
                        f.ShowDialog();
                        
                        break;
                    }
                }

            }
        }

        private void Flowchart_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }




        private void Flowchart_KeyUp(object sender, KeyEventArgs e)
        {
            var todelete = new List<NIcon>();
            foreach (var Icon in Icons)
            {

                if (Icon.isSelected)
                {
                    if (e.KeyCode == Keys.Delete)
                    {



                        foreach (var Icon1 in Icons)
                        {

                            foreach (var cpoint in Icon1.ConnectionPoints)
                            {
                                foreach (var connectionPoint in Icon.ConnectionPoints)
                                {
                                    if (cpoint.ConnectedToUID == connectionPoint.UID)
                                    {
                                        cpoint.ConnectedToUID = -1;
                                    }
                                    connectionPoint.ConnectedToUID = -1;
                                }

                            }

                        }

                        todelete.Add(Icon);
                       

                    }
                    
                }
            }
            foreach (var nIcon in todelete)
            {
                Icons.Remove(nIcon);
            }
        }
    }
}
