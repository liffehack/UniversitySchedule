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
    /// Логика взаимодействия для Login2.xaml
    /// </summary>
    public partial class Login2 : Window
    {
        public Login2()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Password == "123")
            {
                DialogResult = true;
            }
             
            else
            {
                DialogResult = false;
            }
        }

        public string Password
        {
            get { return Parol.Password; }
        }
    }
}
