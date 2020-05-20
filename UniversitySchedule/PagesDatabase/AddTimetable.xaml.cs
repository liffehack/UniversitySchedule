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
    /// Логика взаимодействия для AddTimetable.xaml
    /// </summary>
    public partial class AddTimetable : Window
    {
        public static UniversityEntities _db = MainWindow.db;

        public AddTimetable()
        {
            InitializeComponent();
        }

        private void Btnadd_timetable_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Timetables newTimeTable = new Timetables()
                {
                    LINK = Convert.ToInt32(x_number.Text),
                    timetable_begin = TimeSpan.Parse(x_time_begin.Text),
                    timetable_end = TimeSpan.Parse(x_time_end.Text)

                };
                _db.Timetables.Add(newTimeTable);
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
