using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace zd3_isomatov_h_s
{
    public partial class RoadWorks : Form
    {
        private RoadWorkManager manager = new RoadWorkManager();
        public RoadWorks()
        {
            InitializeComponent();
            CreateWorks();
            UpdateData();
        }
        public void CreateWorks()
        {
            //Добавление обычной работы
            manager.AddRoadWork(10, 100, 50, "Асфальтирование", new DateTime(2025, 05, 20));
            manager.AddRoadWork(8, 150, 45, "Ремонт покрытия", new DateTime(2025, 06, 20));
            //Добавление улучшенной работы
            PRoadWork pWork = new PRoadWork(12, 200, 60, "Капитальный ремонт", new DateTime(2025, 07, 20), 6, "Ясно", false);
            manager.AddRoadWork(pWork);
            PRoadWork pWork2 = new PRoadWork(15, 250, 55, "Строительство новой дороги", new DateTime(2025, 08, 20), 4, "Дождь", true);
            manager.AddRoadWork(pWork2);
        }
        //обновление dataGrid
        private void UpdateData()
        {
            dataGridView1.DataSource = manager.GetAllWorks().ToList();
            dataGridView1.AutoResizeColumns();
        }
        //кнопка удаления
           private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow?.DataBoundItem is RoadWork work)
            {
                manager.RemoveRoadWork(work);
                UpdateData();
            }
        }
        //кнопка показать подробности
        private void btnShowDetails_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow?.DataBoundItem is RoadWork work)
            {
                MessageBox.Show(work.Info(), "Подробная информация");
            }
        }
        //кнопка добавить обычную работу
        private void добавитьОбычныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value > 0 && LenghtLbl.Value > 0 && numericUpDown3.Value > 0 && typeWorkTxt.Text != "")
            {
                manager.AddRoadWork((double)numericUpDown1.Value, (double)LenghtLbl.Value, (double)numericUpDown3.Value, typeWorkTxt.Text, (DateTime)startDate.Value);
                UpdateData();
            }
            else
            {
                MessageBox.Show("Данные заполнены неккоректно!");
            }
        }
        //кнопка добавить продвинутую работу
        private void добавитьПродвинутыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value > 0 && LenghtLbl.Value > 0 && numericUpDown3.Value > 0 && typeWorkTxt.Text != "" && textBox2.Text != "" && comboBox1.SelectedIndex != -1&&(int) numericUpDown3.Value !=0)
            {
                PRoadWork pWork = new PRoadWork((double)numericUpDown1.Value, (double)LenghtLbl.Value, (double)numericUpDown3.Value, typeWorkTxt.Text, (DateTime)startDate.Value,(int) numericUpDown3.Value, "Ясно", comboBox1.SelectedIndex==0);
                manager.AddRoadWork(pWork);
                UpdateData();
            }
            else
            {
                MessageBox.Show("Данные заполнены неккоректно!");
            }
        }
        //обработчик удаления двойным кликом
        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                var selectedRow = dataGridView1.Rows[e.RowIndex];
                string Width = selectedRow.Cells[3].Value?.ToString();
                string Lenght = selectedRow.Cells[4].Value?.ToString();
                string mass = selectedRow.Cells[0].Value?.ToString();
                string type = selectedRow.Cells[1].Value?.ToString();
                    var result = MessageBox.Show($"Удалить работу?", "Подтвердите", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    manager.RemoveRoadWork(Width,Lenght,mass,type);
                    UpdateData();
                }
            }
        }
    }
}