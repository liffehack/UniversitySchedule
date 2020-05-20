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
    /// Логика взаимодействия для ChangeGroups.xaml
    /// </summary>
    public partial class ChangeGroups : Window
    {
        public static UniversityEntities _db = MainWindow.db;
        private int id;
        public ChangeGroups()
        {
            InitializeComponent();
        }

        public ChangeGroups(int id_groups)
        {
            InitializeComponent();
            this.id = id_groups;
            Groups updategroupe = (from m in _db.Groups
                                   where m.LINK == id
                                   select m).Single();
            x_id.Text = id.ToString();
            x_name_group.Text = updategroupe.Name_groups;

        }

        private void Btnupdate_group_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Groups updategroupe = (from m in _db.Groups
                                       where m.LINK == id
                                       select m).Single();
                updategroupe.Name_groups = x_name_group.Text;
                _db.SaveChanges();
                this.Close();
            }
            catch
            {
                this.Close();
            }
        }

        private void Btndelete_group_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }
    }
}
