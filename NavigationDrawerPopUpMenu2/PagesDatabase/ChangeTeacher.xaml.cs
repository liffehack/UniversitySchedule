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
    /// Логика взаимодействия для ChangeTeacher.xaml
    /// </summary>
    public partial class ChangeTeacher : Window
    {
        public static UniversityEntities _db = MainWindow.db;
        private int id;

        public ChangeTeacher()
        {
            InitializeComponent();
        }

        public ChangeTeacher(int id)
        {
            InitializeComponent();
            this.id = id;
            Teachers updateTeacher = (from m in _db.Teachers
                                      where m.LINK == id
                                      select m).Single();
            x_name_teacher.Text = updateTeacher.Name_teacher;
        }

        private void Btnadd_teacher_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Teachers updateTeacher = (from m in _db.Teachers
                                             where m.LINK == id
                                             select m).Single();
                updateTeacher.Name_teacher = x_name_teacher.Text;
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
