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
    /// Логика взаимодействия для AddTimeSheet.xaml
    /// </summary>
    public partial class AddTimeSheet : Window
    {
        private static UniversityEntities db = MainWindow.db;

        public AddTimeSheet()
        {
            InitializeComponent();
            InitCombo();
        }

        // Инициализация
        private void InitCombo()
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

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        // Функция добавление нового элемента для таблицы расписание
        private void AddNewTimeSheet(int f_group, int f_days, int f_timetable, int f_teacher, int f_typeweek, int f_subgroup, string f_subject, string f_audence)
        {

            try
            {
                Timesheet newelement = new Timesheet();
                newelement.F_group = f_group;
                newelement.F_days = f_days;
                newelement.F_timetable = f_timetable;
                newelement.F_teacher = f_teacher;
                newelement.F_typeweek = f_typeweek;
                newelement.F_subgroups = f_subgroup;
                newelement.subject = f_subject;
                newelement.audience = f_audence;
                //newelement.Days = System.Data.Entity.DbSet<DBfivtEntities> db.Days;
                db.Timesheet.Add(newelement);
                db.SaveChanges();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Ошибка при добавлении расписания");
            }
           
        }

        // Проверка введенных данных
        private bool CheckReadData(int timetble, ComboBox teacher, ComboBox subgroups)
        {
            if   ((from a in db.Groups
                                           where a.LINK == timetble
                                           select a.LINK
                                           ).ToList() == null)
            {
                MessageBox.Show("Добавьте данные в таблицу TimeTables");
                return false;
            }

            if (teacher.SelectedItem== null)
            {
                MessageBox.Show("Вы не выбрали преподавателя для "  + timetble + " пары");
            }

            if (subgroups.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали подгруппу для " + timetble + " пары");
            }
            return true;
        }

        private void CreateData(int timetble, string teacher, string subgroups, string audence, string subject)
        {
            // Предварительные данные таблицы
            
                int f_timetable = timetble;                                         // Номер пары
                int f_subgroup = Convert.ToInt16((from a in db.SubGroups            // Ид подгруппы
                                                  where a.Name_subgroups == subgroups
                                                  select a.LINK
                                       ).ToList()[0].ToString());
                int f_teacher = Convert.ToInt16((from a in db.Teachers              // Ид преподавателя
                                                 where a.Name_teacher == teacher
                                                 select a.LINK
                                       ).ToList()[0].ToString());

                int f_group = Convert.ToInt16((from a in db.Groups                  // Ид группы
                                               where a.Name_groups == combo_groups.SelectedItem.ToString()
                                               select a.LINK
                                               ).ToList()[0].ToString());
                int f_days = Convert.ToInt16((from a in db.Days                     // Ид недели
                                              where a.days1 == combo_day.SelectedItem.ToString()
                                              select a.LINK
                                      ).ToList()[0].ToString());

                int f_typeweek = Convert.ToInt16((from a in db.TypeWeek             // Ид типа недели
                                                  where a.Name_type_week == combo_typeweek.SelectedItem.ToString()
                                                  select a.LINK
                                      ).ToList()[0].ToString());
                MessageBox.Show(f_group + " " + f_days + " " + f_timetable + " " + f_teacher + " " + f_typeweek + " " + f_subgroup + " " + audence + " " + subject + "!");
                AddNewTimeSheet(f_group, f_days, f_timetable, f_teacher,  f_typeweek,  f_subgroup,  subject,  audence);
           
        }

        // Добавить расписание
        private void Btnadd_day_Click(object sender, RoutedEventArgs e)
        {
            if (combo_day.SelectedItem != null && combo_groups.SelectedItem != null && combo_typeweek.SelectedItem != null)
            {
                if (checkBox1.IsChecked == true)
                {
                    if (CheckReadData(1, comboteacher1, combosubgroup1))
                    {
                        CreateData(1,comboteacher1.SelectedItem.ToString(), combosubgroup1.SelectedItem.ToString(), audence1.Text.ToString(), subject1.Text.ToString());
                    }
                    else { MessageBox.Show("Повторите еще раз"); }
                }

                if (checkBox2.IsChecked == true)
                {
                    if (CheckReadData(2, comboteacher2, combosubgroup2))
                    {
                        CreateData(2, comboteacher2.SelectedItem.ToString(), combosubgroup2.SelectedItem.ToString(), audence2.Text.ToString(), subject2.Text.ToString());
                    }
                    else { MessageBox.Show("Повторите еще раз"); }
                }

                if (checkBox3.IsChecked == true)
                {
                    if (CheckReadData(3, comboteacher3, combosubgroup3))
                    {
                        CreateData(3, comboteacher3.SelectedItem.ToString(), combosubgroup3.SelectedItem.ToString(), audence3.Text.ToString(), subject3.Text.ToString());
                    }
                    else { MessageBox.Show("Повторите еще раз"); }
                }

                if (checkBox4.IsChecked == true)
                {
                    if (CheckReadData(4, comboteacher4, combosubgroup4))
                    {
                        CreateData(4, comboteacher4.SelectedItem.ToString(), combosubgroup4.SelectedItem.ToString(), audence4.Text.ToString(), subject4.Text.ToString());
                    }
                    else { MessageBox.Show("Повторите еще раз"); }
                }

                if (checkBox5.IsChecked == true)
                {
                    if (CheckReadData(5, comboteacher5, combosubgroup5))
                    {
                        CreateData(5, comboteacher5.SelectedItem.ToString(), combosubgroup5.SelectedItem.ToString(), audence5.Text.ToString(), subject5.Text.ToString());
                    }
                    else { MessageBox.Show("Повторите еще раз"); }
                }

                if (checkBox6.IsChecked == true)
                {
                    if (CheckReadData(6, comboteacher6, combosubgroup6))
                    {
                        CreateData(6, comboteacher6.SelectedItem.ToString(), combosubgroup6.SelectedItem.ToString(), audence6.Text.ToString(), subject6.Text.ToString());
                    }
                    else { MessageBox.Show("Повторите еще раз"); }
                }

                if (checkBox7.IsChecked == true)
                {
                    if (CheckReadData(7, comboteacher7, combosubgroup7))
                    {
                        CreateData(7, comboteacher7.SelectedItem.ToString(), combosubgroup7.SelectedItem.ToString(), audence7.Text.ToString(), subject7.Text.ToString());
                    }
                    else { MessageBox.Show("Повторите еще раз"); }
                }

                if (checkBox8.IsChecked == true)
                {
                    if (CheckReadData(8, comboteacher8, combosubgroup8))
                    {
                        CreateData(8, comboteacher8.SelectedItem.ToString(), combosubgroup8.SelectedItem.ToString(), audence8.Text.ToString(), subject8.Text.ToString());
                    }
                    else { MessageBox.Show("Повторите еще раз"); }
                }
            }
            else MessageBox.Show("Вы не выбрали группу или день, или тип недели");
        }

        // Отменить добавление
        private void Btncancel_day_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CheckBox8_Checked(object sender, RoutedEventArgs e)
        {
            comboteacher8.ItemsSource = (from a in db.Teachers
                                        select a.Name_teacher
                                       ).ToList();

            combosubgroup8.ItemsSource = (from a in db.SubGroups
                                         select a.Name_subgroups
                                       ).ToList();

        }

        private void CheckBox8_Unchecked(object sender, RoutedEventArgs e)
        {
            comboteacher8.ItemsSource = null;
            combosubgroup8.ItemsSource = null;
        }

        private void CheckBox7_Checked(object sender, RoutedEventArgs e)
        {
            comboteacher7.ItemsSource = (from a in db.Teachers
                                         select a.Name_teacher
                                       ).ToList();

            combosubgroup7.ItemsSource = (from a in db.SubGroups
                                          select a.Name_subgroups
                                       ).ToList();
        }

        private void CheckBox7_Unchecked(object sender, RoutedEventArgs e)
        {
            comboteacher7.ItemsSource = null;
            combosubgroup7.ItemsSource = null;
        }

        private void CheckBox6_Checked(object sender, RoutedEventArgs e)
        {
            comboteacher6.ItemsSource = (from a in db.Teachers
                                         select a.Name_teacher
                                       ).ToList();

            combosubgroup6.ItemsSource = (from a in db.SubGroups
                                          select a.Name_subgroups
                                       ).ToList();
        }

        private void CheckBox6_Unchecked(object sender, RoutedEventArgs e)
        {
            comboteacher6.ItemsSource = null;
            combosubgroup6.ItemsSource = null;
        }

        private void CheckBox5_Checked(object sender, RoutedEventArgs e)
        {
            comboteacher5.ItemsSource = (from a in db.Teachers
                                         select a.Name_teacher
                                       ).ToList();

            combosubgroup5.ItemsSource = (from a in db.SubGroups
                                          select a.Name_subgroups
                                       ).ToList();
        }

        private void CheckBox5_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void CheckBox4_Checked(object sender, RoutedEventArgs e)
        {
            comboteacher4.ItemsSource = (from a in db.Teachers
                                         select a.Name_teacher
                                       ).ToList();

            combosubgroup4.ItemsSource = (from a in db.SubGroups
                                          select a.Name_subgroups
                                       ).ToList();
        }

        private void CheckBox4_Unchecked(object sender, RoutedEventArgs e)
        {
            comboteacher4.ItemsSource = null;
            combosubgroup4.ItemsSource = null;
        }

        private void CheckBox3_Checked(object sender, RoutedEventArgs e)
        {
            comboteacher3.ItemsSource = (from a in db.Teachers
                                         select a.Name_teacher
                                       ).ToList();

            combosubgroup3.ItemsSource = (from a in db.SubGroups
                                          select a.Name_subgroups
                                       ).ToList();
        }

        private void CheckBox3_Unchecked(object sender, RoutedEventArgs e)
        {
            comboteacher3.ItemsSource = null;
            combosubgroup3.ItemsSource = null;
        }

        // Устанавливаем признак, что первую пару нужно добавить
        private void CheckBox1_Checked(object sender, RoutedEventArgs e)
        {
            comboteacher1.ItemsSource = (from a in db.Teachers
                                         select a.Name_teacher
                                       ).ToList();

            combosubgroup1.ItemsSource = (from a in db.SubGroups
                                          select a.Name_subgroups
                                       ).ToList();
        }

        // Устанавливаем признак, что первой пары нету
        private void CheckBox1_Unchecked(object sender, RoutedEventArgs e)
        {
            comboteacher1.ItemsSource = null;
            combosubgroup1.ItemsSource = null;
        }

        // Устанавливаем признак, что второую пару нужно добавить
        private void CheckBox2_Checked(object sender, RoutedEventArgs e)
        {
            comboteacher2.ItemsSource = (from a in db.Teachers
                                         select a.Name_teacher
                                       ).ToList();

            combosubgroup2.ItemsSource = (from a in db.SubGroups
                                          select a.Name_subgroups
                                       ).ToList();
        }

        // Устанавливаем признак, что второй пары нету
        private void CheckBox2_Unchecked(object sender, RoutedEventArgs e)
        {
            comboteacher2.ItemsSource = null;
            combosubgroup2.ItemsSource = null;
        }
        
    }
}
