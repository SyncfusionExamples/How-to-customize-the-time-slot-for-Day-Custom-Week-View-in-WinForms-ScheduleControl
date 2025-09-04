using GridScheduleSample;
using Syncfusion.Schedule;
using Syncfusion.Windows.Forms.Schedule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScheduleControlDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SimpleScheduleDataProvider data;

            if (File.Exists("default.schedule"))
            {
                data = SimpleScheduleDataProvider.LoadBinary("default.schedule");
                data.FileName = "default.schedule";
            }

            else
            {
                data = new SimpleScheduleDataProvider();
                data.MasterList = new SimpleScheduleAppointmentList();
                data.FileName = "default.schedule";
            }
            this.scheduleControl1.ScheduleType = ScheduleViewType.Day;
            ScheduleAppointment item = data.MasterList.NewScheduleAppointment() as ScheduleAppointment;
            item.StartTime = DateTime.Now;
            item.EndTime = item.StartTime.AddDays(2);

            //item.BackColor = Color.Green;
            item.ForeColor = Color.Red;
            data.MasterList.Add(item);
           
            this.scheduleControl1.DataSource = data;
           
            this.scheduleControl1.Appearance.DivisionsPerHour = 4;
        }
    }
}
