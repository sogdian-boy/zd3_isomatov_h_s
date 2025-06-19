using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zd3_isomatov_h_s
{
    class PRoadWork : RoadWork
    {
        public int StrenghtCoff { get; set; }
        public string Weather { get; set; }
        public bool IsUrgent { get; set; }
        //конструктор
        public PRoadWork(double w, double l, double mpsm, string wt, DateTime sd, int sc, string weather, bool iu): base(w,l,mpsm,wt,sd)
        {
            StrenghtCoff = sc;
            Weather = weather;
            IsUrgent = iu;
        }
        //переопределенный метод
        public override double Q()
        {
            double baseQ = base.Q();
            if (StrenghtCoff >= 5 && StrenghtCoff <= 8)
            {
                return baseQ * 1.1;
            }
            else if (StrenghtCoff == 3 || StrenghtCoff == 4 || StrenghtCoff == 9 || StrenghtCoff == 10)
                return baseQ * 1.6;
            else
                return baseQ * 1.9;
        }
        //метод для получения подробной информации
        public override string Info()
        {
            return base.Info()
                +$"\nP: { StrenghtCoff}\n" +
                $"Погодные условия: {Weather}\n" +
                $"Качество продвинутого: {Q()}";
        }
    }
}
