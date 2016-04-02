using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicModern
{
    public partial class MainForm : Form
    {
        //List<Shape> Shapes;
        //bool isSelectedArea = false;
        //Rectangle AreaSelectionRect = null;
        //Rectangle LocalSelectedAxis = null;
        //List<Shape> SelectedShapes;

        Frames frames;

        Shape HoveredShape = null;
        Point? SelectedPoint = null;
        int SelectedPointNum;
        bool isPointPressed = false;
        MoveInfo Moving = null;
        bool needBlinking = false;
        static int blinkCount = 5;
        List<Shape> BlinkShapes;
        Shape blinkShape = null;       
        Point? AreaSelectionStartPoint = null;
        public static int PointSize = 4;
        public static int sideDivider = 50;

        public MainForm()
        {
            this.DoubleBuffered = true;
            frames = new Frames();
            frames.Add(new Frame());
            frames.curFrame = 1;
            //Shapes = new List<Shape>();
            //SelectedShapes = new List<Shape>();
            BlinkShapes = new List<Shape>();
            InitializeComponent();
            prevFrameButton.Enabled = false;
            nextFrameButton.Enabled = false;
            RemoveFrameButton.Enabled = false;
            ShowAnimationButton.Enabled = false;

            saveFileDialog1.Filter = String.Format("Файлы редактора|*.grlab");
            openFileDialog1.Filter = String.Format("Файлы редактора|*.grlab");
        }

        private void AddLine_Click(object sender, EventArgs e)
        {
            //Shapes.Add(new Line(200, 300, 400, 300));
            frames[frames.curFrame-1].Shapes.Add(new Line(20, 20, 100, 100));
            DrawPanel.Refresh();
        }
            
        private void DrawPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            var penAxis = new Pen(Color.Gray, 1);
            var penSelection = new Pen(Color.DarkMagenta, 1);
            float[] dashValues = { 5, 5 };
            var penLocalAxis = new Pen(Color.Black);
            penLocalAxis.DashPattern = dashValues;
            e.Graphics.DrawLine(penAxis, new Point(DrawPanel.Width / 2, 0), new Point(DrawPanel.Width / 2, DrawPanel.Height));
            e.Graphics.DrawLine(penAxis, new Point(0, DrawPanel.Height / 2), new Point(DrawPanel.Width, DrawPanel.Height / 2));

            if (frames[frames.curFrame - 1].isSelectedArea)
            {
                e.Graphics.FillRectangle(
                    new SolidBrush(Color.FromArgb(100, 139, 0, 139)),
                    frames[frames.curFrame - 1].AreaSelectionRect.TopLeft.X,
                    frames[frames.curFrame - 1].AreaSelectionRect.TopLeft.Y,
                    frames[frames.curFrame - 1].AreaSelectionRect.Width,
                    frames[frames.curFrame - 1].AreaSelectionRect.Height);

                for (int i = 0; i < frames[frames.curFrame - 1].AreaSelectionRect.Points.Count - 1; i++)
                    e.Graphics.DrawLine(penSelection, frames[frames.curFrame - 1].AreaSelectionRect.Points[i], frames[frames.curFrame - 1].AreaSelectionRect.Points[i + 1]);

                e.Graphics.DrawLine(penSelection, frames[frames.curFrame - 1].AreaSelectionRect.Points[frames[frames.curFrame - 1].AreaSelectionRect.Points.Count - 1], frames[frames.curFrame - 1].AreaSelectionRect.Points[0]);
            }

            if (frames[frames.curFrame - 1].LocalSelectedAxis != null && frames[frames.curFrame - 1].SelectedShapes.Count != 0)
            {
                for (int i = 0; i < frames[frames.curFrame - 1].LocalSelectedAxis.Points.Count - 1; i++)
                    e.Graphics.DrawLine(penLocalAxis, frames[frames.curFrame - 1].LocalSelectedAxis.Points[i], frames[frames.curFrame - 1].LocalSelectedAxis.Points[i + 1]);

                e.Graphics.DrawLine(penLocalAxis, frames[frames.curFrame - 1].LocalSelectedAxis.Points[frames[frames.curFrame - 1].LocalSelectedAxis.Points.Count - 1], frames[frames.curFrame - 1].LocalSelectedAxis.Points[0]);
            }

            foreach (Shape shape in frames[frames.curFrame - 1].Shapes)
            {
                if (!BlinkShapes.Contains(shape) || (BlinkShapes.Contains(shape) && needBlinking))
                {
                    var color = frames[frames.curFrame - 1].SelectedShapes.Contains(shape) ? Color.LimeGreen : shape == HoveredShape ? Color.DimGray : Color.Black;
                    if (BlinkShapes.Contains(shape))
                        color = Color.CadetBlue;
                    var pen = new Pen(color, 3);

                    for (int i = 0; i < shape.Points.Count - 1; i++)
                        e.Graphics.DrawLine(pen, shape.Points[i], shape.Points[i + 1]);

                    e.Graphics.DrawLine(pen, shape.Points[shape.Points.Count - 1], shape.Points[0]);

                    for (int i = 0; i < shape.Points.Count; i++)
                        e.Graphics.FillEllipse(new SolidBrush(Color.DarkCyan), shape.Points[i].X - PointSize, shape.Points[i].Y - PointSize, PointSize * 2, PointSize * 2);
                }
            }
        }

        private void RefreshLineSelection(Point Point)
        {
            var selectedShape = FindShapeByPoint(Point);
            if (selectedShape != this.HoveredShape)
            {
                this.HoveredShape = selectedShape;
                this.Invalidate();
            }
            if (Moving != null)
                this.Invalidate();

            if (this.Cursor != Cursors.Cross)
                this.Cursor = HoveredShape != null ? Cursors.Hand : Cursors.Default;

        }

        Shape FindShapeByPoint(Point p)
        {
            var size = 10;
            var buffer = new Bitmap(size * 2, size * 2);

            foreach (Shape shape in frames[frames.curFrame - 1].Shapes)
            {
                using (var g = Graphics.FromImage(buffer))
                {
                    g.Clear(Color.Black);
                    for (int i = 0; i < shape.Points.Count - 1; i++)
                        g.DrawLine(new Pen(Color.Green, 3), shape.Points[i].X - p.X + size, shape.Points[i].Y - p.Y + size, shape.Points[i + 1].X - p.X + size, shape.Points[i + 1].Y - p.Y + size);

                    g.DrawLine(new Pen(Color.Green, 3), shape.Points[shape.Points.Count - 1].X - p.X + size, shape.Points[shape.Points.Count - 1].Y - p.Y + size, shape.Points[0].X - p.X + size, shape.Points[0].Y - p.Y + size);

                    for (int i = 0; i < shape.Points.Count; i++)
                    {
                        g.FillEllipse(new SolidBrush(Color.DarkCyan), shape.Points[i].X - p.X + size - PointSize, shape.Points[i].Y - p.Y + size - PointSize, PointSize * 2, PointSize * 2);
                        int colorPoint = buffer.GetPixel(size, size).ToArgb();

                        if (colorPoint == Color.DarkCyan.ToArgb())
                        {
                            SelectedPoint = shape.Points[i];
                            SelectedPointNum = i;
                            break;
                        }
                    }
                }


                int color = buffer.GetPixel(size, size).ToArgb();

                if (color != Color.Black.ToArgb())
                {
                    return shape;
                }
            }
            return null;
        }

        void Blinking(int count)
        {
            for (int i = 1; i <= count; i++)
            {
                needBlinking = !needBlinking;
                Refresh();
                System.Threading.Thread.Sleep(100);
            }
            needBlinking = false;
            blinkShape = null;
            BlinkShapes.Clear();
            Refresh();
        }

        private void DrawPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (Moving != null && !isPointPressed)
            {
                bool isInArea = true;
                foreach (Point Point in Moving.StartPoints)
                {
                    if (Point.X + e.X - Moving.StartMousePoint.X <= 0 ||
                        Point.X + e.X - Moving.StartMousePoint.X >= DrawPanel.Width ||
                        Point.Y + e.Y - Moving.StartMousePoint.Y <= 0 ||
                        Point.Y + e.Y - Moving.StartMousePoint.Y >= DrawPanel.Height)
                    {
                        isInArea = false;
                        break;
                    }
                }

                if (isInArea)
                {
                    for (int i = 0; i < Moving.Shape.Points.Count; i++)
                    {
                        Moving.Shape.Points[i] = new Point(Moving.StartPoints[i].X + e.X - Moving.StartMousePoint.X, Moving.StartPoints[i].Y + e.Y - Moving.StartMousePoint.Y);
                    }
                }
            }
            else if (SelectedPoint != null && isPointPressed)
            {
                if (e.X > 0 && e.X < DrawPanel.Width && e.Y > 0 && e.Y < DrawPanel.Height)
                    HoveredShape.Points[SelectedPointNum] = e.Location;
            }
            else if (frames[frames.curFrame - 1].isSelectedArea)
            {
                frames[frames.curFrame - 1].AreaSelectionRect = new Rectangle(
                    AreaSelectionStartPoint.Value.X,
                    AreaSelectionStartPoint.Value.Y,
                    e.X,
                    AreaSelectionStartPoint.Value.Y,
                    e.X,
                    e.Y,
                    AreaSelectionStartPoint.Value.X,
                    e.Y);
            }

            if (e.X > 0 && e.X < DrawPanel.Width && e.Y > 0 && e.Y < DrawPanel.Height)
                if (!isPointPressed)
                    RefreshLineSelection(e.Location);

            DrawPanel.Refresh();
        }

        public Color getPixelColor(Control ctl, Point location)
        {
            Bitmap bmp = new Bitmap(1, 1);
            Graphics g = Graphics.FromImage(bmp);
            int x = (int)location.X;
            int y = (int)location.Y;
            Point screenP = ctl.PointToScreen(new Point(x, y));
            g.CopyFromScreen(screenP.X, screenP.Y, 0, 0, new Size(1, 1));
            Color col = bmp.GetPixel(0, 0);
            bmp.Dispose();
            return col;
        }

        private void DrawPanel_MouseDown(object sender, MouseEventArgs e)
        {
            RefreshLineSelection(e.Location);
            //SelectedShape = null;
            frames[frames.curFrame - 1].SelectedShapes.Clear();
            Refresh();
            frames[frames.curFrame - 1].isSelectedArea = false;
            frames[frames.curFrame - 1].LocalSelectedAxis = null;
            LocalCheckBox.Enabled = false;

            if (getPixelColor(DrawPanel, e.Location).ToArgb() == Color.DarkCyan.ToArgb())
                isPointPressed = true;
            else if (this.HoveredShape != null && Moving == null && !isPointPressed)
            {
                Moving = new MoveInfo
                {
                    Shape = HoveredShape,
                    StartPoints = new List<Point>(HoveredShape.Points),
                    StartMousePoint = e.Location
                };
            }
            else
            {
                frames[frames.curFrame - 1].isSelectedArea = true;
                AreaSelectionStartPoint = e.Location;
            }
            RefreshLineSelection(e.Location);
        }

        private void AddTriangle_Click(object sender, EventArgs e)
        {
            frames[frames.curFrame - 1].Shapes.Add(new Triangle(20, 20, 60, 140, 70, 90));
            DrawPanel.Refresh();
        }

        private void DrawPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (Moving != null)
            {
                if (Moving.StartMousePoint == e.Location)
                {
                    frames[frames.curFrame - 1].SelectedShapes.Add(Moving.Shape);
                    //SelectedShape = Moving.Shape;
                }
                else
                {
                    blinkShape = HoveredShape;
                    BlinkShapes.Add(HoveredShape);
                    Blinking(blinkCount);
                }
            }
            else if (frames[frames.curFrame - 1].isSelectedArea && AreaSelectionStartPoint != e.Location)
            {
                CalcSelectedShapes();
                if (frames[frames.curFrame - 1].SelectedShapes.Count != 0)
                    LocalCheckBox.Enabled = true;
                CalcLocalAxis();
            }

            frames[frames.curFrame - 1].isSelectedArea = false;
            AreaSelectionStartPoint = null;
            Moving = null;
            SelectedPoint = null;
            isPointPressed = false;
            RefreshLineSelection(e.Location);
        }

        private void CalcSelectedShapes()
        {
            foreach (Shape shape in frames[frames.curFrame - 1].Shapes)
            {
                bool isShapeInSelectionRect = false;

                //foreach (Point p in shape.Points)
                //{
                //    if (AreaSelectionRect.isPointInRect(p))
                //    {
                //        isShapeInSelectionRect = true;
                //        break;
                //    }
                //}

                List<Point> iterationPoints = new List<Point>();

                for (int i = 0; i < shape.Points.Count - 1; i++)
                {
                    int dx = (shape.Points[i + 1].X - shape.Points[i].X) / sideDivider;
                    int dy = (shape.Points[i + 1].Y - shape.Points[i].Y) / sideDivider;
                    for (int j = 0; j < sideDivider; j++)
                    {
                        //iterationPoints.Add(new Point(shape.Points[i].X + j*dx, shape.Points[i].Y + j*dy));
                        Point p = new Point(shape.Points[i].X + j * dx, shape.Points[i].Y + j * dy);
                        if (frames[frames.curFrame - 1].AreaSelectionRect.isPointInRect(p))
                        {
                            isShapeInSelectionRect = true;
                            break;
                        }                        
                    }
                }

                int dxend = (shape.Points[0].X - shape.Points[shape.Points.Count - 1].X) / sideDivider;
                int dyend = (shape.Points[0].Y - shape.Points[shape.Points.Count - 1].Y) / sideDivider;
                for (int j = 0; j < sideDivider; j++)
                {
                    Point p = new Point(shape.Points[shape.Points.Count - 1].X + j * dxend, shape.Points[shape.Points.Count - 1].Y + j * dyend);
                    if (frames[frames.curFrame - 1].AreaSelectionRect.isPointInRect(p))
                    {
                        isShapeInSelectionRect = true;
                        break;
                    }
                }

                if (isShapeInSelectionRect)
                    frames[frames.curFrame - 1].SelectedShapes.Add(shape);
            }
        }

        private void CalcLocalAxis()
        {
            if (frames[frames.curFrame - 1].SelectedShapes.Count <= 0)
                return;

            int xl = int.MaxValue,
                xr = int.MinValue,
                yt = int.MaxValue,
                yb = int.MinValue;

            foreach (Shape SelectedShape in frames[frames.curFrame - 1].SelectedShapes)
            {
                foreach (Point p in SelectedShape.Points)
                {
                    if (p.X <= xl) xl = p.X;
                    if (p.X >= xr) xr = p.X;
                    if (p.Y <= yt) yt = p.Y;
                    if (p.Y >= yb) yb = p.Y;
                }
            }

            frames[frames.curFrame - 1].LocalSelectedAxis = new Rectangle(xl - 3, yt - 3, xr + 3, yt - 3, xr + 3, yb + 3, xl - 3, yb + 3);
        }

        private void AddRectangle_Click(object sender, EventArgs e)
        {
            frames[frames.curFrame - 1].Shapes.Add(new Rectangle(20, 20, 40, 20, 40, 60, 20, 60));
            DrawPanel.Refresh();
        }

        private void RemoveShape_Click(object sender, EventArgs e)
        {
            if (frames[frames.curFrame - 1].SelectedShapes.Count == 0)
            {
                MessageBox.Show("Сначала выделите фигуру!");
                return;
            }

            //Shapes.Remove(SelectedShape);
            frames[frames.curFrame - 1].Shapes.RemoveAll(item => frames[frames.curFrame - 1].SelectedShapes.Contains(item));
            frames[frames.curFrame - 1].SelectedShapes.Clear();
            Refresh();
        }

        Point PointRealToAxis(Point p)
        {
            Point center = new Point(DrawPanel.Width / 2, DrawPanel.Height / 2);
            return new Point(p.X - center.X, center.Y - p.Y);
        }

        Point PointRealToLocalAxis(Point p)
        {
            Point center = new Point((frames[frames.curFrame - 1].LocalSelectedAxis.TopLeft.X + frames[frames.curFrame - 1].LocalSelectedAxis.BotRight.X) / 2, (frames[frames.curFrame - 1].LocalSelectedAxis.TopLeft.Y + frames[frames.curFrame - 1].LocalSelectedAxis.BotRight.Y) / 2);
            return new Point(p.X - center.X, center.Y - p.Y);
        }

        Point PointAxisToReal(double x, double y)
        {
            Point center = new Point(DrawPanel.Width / 2, DrawPanel.Height / 2);
            return new Point(Convert.ToInt32(x) + center.X, center.Y - Convert.ToInt32(y));
        }

        Point PointLocalAxisToReal(double x, double y)
        {
            Point center = new Point((frames[frames.curFrame - 1].LocalSelectedAxis.TopLeft.X + frames[frames.curFrame - 1].LocalSelectedAxis.BotRight.X) / 2, (frames[frames.curFrame - 1].LocalSelectedAxis.TopLeft.Y + frames[frames.curFrame - 1].LocalSelectedAxis.BotRight.Y) / 2);
            return new Point(Convert.ToInt32(x) + center.X, center.Y - Convert.ToInt32(y));
        }

        private void ExecuteOperations_Click(object sender, EventArgs e)
        {
            if (frames[frames.curFrame - 1].SelectedShapes.Count == 0)
            {
                MessageBox.Show("Сначала выделите фигуру!");
                return;
            }

            int angle, transformX, transformY;
            double scaleX, scaleY;
            string mirror = RadioMirrorNone.Checked ? "none" : RadioMirrorOX.Checked ? "x" : RadioMirrorOY.Checked ? "y" : "zero";

            try
            {
                scaleX = Convert.ToDouble(ScaleOX.Text.Replace('.', ','));
                scaleY = Convert.ToDouble(ScaleOY.Text.Replace('.', ','));
                if (scaleX <= 0 || scaleY <= 0)
                    throw new FormatException("Не может быть <= 0 в масштабировании");
                angle = Convert.ToInt32(RotateAngle.Text);
                transformX = Convert.ToInt32(TransferX.Text);
                transformY = Convert.ToInt32(TransferY.Text);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            bool isInArea = true;
            foreach (Shape SelectedShape in frames[frames.curFrame - 1].SelectedShapes)
            {
                // проверка на невыходимость за границы
                for (int i = 0; i < SelectedShape.Points.Count; i++)
                {
                    Point cur;

                    if (frames[frames.curFrame - 1].LocalSelectedAxis != null && LocalCheckBox.Checked)
                        cur = PointRealToLocalAxis(SelectedShape.Points[i]);
                    else
                        cur = PointRealToAxis(SelectedShape.Points[i]);

                    double curX = (double)cur.X;
                    double curY = (double)cur.Y;

                    // зеркалирование
                    if (mirror != "none")
                    {
                        if (mirror == "x")
                            curY = -curY;
                        else if (mirror == "y")
                            curX = -curX;
                        else
                        {
                            curY = -curY;
                            curX = -curX;
                        }
                    }

                    if (scaleX != 1)
                        curX = scaleX * curX;

                    if (scaleY != 1)
                        curY = scaleY * curY;

                    double curXtemp = curX;
                    double curYtemp = curY;
                    curX = (curXtemp * Math.Cos(angle * Math.PI / 180) - curYtemp * Math.Sin(angle * Math.PI / 180));
                    curY = (curXtemp * Math.Sin(angle * Math.PI / 180) + curYtemp * Math.Cos(angle * Math.PI / 180));


                    if (transformX != 0)
                        curX += transformX;

                    if (transformY != 0)
                        curY += transformY;

                    Point after;

                    if (frames[frames.curFrame - 1].LocalSelectedAxis != null && LocalCheckBox.Checked)
                        after = PointLocalAxisToReal(curX, curY);
                    else
                        after = PointAxisToReal(curX, curY);

                    if (!(after.X > 0 && after.X < DrawPanel.Width && after.Y > 0 && after.Y < DrawPanel.Height))
                    {
                        isInArea = false;
                        break;
                    }
                }
            }

            if (!isInArea)
            {
                MessageBox.Show("Ошибка. В результате преобразований фигура выйдет за пределы экрана.");
                return;
            }

            foreach (Shape SelectedShape in frames[frames.curFrame - 1].SelectedShapes)
            {
                for (int i = 0; i < SelectedShape.Points.Count; i++)
                {
                    Point cur;

                    if (frames[frames.curFrame - 1].LocalSelectedAxis != null && LocalCheckBox.Checked)
                        cur = PointRealToLocalAxis(SelectedShape.Points[i]);
                    else
                        cur = PointRealToAxis(SelectedShape.Points[i]);

                    double curX = (double)cur.X;
                    double curY = (double)cur.Y;

                    // зеркалирование
                    if (mirror != "none")
                    {
                        if (mirror == "x")
                            curY = -curY;
                        else if (mirror == "y")
                            curX = -curX;
                        else
                        {
                            curY = -curY;
                            curX = -curX;
                        }
                    }


                    if (scaleX != 1)
                        curX = scaleX * curX;

                    if (scaleY != 1)
                        curY = scaleY * curY;

                    double curXtemp = curX;
                    double curYtemp = curY;
                    curX = (curXtemp * Math.Cos(angle * Math.PI / 180) - curYtemp * Math.Sin(angle * Math.PI / 180));
                    curY = (curXtemp * Math.Sin(angle * Math.PI / 180) + curYtemp * Math.Cos(angle * Math.PI / 180));

                    if (transformX != 0)
                        curX += transformX;

                    if (transformY != 0)
                        curY += transformY;

                    if (frames[frames.curFrame - 1].LocalSelectedAxis != null && LocalCheckBox.Checked)
                        SelectedShape.Points[i] = PointLocalAxisToReal(curX, curY);
                    else
                        SelectedShape.Points[i] = PointAxisToReal(curX, curY);
                }
            }

            Refresh();
        }

        bool validateDoubleTextBox(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.' && e.KeyChar != ',' && e.KeyChar != '-'))
            {
                return false;
            }

            if ((e.KeyChar == '.' || e.KeyChar == ',' || e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('.') > -1 || (sender as TextBox).Text.IndexOf(',') > -1 || (sender as TextBox).Text.IndexOf('-') > -1))
            {
                return false;
            }

            return true;
        }

        private void ScaleOX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!validateDoubleTextBox(sender, e))
                e.Handled = true;
        }

        private void ScaleOY_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!validateDoubleTextBox(sender, e))
                e.Handled = true;
        }

        private void RotateAngle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!validateDoubleTextBox(sender, e))
                e.Handled = true;
        }

        private void TransferX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!validateDoubleTextBox(sender, e))
                e.Handled = true;
        }

        private void TransferY_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!validateDoubleTextBox(sender, e))
                e.Handled = true;
        }

        private void AddFrameButton_Click(object sender, EventArgs e)
        {
            frames.Add(new Frame());
            frames.curFrame = frames.Count;
            prevFrameButton.Enabled = true;
            RemoveFrameButton.Enabled = true;
            ShowAnimationButton.Enabled = true;
            FramesCountLabel.Text = String.Format("{0}/{1}", frames.curFrame, frames.Count);
            Refresh();
        }

        private void prevFrameButton_Click(object sender, EventArgs e)
        {
            frames.curFrame--;
            if (frames.curFrame == 1)
                prevFrameButton.Enabled = false;

            if (frames.curFrame < frames.Count)
                nextFrameButton.Enabled = true;

            FramesCountLabel.Text = String.Format("{0}/{1}", frames.curFrame, frames.Count);
            Refresh();
        }

        private void nextFrameButton_Click(object sender, EventArgs e)
        {
            frames.curFrame++;
            if (frames.curFrame == frames.Count)
                nextFrameButton.Enabled = false;

            if (frames.curFrame > 1)
                prevFrameButton.Enabled = true;

            FramesCountLabel.Text = String.Format("{0}/{1}", frames.curFrame, frames.Count);
            Refresh();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog1.FileName;
                FileStream file = new FileStream(fileName, FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(file, frames);
                file.Close();
            }
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;

                try
                {
                    FileStream file = new FileStream(fileName, FileMode.Open);
                    BinaryFormatter bf = new BinaryFormatter();
                    frames = (Frames)(bf.Deserialize(file));
                    file.Close();
                    FramesCountLabel.Text = String.Format("{0}/{1}", frames.curFrame, frames.Count);
                    Refresh();

                    nextFrameButton.Enabled = frames.curFrame < frames.Count ? true : false;
                    prevFrameButton.Enabled = frames.curFrame > 1 ? true : false;
                    RemoveFrameButton.Enabled = frames.Count > 1 ? true : false;
                    ShowAnimationButton.Enabled = frames.Count > 1 ? true : false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void RemoveFrameButton_Click(object sender, EventArgs e)
        {
            frames.RemoveAt(frames.curFrame - 1);

            if (frames.curFrame != 1)
                frames.curFrame--;

            nextFrameButton.Enabled = frames.curFrame < frames.Count ? true : false;
            prevFrameButton.Enabled = frames.curFrame > 1 ? true : false;

            FramesCountLabel.Text = String.Format("{0}/{1}", frames.curFrame, frames.Count);
            Refresh();

            if (frames.Count == 1)
            {
                RemoveFrameButton.Enabled = false;
                ShowAnimationButton.Enabled = false;
            }
        }

        private void ShowAnimationButton_Click(object sender, EventArgs e)
        {
           (new AnimationForm(frames)).ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
