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
    public partial class FormParking : Form
    {
        Parking<ITransport> parking;
        private const int countLevel = 5;
        private GruzCar samosval;
        public FormParking()
        {
            InitializeComponent();
            parking = new Parking<ITransport>(20, pictureBoxParking.Width, pictureBoxParking.Height);
            Draw();
        }

        private void FormParking_Load(object sender, EventArgs e)
        {

        }
        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBoxParking.Width, pictureBoxParking.Height);
            Graphics gr = Graphics.FromImage(bmp);
            parking.Draw(gr);
            pictureBoxParking.Image = bmp;
        }

        private void TakeCar_Button_Click(object sender, EventArgs e)
        {
            if (maskedTextBox.Text != "")
            {
                var bus = parking - Convert.ToInt32(maskedTextBox.Text);
                if (bus != null)
                {
                    Bitmap bmp = new Bitmap(pictureBoxTakeCar.Width,
                    pictureBoxTakeCar.Height);
                    Graphics gr = Graphics.FromImage(bmp);
                    bus.SetPosition(5, 5, pictureBoxTakeCar.Width,
                    pictureBoxTakeCar.Height);
                    bus.DrawCar(gr);
                    pictureBoxTakeCar.Image = bmp;
                }
                else
                {
                    Bitmap bmp = new Bitmap(pictureBoxTakeCar.Width,
                   pictureBoxTakeCar.Height);
                    pictureBoxTakeCar.Image = bmp;
                }
                Draw();
            }
        }

        private void CreateSamosval_Button_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();     
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var car = new SamosvalCar(100, 1000, dialog.Color);
                int place = parking + car;
                Draw();
            }
        }

        private void CreateGruz_Button_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ColorDialog dialogDop = new ColorDialog();
                if (dialogDop.ShowDialog() == DialogResult.OK)
                {
                    var car = new GruzCar(100, 1000, dialog.Color, dialogDop.Color, false, 1, true);
                    int place = parking + car;
                    Draw();
                }
            }
        }
    }
}
