using UniversitySchedule.EntityDatabase;
using UniversitySchedule.PagesDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace UniversitySchedule.UserControls
{
    /// <summary>
    /// Интерфейс логики UserControlCreate.xam
    /// </summary>
    public partial class UserControlCreate : UserControl
    {
        public UserControlCreate()
        {
            InitializeComponent();
            combo_timetable.ItemsSource = (from a in db.Timetables
                                        select a.LINK
                                       ).ToList();
        }

        // Экземпляр базы данных
        public static UniversityEntities db = MainWindow.db;

        // Диалоговое окно для выбора аудиофайла формата *.wav
        public string GetPath()
        {
            try
            {
                var dialog = new System.Windows.Forms.OpenFileDialog();
                dialog.Filter = "Аудиоосообщения в формате (*.wav)|*.wav" + "|Все файлы (*.*)|*.* " ;
                dialog.CheckFileExists = true;
                dialog.ShowDialog();
                return dialog.FileName;
            }
            catch
            {
                return null;
            }
        }

        // Событие при выбора номера пары для аудиофайла
        private void Combo_timetable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MainWindow.sounds[Convert.ToInt32(combo_timetable.SelectedItem.ToString()) - 1].SetTimetable(Convert.ToInt32(combo_timetable.SelectedItem.ToString()));
        }

        // Событие при нажатии на кнопку Выбрать 
        private void ButtonSelectSound(object sender, RoutedEventArgs e)
        {
            if (combo_timetable.SelectedItem != null)
                MainWindow.sounds[Convert.ToInt32(combo_timetable.SelectedItem.ToString()) - 1].SetSound_path(GetPath());
            else MessageBox.Show("Выберите сначала номер пары!");
        }

        // Событие при нажатии на кнопку Играть 
        private void SoundPlay(object sender, RoutedEventArgs e)
        {
            MainWindow.sounds[Convert.ToInt32(combo_timetable.SelectedItem.ToString()) - 1].PlaySound();
        }

        // Событие при нажатии на кнопку Стоп
        private void SoundStop(object sender, RoutedEventArgs e)
        {
            MainWindow.sounds[Convert.ToInt32(combo_timetable.SelectedItem.ToString()) - 1].StopSound();
        }

        // Событие при нажатии на кнопку Сохранить 
        private void SaveAudio(object sender, RoutedEventArgs e)
        {
            if (combo_timetable.SelectedItem != null)
            {
                try
                {
                    int id = Int32.Parse(combo_timetable.SelectedItem.ToString());
                    Timetables updatetimetable = (from m in db.Timetables
                                                  where m.LINK == id
                                                  select m).Single();
                    updatetimetable.audio_path = MainWindow.sounds[Convert.ToInt32(combo_timetable.SelectedItem.ToString()) - 1].GetSound_path();
                    db.SaveChanges();
                    timetableDataGrid.ItemsSource = db.Timetables.ToList();
                }
                catch { MessageBox.Show("Что то пошло не так..."); }



            }
            else MessageBox.Show("Выберите сначала номер пары!");
        }

        // инициализация таблицы подгрупп
        private void SubgroupDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            subgroupDataGrid.ItemsSource=  db.SubGroups.ToList();
        }

        // Инициализация таблицы типы недели
        private void TypeweekDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            typeweekDataGrid.ItemsSource= db.TypeWeek.ToList();
        }
        // Инициализация таблицы преподавателей
        private void TeacherDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            teacherDataGrid.ItemsSource= db.Teachers.ToList(); 
        }

        // Инициализация таблицы пар
        private void TimetableDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            timetableDataGrid.ItemsSource= db.Timetables.ToList();
        }
        // Инициализация таблицы дней
        private void DayDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            dayDataGrid.ItemsSource = db.Days.ToList();
        }

        // Инициализация таблицы групп
        private void GroupDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            groupDataGrid.ItemsSource= db.Groups.ToList();
        }

        private void RaspDataGrid_Loaded(object sender, RoutedEventArgs e)
        {

        }

        // Фильтры для таблицы расписаня (Timesheet)
        private void Combo_groups_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Combo_typeweek_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Combo_day_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        // Изменение группы
        private void Btnupdate_group_Click(object sender, RoutedEventArgs e)
        {
            if (groupDataGrid.SelectedItem != null)
            {
                int Id = (groupDataGrid.SelectedItem as Groups).LINK;
                ChangeGroups Upage = new ChangeGroups(Id);
                Upage.ShowDialog();
                groupDataGrid.ItemsSource = db.Groups.ToList();
            }
            else MessageBox.Show("Выберите элемент");
        }

        // Добавление группы
        private void Btnadd_group_Click(object sender, RoutedEventArgs e)
        {
            AddGroups Upage = new AddGroups();
            Upage.ShowDialog();
            groupDataGrid.ItemsSource = db.Groups.ToList();
        }

        // Удаление группы
        private void Btndelete_group_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int Id = (groupDataGrid.SelectedItem as Groups).LINK;
                var deleteGroup = db.Groups.Where(m => m.LINK == Id).Single();
                db.Groups.Remove(deleteGroup);
                db.SaveChanges();
                groupDataGrid.ItemsSource = db.Groups.ToList();
            }
            catch
            {
                MessageBox.Show("Ошибка при удалении");
            }

        }

        // Добавление дней
        private void Btnadd_day_Click(object sender, RoutedEventArgs e)
        {
            AddDay Upage = new AddDay();
            Upage.ShowDialog();
            dayDataGrid.ItemsSource = db.Days.ToList();
        }

        // Изменение дня
        private void Btnupdate_day_Click(object sender, RoutedEventArgs e)
        {
            if (dayDataGrid.SelectedItem != null)
            {
                int Id = (dayDataGrid.SelectedItem as Days).LINK;
                ChangeDay Upage = new ChangeDay(Id);
                Upage.ShowDialog();
                dayDataGrid.ItemsSource = db.Days.ToList();
            }
            else MessageBox.Show("Выберите элемент");
        }

        // Удаление дня
        private void Btndelete_day_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int Id = (dayDataGrid.SelectedItem as Days).LINK;
                var deleteDay = db.Days.Where(m => m.LINK == Id).Single();
                db.Days.Remove(deleteDay);
                db.SaveChanges();
                dayDataGrid.ItemsSource = db.Days.ToList();
            }
            catch
            {
                MessageBox.Show("Ошибка при удалении");
            }
        }

        // Добавление пары
        private void Btnadd_timetable_Click(object sender, RoutedEventArgs e)
        {
            AddTimetable Upage = new AddTimetable();
            Upage.ShowDialog();
            timetableDataGrid.ItemsSource = db.Timetables.ToList();
        }

        // Изменение пары
        private void Btnupdate_timetable_Click(object sender, RoutedEventArgs e)
        {
            if (timetableDataGrid.SelectedItem != null)
            {
                int Id = (timetableDataGrid.SelectedItem as Timetables).LINK;
                ChangeTimetable Upage = new ChangeTimetable(Id);
                Upage.ShowDialog();
                timetableDataGrid.ItemsSource = db.Timetables.ToList();
            }
            else MessageBox.Show("Выберите элемент");
        }

        // Удаление пары
        private void Btndelete_timetable_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int Id = (timetableDataGrid.SelectedItem as Timetables).LINK;
                var deleteTimetable= db.Timetables.Where(m => m.LINK == Id).Single();
                db.Timetables.Remove(deleteTimetable);
                db.SaveChanges();
                timetableDataGrid.ItemsSource = db.Timetables.ToList();
            }
            catch
            {
                MessageBox.Show("Ошибка при удалении");
            }
        }

        // Добавление преподавателя
        private void Btnadd_teacher_Click(object sender, RoutedEventArgs e)
        {
            AddTeacher Upage = new AddTeacher();
            Upage.ShowDialog();
            teacherDataGrid.ItemsSource = db.Teachers.ToList();
        }

        // Изменение преподавателя
        private void Btnupdate_teacher_Click(object sender, RoutedEventArgs e)
        {
            if (teacherDataGrid.SelectedItem != null)
            {
                int Id = (teacherDataGrid.SelectedItem as Teachers).LINK;
                ChangeTeacher Upage = new ChangeTeacher(Id);
                Upage.ShowDialog();
                teacherDataGrid.ItemsSource = db.Teachers.ToList();
            }
            else MessageBox.Show("Выберите элемент");
        }

        // Удаление преподавателя
        private void Btndelete_teacher_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int Id = (teacherDataGrid.SelectedItem as Groups).LINK;
                var deleteTeacher = db.Teachers.Where(m => m.LINK == Id).Single();
                db.Teachers.Remove(deleteTeacher);
                db.SaveChanges();
                teacherDataGrid.ItemsSource = db.Teachers.ToList();
            }
            catch
            {
                MessageBox.Show("Ошибка при удалении");
            }
        }

        // Добавление типа недели
        private void Btnadd_typeweek_Click(object sender, RoutedEventArgs e)
        {
            AddTypeweek Upage = new AddTypeweek();
            Upage.ShowDialog();
            typeweekDataGrid.ItemsSource = db.TypeWeek.ToList();
        }

        // Изменение типа недели
        private void Btnupdate_typeweek_Click(object sender, RoutedEventArgs e)
        {
            if (typeweekDataGrid.SelectedItem != null)
            {
                int Id = (typeweekDataGrid.SelectedItem as TypeWeek).LINK;
                ChangeTypeweek Upage = new ChangeTypeweek(Id);
                Upage.ShowDialog();
                typeweekDataGrid.ItemsSource = db.TypeWeek.ToList();
            }
            else MessageBox.Show("Выберите элемент");
        }

        // Удаление типа недели
        private void Btndelete_typeweek_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int Id = (typeweekDataGrid.SelectedItem as TypeWeek).LINK;
                var deleteTypeweek = db.TypeWeek.Where(m => m.LINK == Id).Single();
                db.TypeWeek.Remove(deleteTypeweek);
                db.SaveChanges();
                typeweekDataGrid.ItemsSource = db.TypeWeek.ToList();
            }
            catch
            {
                MessageBox.Show("Ошибка при удалении");
            }
        }

        // Добавление подгруппы
        private void Btnadd_subgroup_Click(object sender, RoutedEventArgs e)
        {
            AddSubgroup Upage = new AddSubgroup();
            Upage.ShowDialog();
            subgroupDataGrid.ItemsSource = db.SubGroups.ToList();
        }

        // Изменение подгруппы
        private void Btnupdate_subgroup_Click(object sender, RoutedEventArgs e)
        {
            if (subgroupDataGrid.SelectedItem != null)
            {
                int Id = (subgroupDataGrid.SelectedItem as SubGroups).LINK;
                ChangeSubgroup Upage = new ChangeSubgroup(Id);
                Upage.ShowDialog();
                subgroupDataGrid.ItemsSource = db.SubGroups.ToList();
            }
            else MessageBox.Show("Выберите элемент");
        }

        // Удаление подгруппы
        private void Btndelete_subgroup_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int Id = (subgroupDataGrid.SelectedItem as SubGroups).LINK;
                var deleteSubgroup = db.SubGroups.Where(m => m.LINK == Id).Single();
                db.SubGroups.Remove(deleteSubgroup);
                db.SaveChanges();
                subgroupDataGrid.ItemsSource = db.SubGroups.ToList();
            }
            catch
            {
                MessageBox.Show("Ошибка при удалении");
            }
        }
        
        // Добавление расписания
        private void Btnadd_Click(object sender, RoutedEventArgs e)
        {
            AddTimeSheet Upage = new AddTimeSheet();
            Upage.ShowDialog();
        }

        // Удаление расписания
        private void Btndelete_Click(object sender, RoutedEventArgs e)
        {

        }

        // Вывод расписания
        private void Btnshow_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
