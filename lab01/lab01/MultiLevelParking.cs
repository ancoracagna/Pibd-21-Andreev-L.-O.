﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab01
{
    class MultiLevelParking
    {
        List<Parking<ITransport>> parkingStages;
        /// <summary>
        /// Сколько мест на каждом уровне
        /// </summary>
        private const int countPlaces = 20;
        private int pictureWidth;
        /// <summary>
        /// Высота окна отрисовки
        /// </summary>
        private int pictureHeight;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="countStages">Количество уровенй парковки</param>
        /// <param name="pictureWidth"></param>
        /// <param name="pictureHeight"></param>
        public MultiLevelParking(int countStages, int pictureWidth, int pictureHeight)
        {
            parkingStages = new List<Parking<ITransport>>();
            this.pictureWidth = pictureWidth;
            this.pictureHeight = pictureHeight;
            for (int i = 0; i < countStages; ++i)
            {
                parkingStages.Add(new Parking<ITransport>(countPlaces, pictureWidth,
               pictureHeight));
            }
        }
        public Parking<ITransport> this[int ind]
        {
            get
            {
                if (ind > -1 && ind < parkingStages.Count)
                {
                    return parkingStages[ind];
                }
                return null;
            }
        }
        public bool SaveData(string filename)
        {
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                //Записываем количество уровней
                WriteToFile("CountLeveles:" + parkingStages.Count + Environment.NewLine,
               fs);
                foreach (var level in parkingStages)
                {
                    //Начинаем уровень
                    WriteToFile("Level" + Environment.NewLine, fs);
                    foreach (ITransport car in level)
                    {
                        //Записываем тип мшаины
                        if (car.GetType().Name == "SamosvalCar")
                        {
                            WriteToFile(level.GetKey + ":SamosvalCar:", fs);
                        }
                        if (car.GetType().Name == "GruzCar")
                        {
                            WriteToFile(level.GetKey + ":GruzCar:", fs);
                        }
                        //Записываемые параметры
                        WriteToFile(car + Environment.NewLine, fs);
                    }
                }
            }
            return true;
        }

        private void WriteToFile(string text, FileStream stream)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(text);
            stream.Write(info, 0, info.Length);
        }
        public bool LoadData(string filename)
        {
            if (!File.Exists(filename))
            {
                throw new FileNotFoundException();
            }
            string bufferTextFromFile = "";
            using (FileStream fs = new FileStream(filename, FileMode.Open))
            {
                byte[] b = new byte[fs.Length];
                UTF8Encoding temp = new UTF8Encoding(true);
                while (fs.Read(b, 0, b.Length) > 0)
                {
                    bufferTextFromFile += temp.GetString(b);
                }
            }
            bufferTextFromFile = bufferTextFromFile.Replace("\r", "");
            var strs = bufferTextFromFile.Split('\n');
            if (strs[0].Contains("CountLeveles"))
            {
                //считываем количество уровней
                int count = Convert.ToInt32(strs[0].Split(':')[1]);
                if (parkingStages != null)
                {
                    parkingStages.Clear();
                }
                parkingStages = new List<Parking<ITransport>>(count);
            }
            else
            {
                //если нет такой записи, то это не те данные
                return false;
            }
            int counter = -1;
            ITransport car = null;
            for (int i = 1; i < strs.Length; ++i)
            {
                //идем по считанным записям
                if (strs[i] == "Level")
                {
                    //начинаем новый уровень
                    counter++;
                    parkingStages.Add(new Parking<ITransport>(countPlaces, pictureWidth,
                   pictureHeight));
                    continue;
                }
                if (string.IsNullOrEmpty(strs[i]))
                {
                    continue;
                }
                if (strs[i].Split(':')[1] == "Car")
                {
                    car = new SamosvalCar(strs[i].Split(':')[2]);
                }
                else if (strs[i].Split(':')[1] == "SportCar")
                {
                    car = new GruzCar(strs[i].Split(':')[2]);
                }
                parkingStages[counter][Convert.ToInt32(strs[i].Split(':')[0])] = car;
            }
            return true;
        }
        public void Sort()
        {
            parkingStages.Sort();
        }
    }
}
       