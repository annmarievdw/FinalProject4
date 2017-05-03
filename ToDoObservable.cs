using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject4
{
    class ToDoObservable : ObservableCollection<ToDoList>
    {

        public ToDoObservable(LINQtoSQLClassesDataContext db)
        {
            foreach (var g in db.ToDoLists)
            {
                this.Add(g);
            }
        }
    }
}
