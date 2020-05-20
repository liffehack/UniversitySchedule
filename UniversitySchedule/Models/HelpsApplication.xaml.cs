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

namespace UniversitySchedule.Models
{
    /// <summary>
    /// Логика взаимодействия для HelpsApplication.xaml
    /// </summary>
    public partial class HelpsApplication : Window
    {
        public HelpsApplication()
        {
            InitializeComponent();
        }

        // Событие при нажатии на кнопку Выход
        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
