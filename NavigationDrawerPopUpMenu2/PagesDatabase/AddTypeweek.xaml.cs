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
    /// Логика взаимодействия для AddTypeweek.xaml
    /// </summary>
    public partial class AddTypeweek : Window
    {
        public static UniversityEntities _db = MainWindow.db;

        public AddTypeweek()
        {
            InitializeComponent();
        }

        private void Btnadd_typeweek_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TypeWeek newTypeweek = new TypeWeek()
                {
                    Name_type_week = x_name_typeweek.Text.ToString()
                };
                _db.TypeWeek.Add(newTypeweek);
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
