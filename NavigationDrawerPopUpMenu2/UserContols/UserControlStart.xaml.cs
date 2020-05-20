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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UniversitySchedule.UserContols
{
    /// <summary>
    /// Логика взаимодействия для UserControlStart.xaml
    /// </summary>
    public partial class UserControlStart : UserControl
    {
        private static UniversityEntities db = MainWindow.db;
        // Таймер
        System.Windows.Forms.Timer timer02 = new System.Windows.Forms.Timer();

        public UserControlStart()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            List<Timesheet> tbl = db.Timesheet.Where(x => x.F_timetable.Equals(x.Timetables.LINK)).ToList();            
            foreach (var m in tbl)
            {
                //MessageBox.Show(((int)DateTime.Now.DayOfWeek).ToString());
                if (DateTime.Now.TimeOfDay > m.Timetables.timetable_begin && DateTime.Now.TimeOfDay < m.Timetables.timetable_end && (int)DateTime.Now.DayOfWeek == m.F_days)
                {
                    Raspisanie.Children.Add(CreateTextBlock(m.audience.ToString() + " - " + m.subject.ToString() + ", преподаватель " + m.Teachers.Name_teacher ));
                }
            }

            // Инициализация таймера
            timer02.Interval = 1000;
            timer02.Tick += Timer02_Tick;
            timer02.Start();
        }

        private void Timer02_Tick(object sender, EventArgs e)
        {
            try
            {
                if (MainWindow.NowTimetable == 0)
                {
                    Timetables updatetimetable = (from element in db.Timetables
                                                  where element.LINK == MainWindow.NowTimetable + 1
                                                  select element).Single();
                    time.Text = "Текущее время: " + (DateTime.Now.TimeOfDay).ToString(@"hh\:mm\:ss");
                    time2.Text = "До следующей пары: " + (updatetimetable.timetable_begin - DateTime.Now.TimeOfDay).ToString(@"hh\:mm\:ss");
                }
                else
                {
                    Timetables updatetimetable = (from element in db.Timetables
                                                  where element.LINK == MainWindow.NowTimetable
                                                  select element).Single();
                    time.Text = "Текущее время: " + (DateTime.Now.TimeOfDay).ToString(@"hh\:mm\:ss");
                    time2.Text = "До конца пары: " + (updatetimetable.timetable_end - DateTime.Now.TimeOfDay).ToString(@"hh\:mm\:ss"); 
                }
            }
            catch {  }
        }

        private TextBlock CreateTextBlock(string name)
        {
            TextBlock element = new TextBlock();
            element.Text = name;
            element.Margin = new Thickness(10);
            //element.Background = Brushes.White;
            element.TextAlignment = TextAlignment.Center;
            element.Foreground = Brushes.Black;
            element.FontSize = 14;
            return element;
        }
    }
}
