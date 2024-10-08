using GraphBuilder.App.Models;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace GraphBuilder.App.Views
{
    partial class GraphViewer : UserControl
    {
        private const double InitialZoomFactor = 40.0;
        private double _zoomFactor = InitialZoomFactor;
        private const int GridSize = (int)InitialZoomFactor;
        private FormulaRegistry? _registry;

        public GraphViewer()
        {
            InitializeComponent();
            DoubleBuffered = true;
            ResizeRedraw = true;
        }

        public void Redraw(FormulaRegistry registry)
        {
            if (registry == null)
            {
                return;
            }

            _registry = registry;

            Invalidate();
            Refresh(); ;
        }

        private void DrawGraph(Graphics g, FormulaContext ctx, int width, int height)
        {
            var function = (double x) => new FormulaEvaluator(ctx, x).Evaluate();

            Pen graphPen = new Pen(ctx.LineColor, 2);

            int centerX = width / 2;
            int centerY = height / 2;

            PointF[] graphPoints = new PointF[width];
            var curvePoints = new List<PointF>();

            var draw = () =>
            {
                try
                {
                    if (ctx.InterpolationMode == Models.InterpolationMode.LineInterpolation)
                    {
                        g.DrawLines(graphPen, curvePoints.ToArray());
                    }
                    else
                    {
                        g.SmoothingMode = SmoothingMode.HighQuality;
                        g.DrawCurve(graphPen, curvePoints.ToArray());
                        g.SmoothingMode = SmoothingMode.Default;
                    }
                }
                catch (Exception)
                {
                    // Do nothing..
                }
            };

            for (int i = 0; i < width; i++)
            {
                float x = (i - centerX) / (float)_zoomFactor;
                float y = (float)(centerY - function(x) * _zoomFactor);

                if (float.IsInfinity(y) || float.IsNaN(y))
                {
                    if (curvePoints.Count >= 2)
                    {
                        draw();
                    }
                    curvePoints.Clear();
                    continue;
                }

                curvePoints.Add(new PointF(i, y));
            }

            try
            {
                if (curvePoints.Count >= 2)
                {
                    draw();
                }
            }
            catch (Exception)
            {
                // Do nothing...
            }
        }

        private void DrawGrid(Graphics g, int width, int height)
        {
            Pen gridPen = new Pen(Color.LightGray);

            // Рассчитать центр виджета. 
            int centerX = width / 2;
            int centerY = height / 2;

            // Нарисовать вертикальные линии сетки. 
            for (int i = centerX % GridSize; i < width; i += GridSize)
            {
                g.DrawLine(gridPen, i, 0, i, height);
                DrawNumericMarking(g, i, centerY, (i - centerX) / _zoomFactor, true);
            }

            // Нарисовать горизонтальные линии сетки. 
            for (int i = centerY % GridSize; i < height; i += GridSize)
            {
                g.DrawLine(gridPen, 0, i, width, i);
                DrawNumericMarking(g, centerX, i, (centerY - i) / _zoomFactor, false);
            }

            // Нарисовать оси F(x) и X.
            Pen axisPen = new Pen(Color.Black, 2);
            g.DrawLine(axisPen, centerX, 0, centerX, height);
            g.DrawLine(axisPen, 0, centerY, width, centerY);

            // Подписать оси.
            Font axisLabelFont = new Font("Arial", 10);
            Brush axisLabelBrush = Brushes.Black;
            g.DrawString("X", axisLabelFont, axisLabelBrush, new Point(width - 20, centerY - 20));
            g.DrawString("F(x)", axisLabelFont, axisLabelBrush, new Point(centerX + 10, 10));
        }

        private void DrawNumericMarking(Graphics g, int x, int y, double value, bool isVertical)
        {
            Font markingFont = new Font("Arial", 8);
            Brush markingBrush = Brushes.Black;

            string valueString = value.ToString("0.##");
            SizeF textSize = g.MeasureString(valueString, markingFont);

            int textX = x - (int)(textSize.Width / 2);
            int textY = y - (int)(textSize.Height / 2);

            if (isVertical)
            {
                textY += 5; 
            }
            else
            {
                textX -= (int)textSize.Width - 5;
            }

            g.DrawString(valueString, markingFont, markingBrush, new Point(textX, textY));
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            double zoomDelta = e.Delta > 0 ? 1.1 : 0.9;
            _zoomFactor *= zoomDelta;
            Refresh();
        }

        protected override void OnResize(EventArgs e)
        {
            Redraw(_registry!);
            Refresh();
        }

        private void GraphViewer_Paint(object sender, PaintEventArgs e)
        {
            if (_registry == null)
            {
                return;
            }

            DrawGrid(e.Graphics, Width, Height);

            for (int i = 0; i < _registry.Size; i++)
            {
                if (_registry.IsEnabled(i))
                {
                    FormulaContext ctx = _registry.GetContext(i);
                    DrawGraph(e.Graphics, ctx, Width, Height);
                }
            }
        }

        private void GraphViewer_DoubleClick(object sender, EventArgs e)
        {
            _zoomFactor = InitialZoomFactor;
            Invalidate();
            Refresh();
        }
    }
}
