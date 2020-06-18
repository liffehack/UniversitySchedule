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
    /// Логика взаимодействия для AddDay.xaml
    /// </summary>
    public partial class AddDay : Window
    {
        /// <summary>
        /// Экземпляр БД
        /// </summary>
        private UniversityEntities _db = MainWindow.db;
        
        /// <summary>
        /// Конструктор (инициализация)
        /// </summary>
        public AddDay()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Добавить
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btnadd_day_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Days newDay = new Days()
                {
                    days1 = x_name_day.Text.ToString()
                };
                _db.Days.Add(newDay);
                _db.SaveChanges();
                this.Close();
            }
            catch
            {
                this.Close();
            }
        }

        /// <summary>
        /// Отмена
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btncancel_day_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }
    }
}
