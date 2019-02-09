using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab01
{
    public class GruzCar : SamosvalCar
    {
        public Color DopColor { private set; get; }
        public bool Toner { private set; get; }
        public Color WhellColor { private set; get; }
        public double Kuzovsize { private set; get; }
        public bool Line { private set; get; }

        public GruzCar(int maxSpeed, float weight, Color mainColor, Color dopColor, bool
       toner, double kuzovsize, bool line) : base(maxSpeed, weight, mainColor)
        {
            DopColor = dopColor;
            Toner = toner;
            Kuzovsize = kuzovsize;
            Line = line;
        }
        public GruzCar(string info) : base(info)
        {
            string[] strs = info.Split(';');
            if (strs.Length == 8)
            {
            MaxSpeed = Convert.ToInt32(strs[0]);
                Weight = Convert.ToInt32(strs[1]);
                MainColor = Color.FromName(strs[2]);
                DopColor = Color.FromName(strs[3]);
                Toner = Convert.ToBoolean(strs[4]);
                Kuzovsize = Convert.ToInt32(strs[5]);
                Line = Convert.ToBoolean(strs[6]);
            }
        }

        public override void DrawCar(Graphics g)
        {
            Pen pen = new Pen(Color.Black);
            Pen bpen = new Pen(Color.Black);
            Brush brush = new SolidBrush(MainColor);
            Brush kuzov = new SolidBrush(DopColor);
            Brush whellc = new SolidBrush(WhellColor);
            Brush white = new SolidBrush(Color.White);
            Brush toner = new SolidBrush(Color.Black);
            base.DrawCar(g);
            if (Toner)
            {
                g.DrawRectangle(pen, _startPosX + 55, _startPosY, 15, 15);
                g.FillRectangle(toner, _startPosX + 55, _startPosY, 15, 15);
            }
            if (Line)
            {
                g.DrawRectangle(pen, _startPosX + 80, _startPosY + 15, 80, 10);
                g.FillRectangle(kuzov, _startPosX + 80, _startPosY + 15, 80, 10);
            }
            if (Kuzovsize != 0)
            {
                g.DrawRectangle(pen, _startPosX + 80, _startPosY - 6, 80 * (int)Kuzovsize, 40);
                g.FillRectangle(brush, _startPosX + 80, _startPosY - 6, 80 * (int)Kuzovsize, 40);
            }
        }
        public void SetDopColor(Color color)
        {
            DopColor = color;
        }
        public override string ToString()
        {
            return base.ToString() + ";" + DopColor.Name + ";" + FrontSpoiler + ";" +
           SideSpoiler + ";" + BackSpoiler + ";" + CountLines;
        }

    }
}
