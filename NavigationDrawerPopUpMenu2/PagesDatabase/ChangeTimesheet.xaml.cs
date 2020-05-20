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
    /// Логика взаимодействия для ChangeTimesheet.xaml
    /// </summary>
    public partial class ChangeTimesheet : Window
    {
        public static UniversityEntities _db = new UniversityEntities();

        public ChangeTimesheet()
        {
            InitializeComponent();
        }
    }
}
