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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace FinalProject4
{
    /// <summary>
    /// Interaction logic for ToDoListPage.xaml
    /// </summary>
    public partial class ToDoListPage : Page, IDisposable
    {
        
        LINQtoSQLClassesDataContext db = new LINQtoSQLClassesDataContext(Properties.Settings.Default.GoalsProjectConnectionString);
        private ToDoObservable tdlist;
        public ToDoListPage()
        {
            InitializeComponent();

            
            tdlist = new ToDoObservable(db);


            ToDoListBox.ItemsSource = tdlist;
            textBox2.Text = Convert.ToString(tdlist);
            
        }

        private void saveBtn_Click(object sender, EventArgs e)

        {
            //add to todolist database
            ToDoList todolist = new ToDoList();

            todolist.Subject = textBox1.Text;
            todolist.Goal = textBox2.Text;

            db.ToDoLists.InsertOnSubmit(todolist);

            //db.SubmitChanges();
            //db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.ToDoLists);

            textBox1.Focus();
            textBox1.Clear();
            textBox2.Focus();
            textBox2.Clear();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~ToDoListPage() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion

        
    }
}
