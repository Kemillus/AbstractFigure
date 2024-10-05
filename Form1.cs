using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace AbstractFigure
{
    public partial class Figure : Form
    {
        private Pen _pen;
        private Brush _brush;

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
            _pen = new Pen(Color.Black, 5);
            _brush = new SolidBrush(Color.White);
            PointF startPoint = new PointF(350, 350);
            float radius = 250;

            PaintCicle(g, startPoint, radius);
            PaintRectangles(g, startPoint, radius);
        }

        private void PaintRectangles(Graphics g, PointF startPoint, float radius)
        {
            int c = 5;
            int angle = -22;

            for (int i = 0; i < c; i++)
            {
                if (i < 2)
                {
                    PaintRectangle(g, startPoint, radius, angle, false, false);
                    angle += 44;
                }

                else if (i == 2)
                {
                    PaintRectangle(g, startPoint, radius, 45, true, true);
                    PaintRectangle(g, startPoint, radius - (radius / 5), 45, false, false);
                }

                else
                {
                    PaintRectangle(g, startPoint, radius, 0, true, false);
                    PaintRectangle(g, startPoint, radius - (radius/5), 0, true, true);

                    float r = radius / 1.8f;
                    for (int j = 0; j < 3; j++)
                    {
                        PaintRectangle(g, startPoint, r, 45, false, false);
                        r -= radius / 5;
                    }
                }
            }
        }

        private void PaintLine(Graphics g, PointF startPoint, float radius, bool isDiagonal, int angle)
        {
            if (!isDiagonal)
            {
                PointF p1 = new PointF(startPoint.X - startPoint.X / 2, startPoint.Y);
                PointF p2 = new PointF(startPoint.X + startPoint.X / 2, startPoint.Y);
                g.DrawLine(_pen, p1, p2);
                p1 = new PointF(startPoint.X, startPoint.Y - startPoint.Y / 2);
                p2 = new PointF(startPoint.X, startPoint.Y + startPoint.Y / 2);
                g.DrawLine(_pen, p1, p2);
            }

            else
            {
                RotateMatrix(g, startPoint, angle + 45);
                PointF p1 = new PointF(startPoint.X - radius, startPoint.Y);
                PointF p2 = new PointF(startPoint.X + radius, startPoint.Y);
                g.DrawLine(_pen, p1, p2);
                p1 = new PointF(startPoint.X, startPoint.Y - radius);
                p2 = new PointF(startPoint.X, startPoint.Y + radius);
                g.DrawLine(_pen, p1, p2);
            }
        }

        private void PaintCicle(Graphics g, PointF startPoint, float radius)
        {
            g.FillEllipse(_brush, startPoint.X - radius, startPoint.Y - radius, radius * 2, radius * 2);
            g.DrawEllipse(_pen, startPoint.X - radius, startPoint.Y - radius, radius * 2, radius * 2);
        }

        private void PaintRectangle(Graphics g, PointF centerPoint, float radius, int angle, bool line, bool isDiagonal)
        {
            RotateMatrix(g, centerPoint, angle);
            float rectangleWidth = radius * 1.4f;
            float rectangleHeight = radius * 1.4f;
            float rectangleX = centerPoint.X - (rectangleWidth / 2);
            float rectangleY = centerPoint.Y - (rectangleHeight / 2);

            g.FillRectangle(_brush, rectangleX, rectangleY, rectangleWidth, rectangleHeight);
            g.DrawRectangle(_pen, rectangleX, rectangleY, rectangleWidth, rectangleHeight);

            if (line)
            {
                PaintLine(g, centerPoint, radius, isDiagonal, angle);
            }

            g.ResetTransform();
        }

        private void RotateMatrix(Graphics g, PointF centerPoint, int angle)
        {
            g.ResetTransform();
            Matrix matrix = new Matrix();
            matrix.RotateAt(angle, centerPoint);
            g.Transform = matrix;
        }
    }
}
