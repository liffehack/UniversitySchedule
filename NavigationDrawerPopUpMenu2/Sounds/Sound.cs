using System.Media;

namespace UniversitySchedule
{
    public class Sound
    {
        SoundPlayer sound;                  // Объект аудиосообщения
        private string sound_path;          // Путь к аудиосообщению
        private int number_timetable;       // Номер пары
        private bool timetable_begin;       // Состояние озвучки начала пары
        private bool timetable_end;       // Состояние озвучки конца пары
       
        
        public Sound()
        {
            timetable_begin = false;
            timetable_end = false;
            sound_path = "";
            int number_timetable = 0;
        }

        // Метод для получаения текущего состояние озучки начала пары
        public bool GetTimetable_begin()
        {
            return this.timetable_begin;
        }

        // Метод для получаения текущего состояние озучки конца пары
        public bool GetTimetable_end()
        {
            return this.timetable_end;
        }

        // Метод для получаения пути к аудиофайлу
        public string GetSound_path()
        {
            return this.sound_path;
        }

        // Метод для получаения номера пары
        public int GetTimetable()
        {
            return this.number_timetable;
        }

        // Метод для получаения объекта аудиосообщения
        public SoundPlayer GetSound()
        {
            return this.sound;
        }

        // Метод для получаения текущего состояние озучки начала пары
        public void SetTimetable_begin(bool sost)
        {
             this.timetable_begin = sost;
        }

        // Метод для получаения текущего состояние озучки конца пары
        public void SetTimetable_end(bool sost)
        {
             this.timetable_end = sost;
        }

        // Метод для получаения пути к аудиофайлу
        public void SetSound_path(string path)
        {
             this.sound_path = path;
        }

        // Метод для получаения номера пары
        public void SetTimetable( int num)
        {
             this.number_timetable = num;
        }

        // Метод для получаения объекта аудиосообщения
        public void SetSound(SoundPlayer player)
        {
             this.sound = player;
        }

        // Метод для проигрывания аудиофайла
        public void PlaySound()
        {
            try
            {
                this.sound = new SoundPlayer(sound_path);
                sound.Play();
            }
            catch
            {
                System.Windows.MessageBox.Show("Ошибка при попытке передачи аудиосообщения №00" + number_timetable);
            }
        }

        // Метод для проигрывания аудиофайла
        public void StopSound()
        {
            try
            {
                sound.Stop();
            }
            catch
            {
                System.Windows.MessageBox.Show("Ошибка при попытке передачи аудиосообщения №00" + number_timetable);
            }
        }
    }
}

