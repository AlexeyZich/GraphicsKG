using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicModern
{
    public partial class AnimationForm : Form
    {
        Frames frames;
        public static int PointSize = 4;
        bool isPlay = false;
        //bool isPause = false;
        //bool isStop = false;

        public AnimationForm(Frames fr)
        {
            InitializeComponent();

            frames = new Frames();
            frames.AddRange(fr);
            frames.curFrame = 1;
            Slider.Maximum = frames.Count;
            RightSideLabel.Text = frames.Count.ToString();
        }

        private void DrawPanel_Paint(object sender, PaintEventArgs e)
        {
            Slider.Value = frames.curFrame;
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

                var color = frames[frames.curFrame - 1].SelectedShapes.Contains(shape) ? Color.LimeGreen : Color.Black;
                var pen = new Pen(color, 3);

                for (int i = 0; i < shape.Points.Count - 1; i++)
                    e.Graphics.DrawLine(pen, shape.Points[i], shape.Points[i + 1]);

                e.Graphics.DrawLine(pen, shape.Points[shape.Points.Count - 1], shape.Points[0]);

                for (int i = 0; i < shape.Points.Count; i++)
                    e.Graphics.FillEllipse(new SolidBrush(Color.DarkCyan), shape.Points[i].X - PointSize, shape.Points[i].Y - PointSize, PointSize * 2, PointSize * 2);
            }
        }

        async Task PutTaskDelay(int time)
        {
            await Task.Delay(time);
        }

        private async void PlayButton_Click(object sender, EventArgs e)
        {            
            int time;
            try
            {
                time = Convert.ToInt32(TimeTextBox.Text);
                if (time <= 0)
                    throw new Exception("Неверное значение временного интервала");
                isPlay = true;
                PlayButton.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            while (isPlay)
            {
                if (frames.curFrame == frames.Count)
                    frames.curFrame = 1;
                else
                    frames.curFrame++;

                Refresh();
                await PutTaskDelay(time);
                //System.Threading.Thread.Sleep(100);
            }
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            isPlay = false;
            PlayButton.Enabled = true;
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            isPlay = false;
            PlayButton.Enabled = true;
            frames.curFrame = 1;
            Refresh();
        }

        private void Slider_ValueChanged(object sender, EventArgs e)
        {
            frames.curFrame = Slider.Value;
            Refresh();
        }
    }
}
