using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject4
{
    class ObservableGoal : ObservableCollection<ProgressGoal>
    {
        public ObservableGoal(LINQtoSQLClassesDataContext db)
        {
            foreach (var g in db.ProgressGoals)
            {
                this.Add(g);
            }
        }
    }
}
