//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UniversitySchedule.EntityDatabase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Timetables
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Timetables()
        {
            this.Timesheet = new HashSet<Timesheet>();
        }
    
        public int LINK { get; set; }
        public System.TimeSpan timetable_begin { get; set; }
        public System.TimeSpan timetable_end { get; set; }
        public string audio_path { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Timesheet> Timesheet { get; set; }
    }
}
