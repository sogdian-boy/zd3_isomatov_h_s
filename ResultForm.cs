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
    public partial class ResultForm : Form
    {
        public ResultForm(List<RoadWork> works, string title)
        {
            InitializeComponent();
            this.Text = title;
            dataGridView1.DataSource = works;
            dataGridView1.AutoResizeColumns();
        }
        
    }
}
