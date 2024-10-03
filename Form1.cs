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
            PaintRectangles(g, startPoint, radius, color);
        }

        private void PaintRectangles(Graphics g, PointF startPoint, float radius, Color color)
        {
            int c = 5;
            int angle = -22;

            for (int i = 0; i < c; i++)
            {
                if (i < 2)
                {
                    PaintRectangle(g, startPoint, radius, color, angle, false);
                    angle += 44;
                }

                else if (i == 2)
                {
                    PaintRectangle(g, startPoint, radius, color, 45, true);

                    PaintRectangle(g, startPoint, radius - (radius / 5), color, 45, false);
                }

                else
                    PaintRectangle(g, startPoint, radius, color, 0, true);
            }
        }

        private void PaintLine(Graphics g, PointF startPoint, float radius, Color color, bool isDiagonal)
        {
            if (!isDiagonal)
            {
                Pen pen = new Pen(color, 2);
                PointF p1 = new PointF(startPoint.X - startPoint.X / 2, startPoint.Y);
                PointF p2 = new PointF(startPoint.X + startPoint.X / 2, startPoint.Y);
                g.DrawLine(pen, p1, p2);
                p1 = new PointF(startPoint.X, startPoint.Y - startPoint.Y / 2);
                p2 = new PointF(startPoint.X, startPoint.Y + startPoint.Y / 2);
                g.DrawLine(pen, p1, p2);
            }

            else
            {
                
            }
        }

        private void PaintCicle(Graphics g, PointF startPoint, float radius, Color color)
        {
            g.FillEllipse(new SolidBrush(color), startPoint.X - radius, startPoint.Y - radius, radius * 2, radius * 2);
            g.DrawEllipse(new Pen(Color.White, 6), startPoint.X - radius, startPoint.Y - radius, radius * 2, radius * 2);
        }

        private void PaintRectangle(Graphics g, PointF centerPoint, float radius, Color color, int angle, bool line)
        {
            Matrix matrix = new Matrix();
            matrix.RotateAt(angle, centerPoint);
            g.Transform = matrix;
            float rectangleWidth = radius * 1.4f;
            float rectangleHeight = radius * 1.4f;
            float rectangleX = centerPoint.X - (rectangleWidth / 2);
            float rectangleY = centerPoint.Y - (rectangleHeight / 2);

            g.FillRectangle(new SolidBrush(Color.Violet), rectangleX, rectangleY, rectangleWidth, rectangleHeight);

            if (line)
            {
                PaintLine(g, centerPoint, radius, color, false);
            }

            g.DrawRectangle(new Pen(Color.Black, 2), rectangleX, rectangleY, rectangleWidth, rectangleHeight);
            g.ResetTransform();
        }
    }
}
