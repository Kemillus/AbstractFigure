using System;
using System.Drawing;
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


        }
    }
}
