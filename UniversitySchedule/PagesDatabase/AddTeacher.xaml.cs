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
    /// Логика взаимодействия для AddTeacher.xaml
    /// </summary>
    public partial class AddTeacher : Window
    {
        private UniversityEntities _db = MainWindow.db;

        public AddTeacher()
        {
            InitializeComponent();
        }

        private void Btnadd_teacher_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Teachers newTeacher = new Teachers()
                {
                    Name_teacher = x_name_teacher.Text.ToString()
                };
                _db.Teachers.Add(newTeacher);
                _db.SaveChanges();
                this.Close();
            }
            catch
            {
                this.Close();
            }
        }

        private void Btncancel_teacher_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }
    }
}
