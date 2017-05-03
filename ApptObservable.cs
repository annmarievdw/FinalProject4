using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject4
{
    class ApptObservable : ObservableCollection<Appointment>
    {
        public ApptObservable(LINQtoSQLClassesDataContext db)
        {
            foreach(var a in db.Appointments)
            {
                this.Add(a);
            }
        }
    }
}
