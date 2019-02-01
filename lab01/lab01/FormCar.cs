using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab01
{
    public partial class FormCar : Form
    {
        private SamosvalCar samosval;
        public FormCar()
        {
            InitializeComponent();
        }
        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBoxCar.Width, pictureBoxCar.Height);
            Graphics gr = Graphics.FromImage(bmp);
            samosval.DrawCar(gr);
            pictureBoxCar.Image = bmp;
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            samosval = new SamosvalCar(rnd.Next(100, 300), rnd.Next(1000, 2000), Color.LightGreen,
            Color.Yellow, false, 1, true);
            samosval.SetPosition(rnd.Next(10, 100), rnd.Next(10, 100), pictureBoxCar.Width,
            pictureBoxCar.Height);
            Draw();
        }
        private void buttonMove_click(object sender, EventArgs e)
        {
            string name = (sender as Button).Name;
            switch (name)
            {
                case "Up":
                    samosval.MoveTransport(Direction.Up);
                    break;
                case "Down":
                    samosval.MoveTransport(Direction.Down);
                    break;
                case "Left":
                    samosval.MoveTransport(Direction.Left);
                    break;
                case "Right":
                    samosval.MoveTransport(Direction.Right);
                    break;
            }
            Draw();
        }
    }
}
