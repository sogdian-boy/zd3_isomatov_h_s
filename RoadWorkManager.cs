using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
namespace zd3_isomatov_h_s
{
    class RoadWorkManager
    {
        private List<RoadWork> roadWorks = new List<RoadWork>();
        private Dictionary<int, RoadWork> roadWorksDict = new Dictionary<int, RoadWork>();
        private int nextID = 1;
        //Добавление работ
        public void AddRoadWork(RoadWork work)
        {
            roadWorks.Add(work);
            roadWorksDict.Add(nextID++,work);
        }
        public void AddRoadWork(double width, double lenght, double mass, string workType, DateTime startTime)
        {
            RoadWork work = new RoadWork(width, lenght, mass, workType, startTime);
            roadWorks.Add(work);
            roadWorksDict.Add(nextID++, work);
        }
        // Методы для удаления (2 перегрузки)
        public bool RemoveRoadWork(RoadWork work)
        {
            var key = roadWorksDict.FirstOrDefault(x => x.Value == work).Key;
            if (key != 0)
            {
                roadWorksDict.Remove(key);
            }
            return roadWorks.Remove(work);
        }
        public bool RemoveRoadWork(int id)
        {
            if (roadWorksDict.TryGetValue(id, out var work))
            {
                roadWorksDict.Remove(id);
                roadWorks.Remove(work);
                return true;
            }
            return false;
        }
        public void RemoveRoadWork(string width, string lenght, string mass, string type)
        {
            var workToRemove = GetAllWorks()
    .FirstOrDefault(w =>
        w.Width.ToString() == width &&
        w.Lenght.ToString() == lenght &&
        w.MassPerSqMeter.ToString() == mass &&
        w.WorkType == type);

            if (workToRemove != null)
            {
                if (RemoveRoadWork(workToRemove))
                {
                    MessageBox.Show("Работа успешно удалена");
                }
                else
                {
                    MessageBox.Show("Не удалось удалить работу");
                }
            }
        }
        // Получение всех работ
        public IEnumerable<RoadWork> GetAllWorks()
        {
            return roadWorks;
        }
     
    }
}