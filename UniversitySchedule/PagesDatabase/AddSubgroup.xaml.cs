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
    /// Логика взаимодействия для AddSubgroup.xaml
    /// </summary>
    public partial class AddSubgroup : Window
    {
        private UniversityEntities _db = MainWindow.db;

        public AddSubgroup()
        {
            InitializeComponent();
        }

        private void Btnadd_subgroup_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SubGroups newSubGroup = new SubGroups()
                {
                    Name_subgroups = x_name_subgroup.Text.ToString()
                };
                _db.SubGroups.Add(newSubGroup);
                _db.SaveChanges();
                this.Close();
            }
            catch
            {
                this.Close();
            }
        }

        private void Btncancel_subgroup_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }
    }
}
