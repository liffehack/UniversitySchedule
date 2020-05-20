using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversitySchedule.ViewModels
{
    class MainWindowModel: ViewModel
    {
        private string v_Message;

        public string Message
        {
            get => v_Message;
            set => Set(ref v_Message, value);
        }
    }
}
