using UniversitySchedule.EntityDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UniversitySchedule.PagesDatabase
{
    /// <summary>
    /// Логика взаимодействия для ChangeTimetable.xaml
    /// </summary>
    public partial class ChangeTimetable : Window
    {
        public static UniversityEntities _db = MainWindow.db;
        private int id;

        public ChangeTimetable()
        {
            InitializeComponent();
        }

        public ChangeTimetable(int id)
        {
            InitializeComponent();
            this.id = id;
            Timetables updateTimeTable = (from m in _db.Timetables
                                          where m.LINK == id
                                          select m).Single();
            x_number.Text=updateTimeTable.LINK.ToString();
            x_time_begin.Text = updateTimeTable.timetable_begin.ToString();
            x_time_end.Text = updateTimeTable.timetable_end.ToString();
        }

        private void Btnadd_timetable_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Timetables updateTimeTable = (from m in _db.Timetables
                                           where m.LINK == id
                                           select m).Single();
                updateTimeTable.LINK = Convert.ToInt32(x_number.Text);
                updateTimeTable.timetable_begin = TimeSpan.Parse(x_time_begin.Text);
                updateTimeTable.timetable_end = TimeSpan.Parse(x_time_end.Text);
                _db.SaveChanges();
                this.Close();
            }
            catch
            {
                this.Close();
            }
        }

        private void Btncancel_timetable_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }
    }
}
