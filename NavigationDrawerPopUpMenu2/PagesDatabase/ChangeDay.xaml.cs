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
    /// Логика взаимодействия для ChangeDay.xaml
    /// </summary>
    public partial class ChangeDay : Window
    {
        public static UniversityEntities _db = MainWindow.db;
        private int id;

        public ChangeDay()
        {
            InitializeComponent();
        }

        public ChangeDay(int id)
        {
            InitializeComponent();
            this.id = id;
            Days updateDay = (from m in _db.Days
                              where m.LINK == id
                              select m).Single();
            x_name_day.Text = updateDay.days1;
        }

        private void Btnadd_day_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Days updateDay = (from m in _db.Days
                                       where m.LINK == id
                                       select m).Single();
                updateDay.days1 = x_name_day.Text;
                _db.SaveChanges();
                this.Close();
            }
            catch
            {
                this.Close();
            }
        }

        private void Btncancel_day_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }
    }
}
