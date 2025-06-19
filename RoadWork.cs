using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zd3_isomatov_h_s
{
    public class RoadWork
    {
        public double Width;
        public double Lenght;
        public double MassPerSqMeter { get; set; }
        //Доп поля
        public string WorkType { get; set; }
        public DateTime StartDate { get; set; }
        //Свойства
        public double WIDTH
        {
            get
            {
                return Width;
            }
            set
            {
                Width = value;
            }
        }
        public double LENGHT
        {
            get
            {
                return Lenght;
            }
            set
            {
                Lenght = value;
            }
        }
        //Конструктор
        public RoadWork(double w, double l, double mpsm, string wt, DateTime sd)
        {
            Width = w;
            Lenght = l;
            MassPerSqMeter = mpsm;
            WorkType = wt;
            StartDate = sd;
        }
        //Расчет Q
        public virtual double Q()
        {
            return Width * Lenght * MassPerSqMeter / 1000;
        }
        //Информация о работах
        public virtual string Info()
        {
            return $"Дорожные работы: {WorkType}\n" +
                $"Ширина: {Width}м, Длина: {Lenght}м\n" +
                $"Масса покрытия: {MassPerSqMeter}кв.м\n" +
                $"Дата начала: {StartDate}\n" +
                $"Базовое качество: {Q()}";
        }

    }
}
