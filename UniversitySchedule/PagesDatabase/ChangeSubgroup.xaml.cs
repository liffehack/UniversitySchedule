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
    /// Логика взаимодействия для ChangeSubgroup.xaml
    /// </summary>
    public partial class ChangeSubgroup : Window
    {
        public static UniversityEntities _db = MainWindow.db;
        private int id;

        public ChangeSubgroup()
        {
            InitializeComponent();
        }

        public ChangeSubgroup(int id)
        {
            InitializeComponent();
            this.id = id;
            SubGroups updateSubgroups = (from m in _db.SubGroups
                                         where m.LINK == id
                                         select m).Single();
            x_name_subgroup.Text = updateSubgroups.Name_subgroups;
        }

        private void Btnadd_subgroup_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SubGroups updateSubgroups = (from m in _db.SubGroups
                                  where m.LINK == id
                                  select m).Single();
                updateSubgroups.Name_subgroups = x_name_subgroup.Text;
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
