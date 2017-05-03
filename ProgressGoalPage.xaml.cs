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

namespace FinalProject4
{
    /// <summary>
    /// Interaction logic for ProgressGoalPage.xaml
    /// </summary>
    public partial class ProgressGoalPage : Page, IDisposable
    
    {

        int count;
        
        LINQtoSQLClassesDataContext db = new LINQtoSQLClassesDataContext(Properties.Settings.Default.GoalsProjectConnectionString);
        private ObservableGoal glist;
        public string chosenGoal = string.Empty;

        public ProgressGoalPage()
        {
            InitializeComponent();

            if (db.DatabaseExists())
            {
                glist = new ObservableGoal(db);

                this.goalListbox.ItemsSource = glist;
            }

        }

        private void goalListbox_Selected(object sender, RoutedEventArgs e)
        {
            
            chosenGoal = (goalListbox.SelectedValue as ListBoxItem).Content.ToString();
        }

        private void progressBtn_Click(object sender, EventArgs e)
        {
            
            if (chosenGoal != null)
            {
                
                progressTextBlock.Background = new SolidColorBrush(Colors.CornflowerBlue);
                SetProgressMessage();
            }
            else
            {
                MessageBox.Show("Please choose a goal from the list", "Error", MessageBoxButton.OK);
            }
            
        }//progressbutton click event handler

        private void SetProgressMessage()
        {
            //linq statement searching appts and todolist goals  select goal from appts, goal from todolist, sort by goals, then count number of items for each goal, count equals count of items from both for chosen goal
            //goals.Where(apptGoal => Goal)
            //     goals.Count++;
            count = 0;
            var apptSteps =
                from ap in db.Appointments
                where ap.Goal == chosenGoal
                select ap.ID;

            var todoSteps =
                from td in db.ToDoLists
                where td.Goal == chosenGoal
                select td.ID;

                      

            //somehow select ap.goal + t.goal and total count

            
            foreach(var item in apptSteps)
            {
                count++;
            }
            foreach(var item in todoSteps)
            {
                count++;
            }
            //count = 4;
            

            //increment count for each goal in appts and todolist

            switch (count)
            {
                case 0:
                    progressTextBlock.Text = "\nThis is within the realm of possibility.. come on just do one \n\n" + "You have completed " + count + " steps completed towards your goal";
                    break;
                case 1:
                    progressTextBlock.Text = "\nYou've made some progress! Great! \n\n" + count + " steps completed towards your goal";
                    break;
                case 2:
                    progressTextBlock.Text = "\nTwo down! You can do this! \n\n" + count + " steps completed towards your goal";
                    break;
                case 3:
                    progressTextBlock.Text = "\nNow you're getting somewhere! \n\n" + count + " steps completed towards your goal";
                    break;
                case 4:
                    progressTextBlock.Text = "\nWow look at you go! \n\n" + count + " steps completed towards your goal";
                    break;
                case 5:
                    progressTextBlock.Text = "\nYou are amazing! \n\n" + count + " steps completed towards your goal";
                    break;
                case 6:
                    progressTextBlock.Text = "\nAlmost done with this one! \n\n" + count + " steps completed towards your goal";
                    break;
                case 7:
                    progressTextBlock.Text = "\nYou did it! Never doubted for a minute!\n\n" + count + " steps completed. You have met your goal";
                    break;
                default:
                    progressTextBlock.Text = "\nYou really worked hard! \n\n" + count + " steps completed. You have met your goal";
                    break;
                   
            }//switch statement setting message and count

        }//counting goals and setting message in textblock

        private void Btn_Click(object sender, EventArgs e)
        {
            if (sender == rbtn1)
            {
                //redirect to todolist 
                ToDoListPage toDoListPage = new ToDoListPage();
                NavigationService.Navigate(toDoListPage);
            }
            else if (sender == rbtn2)
            {

                //redirect to appointment page
                AppointmentPage appointmentPage = new AppointmentPage();
                NavigationService.Navigate(appointmentPage);
            }
            else if (sender == rbtn3)
            {
                //add goal
                ProgressGoal progressgoal = new ProgressGoal();

                progressgoal.Goal = addGoalTextbox.Text;

                db.ProgressGoals.InsertOnSubmit(progressgoal);
                //db.SubmitChanges();

                goalListbox.Items.Add(this.addGoalTextbox.Text);
               
                this.addGoalTextbox.Focus();
                this.addGoalTextbox.Clear();
         
            }
            else if (sender == rbtn4)
            {
                ProgressGoal progressgoal = new ProgressGoal();

                progressgoal.Goal = chosenGoal;

                db.ProgressGoals.DeleteOnSubmit(progressgoal);
                //db.SubmitChanges();

                goalListbox.Items.Remove(this.addGoalTextbox.Text);

                this.addGoalTextbox.Focus();
                this.addGoalTextbox.Clear();
            }

        }



        

        public void Dispose()
        {
            ((IDisposable)db).Dispose();
        }

        private void goalTextBlock_Loaded(object sender, RoutedEventArgs e)
        {

        }

       
    }
}
