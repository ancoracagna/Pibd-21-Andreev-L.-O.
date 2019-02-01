using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab01
{
    class SamosvalCar
    {
        protected float _startPosX;

        protected float _startPosY;

        protected int _pictureWidth;

        protected int _pictureHeight;

        private const int carWidth = 140;

        private const int carHeight = 25;

        public int MaxSpeed { protected set; get; }

        public float Weight { protected set; get; }

        public Color MainColor { protected set; get; }
        public Color DopColor { private set; get; }
        public bool Toner { private set; get; }
        public Color WhellColor { private set; get; }
        public double Kuzovsize { private set; get; }
        public bool Line { private set; get; }

        public SamosvalCar(int maxSpeed, float weight, Color mainColor, Color dopColor, bool
       toner, double kuzovsize, bool line)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            DopColor = dopColor;
            Toner = toner;
            Kuzovsize = kuzovsize;
            Line = line;
        }

        public void SetPosition(int x, int y, int width, int height)
        {
            _startPosX = x;
            _startPosY = y;
            _pictureWidth = width;
            _pictureHeight = height;
        }

        public void MoveTransport(Direction direction)
        {
            float step = MaxSpeed * 100 / Weight;
            switch (direction)
            {
                // вправо
                case Direction.Right:
                    if (_startPosX + step < _pictureWidth - carWidth)
                    {
                        _startPosX += step;
                    }
                    break;
                //влево
                case Direction.Left:
                    if (_startPosX - step > 0)
                    {
                        _startPosX -= step;
                    }
                    break;
                //вверх
                case Direction.Up:
                    if (_startPosY - step > 0)
                    {
                        _startPosY -= step;
                    }
                    break;
                //вниз
                case Direction.Down:
                    if (_startPosY + step < _pictureHeight - carHeight)
                    {
                        _startPosY += step;
                    }
                    break;
            }
        }

        public void DrawCar(Graphics g)
        {
            Pen pen = new Pen(Color.Black);
            Pen bpen = new Pen(Color.Black);
            Brush brush = new SolidBrush(MainColor);
            Brush kuzov = new SolidBrush(Color.Yellow);
            Brush whellc = new SolidBrush(Color.Black);
            Brush white = new SolidBrush(Color.White);
            Brush toner = new SolidBrush(Color.Black);
            // КУЗОВ
            g.DrawRectangle(pen, _startPosX + 80, _startPosY + 15, 80, 20);
            g.FillRectangle(brush, _startPosX + 80, _startPosY + 15, 80, 20);
            //   g.DrawLine(bpen, _startPosX, _startPosY);
            // КОЛЕСА
            g.DrawEllipse(pen, _startPosX + 140, _startPosY + 25, 20, 20);
            g.DrawEllipse(pen, _startPosX + 80, _startPosY + 25, 20, 20);
            g.FillEllipse(whellc, _startPosX + 140, _startPosY + 25, 20, 20);
            g.FillEllipse(whellc, _startPosX + 80, _startPosY + 25, 20, 20);
            // ПЕРЕДНЯЯ ЧАСТЬ КУЗОВА
            g.DrawRectangle(pen, _startPosX + 50, _startPosY - 5, 30, 30);
            g.FillRectangle(kuzov, _startPosX + 50, _startPosY - 5, 30, 30);
            g.DrawRectangle(pen, _startPosX + 55, _startPosY, 15, 15);
            g.FillRectangle(white, _startPosX + 55, _startPosY, 15, 15);
        }
    }
}