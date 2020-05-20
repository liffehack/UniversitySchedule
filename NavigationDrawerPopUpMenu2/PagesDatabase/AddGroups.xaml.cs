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
    /// Логика взаимодействия для AddGroups.xaml
    /// </summary>
    public partial class AddGroups : Window
    {
        private UniversityEntities _db = MainWindow.db;

        public AddGroups()
        {
            InitializeComponent();
        }

        private void Btnadd_group_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Groups newGroup = new Groups()
                {
                    Name_groups = x_name_group.Text.ToString()
                };
                _db.Groups.Add(newGroup);
                _db.SaveChanges();
                this.Close();
            }
            catch
            {
                this.Close();
            }
    }

        private void Btncancel_group_Click_1(object sender, RoutedEventArgs e)
        {
        DialogResult = false;
        this.Close();
        }
    }
}
