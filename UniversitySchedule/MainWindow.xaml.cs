using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Media;
using UniversitySchedule.UserControls;
using UniversitySchedule.Models;
using UniversitySchedule.UserContols;
using UniversitySchedule.EntityDatabase;
using System.Windows.Media;

namespace UniversitySchedule
{

    public partial class MainWindow : Window
    {
        //[STAThread]
        public MainWindow()
        {
            InitializeComponent();
            Init();
        }

        // Таймер
        System.Windows.Forms.Timer timer01 = new System.Windows.Forms.Timer();
        public static UniversityEntities db = new UniversityEntities();
        public bool ViewMode = false;
        public static List<Sound> sounds = new List<Sound>();
        public static int NowTimetable = 0;

        // Инициализация компонентов
        public void Init()
        {
            // Инициализация главного окна приложения
            UserControl usc = null;
            GridMain.Children.Clear();
            usc = new UserControlStart();
            GridMain.Children.Add(usc);

            // Инициализация таймера
            timer01.Interval = 1000;
            timer01.Tick += Timer01_Tick;
            timer01.Start();

            // Инициализация аудиосообщений
            foreach (var m in db.Timetables.ToList())
            {
                var newsound = new Sound();
                newsound.SetTimetable(m.LINK);
                newsound.SetSound_path(m.audio_path);
                sounds.Add(newsound);
            }
        }

        // Работа таймера
        private void Timer01_Tick(object sender, EventArgs e)
        {
            CheckTime();
        }

        // Проверка времени
        private void CheckTime()
        {
            var timeNow = DateTime.Now.TimeOfDay;
            TimeSpan TimeTo = new TimeSpan(0, 0, 10); // Время озвучивания конца пары за 10 секунд
            foreach (var timetable in db.Timetables.ToList())
            {
                try
                {
                    // Проверка времени
                    if ((timeNow >= timetable.timetable_begin) && (timeNow <= timetable.timetable_end))
                    {
                        NowTimetable = timetable.LINK;
                        // Проверка на озвучинвание начала пары
                        if (!sounds[timetable.LINK - 1].GetTimetable_begin())
                        {
                            sounds[timetable.LINK - 1].SetTimetable_begin(true);
                            sounds[timetable.LINK - 1].PlaySound();
                        }

                        // Проверка на озвучивание конца пары
                        if ((timetable.timetable_end - timeNow) < TimeTo)
                        {
                            if (!sounds[timetable.LINK - 1].GetTimetable_end())
                            {
                                sounds[timetable.LINK - 1].SetTimetable_end(true);
                                sounds[timetable.LINK - 1].PlaySound();
                                NowTimetable = 0;
                            }
                        }
                    }
                }
                catch { }
            }
        }

        // Событие раскрытия списка
        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        // Закрытие списка
        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }

        // Действия выбора элементов со списка
        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserControl usc = null;
            GridMain.Children.Clear();

            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "ItemHome":
                    usc = new UserControlStart();
                    GridMain.Children.Add(usc);
                    break;
                case "ItemCreate":
                    if (ViewMode)
                    {
                        usc = new UserControlCreate();
                        GridMain.Children.Add(usc);
                    }
                    else MessageBox.Show("Пройдите авторизацию");
                    break;
                default:
                    usc = new UserControlHome();
                    GridMain.Children.Add(usc);
                    break;
            }
        }

        // Событие при нажатии на кнопку Помощь
        private void ButtonHelps_Click(object sender, RoutedEventArgs e)
        {
            HelpsApplication helps = new HelpsApplication();
            helps.ShowDialog();
        }

        // Событие при нажатии на кнопку Выход
        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // Авторизация
        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            Login2 log = new Login2();
            if (log.ShowDialog() == true)
            {
                ViewMode = true;
                topMenu.Background= Brushes.Red;
            }
            
        }
    }
}

