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
    /// Логика взаимодействия для ChangeTypeweek.xaml
    /// </summary>
    public partial class ChangeTypeweek : Window
    {
        public static UniversityEntities _db = MainWindow.db;
        private int id;

        public ChangeTypeweek()
        {
            InitializeComponent();
        }

        public ChangeTypeweek(int id)
        {
            InitializeComponent();
            this.id = id;
            TypeWeek updateTypeweek = (from m in _db.TypeWeek
                                       where m.LINK == id
                                       select m).Single();
             x_name_typeweek.Text = updateTypeweek.Name_type_week;
        }

        private void Btnadd_typeweek_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TypeWeek updateTypeweek = (from m in _db.TypeWeek
                                          where m.LINK == id
                                          select m).Single();
                updateTypeweek.Name_type_week = x_name_typeweek.Text;
                _db.SaveChanges();
                this.Close();
            }
            catch
            {
                this.Close();
            }
        }

        private void Btncancel_typeweek_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }
    }
}
