using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MaterialDesignThemes.Wpf;
using UniversitySchedule.EntityDatabase;

namespace UniversitySchedule.UserControls
{
    /// <summary>
    /// Интерфейс логики UserControlHome.xam
    /// </summary>
    public partial class UserControlHome : UserControl
    {
        public static UniversityEntities db = MainWindow.db;

        public UserControlHome()
        {
            InitializeComponent();
            Init();
        }

        /// <summary>
        /// Инициализация
        /// </summary>
        private void Init()
        {
            combo_groups.ItemsSource = (from a in db.Groups
                                        select a.Name_groups
                                       ).ToList(); 

            combo_day.ItemsSource = (from a in db.Days
                                     select a.days1
                                       ).ToList();

            combo_typeweek.ItemsSource = (from a in db.TypeWeek
                                          select a.Name_type_week
                                       ).ToList();
        }

        private void Combo_groups_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void Combo_day_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (combo_groups.SelectedItem != null)
            {
            }
            else MessageBox.Show("Выберите сначала группу");
        }

        private void Combo_typeweek_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (combo_day.SelectedItem != null && combo_groups.SelectedItem != null)
            {             
            }
            else MessageBox.Show("Выберите сначала День");
        }

        /// <summary>
        /// Событие на нажатие кнопки "Показать"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btnshow_Click(object sender, RoutedEventArgs e)
        {
            if (combo_day.SelectedItem != null && combo_groups.SelectedItem != null && combo_typeweek.SelectedItem != null)
            {
                var message = (from a in db.Timesheet
                               join b in db.Groups on a.F_group equals b.LINK
                               join c in db.Days on a.F_days equals c.LINK
                               join d in db.TypeWeek on a.F_typeweek equals d.LINK
                               join f in db.Teachers on a.F_teacher equals f.LINK
                               where b.Name_groups == combo_groups.SelectedItem.ToString()
                               where c.days1 == combo_day.SelectedItem.ToString()
                               where d.Name_type_week == combo_typeweek.SelectedItem.ToString()
                               orderby a.F_timetable
                               select a).ToList();
                ClearElements();
                foreach (var m in message)
                {
                    NewElements(m.Timetables.LINK +". " + m.Timetables.timetable_begin.ToString() + " - " + m.Timetables.timetable_end.ToString(), m.subject, m.audience, m.Teachers.Name_teacher.ToString(), m.SubGroups.Name_subgroups.ToString() + " ");
                }
            }
            else MessageBox.Show("Вы не выбрали группу или день, или тип недели");
        }

        /// <summary>
        /// Создание нового элемента TextBlock
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private TextBlock CreateTextBlock(string name)
        {
            TextBlock element = new TextBlock();
            element.Text = name;
            element.Margin = new Thickness(20);
            //element.Background = Brushes.White;
            element.TextAlignment = TextAlignment.Center;
            element.Foreground = Brushes.Black;
            element.FontSize = 14;
            return element;
        }

        /// <summary>
        /// Динамическое создание таблички
        /// </summary>
        /// <param name="timetable"></param>
        /// <param name="subject"></param>
        /// <param name="audence"></param>
        /// <param name="teacher"></param>
        /// <param name="subgroup"></param>
        private void NewElements(string timetable, string subject, string audence, string teacher, string subgroup)
        {
            stimetable.Children.Add(CreateTextBlock(timetable));
            ssubject.Children.Add(CreateTextBlock(subject));
            saudence.Children.Add(CreateTextBlock(audence));
            steacher.Children.Add(CreateTextBlock(teacher));
            ssubroup.Children.Add(CreateTextBlock(subgroup));
        }

        /// <summary>
        /// Очищение элементов
        /// </summary>
        private void ClearElements()
        {
            stimetable.Children.Clear();
            ssubject.Children.Clear();
            saudence.Children.Clear();
            steacher.Children.Clear();
            ssubroup.Children.Clear();
            stimetable.Children.Add(CreateTextBlock("Пара"));
            ssubject.Children.Add(CreateTextBlock("Предмет"));
            saudence.Children.Add(CreateTextBlock("Аудитория"));
            steacher.Children.Add(CreateTextBlock("Преподаватель"));
            ssubroup.Children.Add(CreateTextBlock("Подгруппа"));
        }

         /// <summary>
         /// Событие после выбора комбокса "Группы"
         /// </summary>
         /// <param name="sender"></param>
         /// <param name="e"></param>
        private void Combo_cours_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

// s.Substring(s.Length-2)