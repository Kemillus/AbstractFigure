using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace AbstractFigure
{
    public partial class Figure : Form
    {
        public Figure()
        {
            this.Paint += new PaintEventHandler(Painter);
            this.Height = 700;
            this.Width = 700;
        }

        private void Painter(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            PointF startPoint = new PointF(350, 350);
            float radius = 250;
            Color color = Color.Green;
            PaintCicle(g, startPoint, radius, color);
            PaintRectangle(g, startPoint, radius, color);
        }

        private void PaintCicle(Graphics g, PointF startPoint, float radius, Color color)
        {
            g.FillEllipse(new SolidBrush(color), startPoint.X - radius, startPoint.Y - radius, radius * 2, radius * 2);
            g.DrawEllipse(new Pen(Color.White, 6), startPoint.X - radius, startPoint.Y - radius, radius * 2, radius * 2);
        }



        private void PaintRectangle(Graphics g, PointF centerPoint, float radius, Color color)
        { 
            float rectangleWidth = radius * 1.4f;
            float rectangleHeight = radius * 1.4f;
            float rectangleX = centerPoint.X - (rectangleWidth / 2);
            float rectangleY = centerPoint.Y - (rectangleHeight / 2);

            g.FillRectangle(new SolidBrush(Color.Violet), rectangleX, rectangleY, rectangleWidth, rectangleHeight);
        }
    }
}
