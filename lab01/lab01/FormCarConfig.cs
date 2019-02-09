﻿using System;
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
    public partial class FormCarConfig : Form
    {
        ITransport car = null;


        private event carDelegate eventAddCar;

        public FormCarConfig()
        {
            InitializeComponent();
            panelBlack.MouseDown += panelColor_MouseDown;
            panelGreen.MouseDown += panelColor_MouseDown;
            panelRed.MouseDown += panelColor_MouseDown;
            panelWhite.MouseDown += panelColor_MouseDown;
            panelYellow.MouseDown += panelColor_MouseDown;
            panelBlue.MouseDown += panelColor_MouseDown;
            buttonCancel.Click += (object sender, EventArgs e) => { Close(); };
        }

        private void panelColor_MouseDown(object sender, MouseEventArgs e)
        {
            (sender as Control).DoDragDrop((sender as Control).BackColor,
           DragDropEffects.Move | DragDropEffects.Copy);
        }

        private void DrawCar()
        {
            if (car != null)
            {
                Bitmap bmp = new Bitmap(pictureBoxCar.Width, pictureBoxCar.Height);
                Graphics gr = Graphics.FromImage(bmp);
                car.SetPosition(5, 5, pictureBoxCar.Width, pictureBoxCar.Height);
                car.DrawCar(gr);
                pictureBoxCar.Image = bmp;
            }
        }
        public void AddEvent(carDelegate ev)
        {
            if (eventAddCar == null)
            {
                eventAddCar = new carDelegate(ev);
            }
            else
            {
                eventAddCar += ev;
            }
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            labelSamosval.DoDragDrop(labelSamosval.Text, DragDropEffects.Move |DragDropEffects.Copy);
        }

        private void labelGruz_MouseDown(object sender, MouseEventArgs e)
        {
            labelGruz.DoDragDrop(labelGruz.Text, DragDropEffects.Move |DragDropEffects.Copy);
        }

        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            switch (e.Data.GetData(DataFormats.Text).ToString())
            {
                case "Обычный автомобиль":
                    car = new SamosvalCar(100, 500, Color.White);
                    break;
                case "Гоночный автомобиль":
                    car = new GruzCar(100, 500, Color.White, Color.Black, true, 2, true);
                    break;
            }
            DrawCar();
        }

        private void label2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Color)))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void labelBaseColor_DragDrop(object sender, DragEventArgs e)
        {
            if (car != null)
            {
             car.SetMainColor((Color)e.Data.GetData(typeof(Color)));
                DrawCar();
            }
        }

        private void labelAddColor_DragDrop(object sender, DragEventArgs e)
        {
            if (car != null)
            {
                if (car is GruzCar)
                {
                    (car as GruzCar).SetDopColor((Color)e.Data.GetData(typeof(Color)));
                    DrawCar();
                }
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            eventAddCar?.Invoke(car);
            Close();
        }
    }
}    

