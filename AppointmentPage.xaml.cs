﻿using System;
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

namespace FinalProject4
{
    /// <summary>
    /// Interaction logic for AppointmentPage.xaml
    /// </summary>
    public partial class AppointmentPage : Page, IDisposable
    {
        LINQtoSQLClassesDataContext db = new LINQtoSQLClassesDataContext(Properties.Settings.Default.GoalsProjectConnectionString);
        private ApptObservable alist;
        public AppointmentPage()
        {
            InitializeComponent();

            if (db.DatabaseExists())
            {
                
                alist = new ApptObservable(db);

                this.apptListbox.ItemsSource = alist; 

                
            }
        }

        private void apptBtn_Click(object sender, RoutedEventArgs e)
        {
            Appointment appointment = new Appointment();

            appointment.ApptTime = apptDate.SelectedDate;
            appointment.Subject = apptTextbox.Text;
            appointment.Goal = apptCombobox.Text;

            db.Appointments.InsertOnSubmit(appointment);
        }

        private void apptCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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
        // ~AppointmentPage() {
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
