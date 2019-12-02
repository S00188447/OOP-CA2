using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace CA2 
{
    enum ActivityType
    {
        Air = 0,
        Water = 0,
        Land = 0

    }
    public partial class MainWindow : Window 
    {
        List<Activity> activities = new List<Activity>();
        List<Activity> selectedActivities = new List<Activity>();
        List<Activity> filteredactivities = new List<Activity>();








        ObservableCollection<Activity> ac;
        Random rng = new Random();
    public MainWindow()
    {
        InitializeComponent();
    }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            Activity Act1 = new Activity("Treking", DateTime.Now, 30m, "A trek to the mountains", Category.Land);
            Activity Act2 = new Activity("Mountain Bike", DateTime.Now, 50m, "Mountain biking, all equipment provided", Category.Land);
            Activity Act3 = new Activity("Absailing", DateTime.Now, 70m, "Up to 1000m high", Category.Water);
            Activity Act4 = new Activity("Kayaking", DateTime.Now, 70m, "Travel to an island picnic", Category.Water);
            Activity Act5 = new Activity("Surfing", DateTime.Now, 50m, "2 hour long surd", Category.Water);
            Activity Act6 = new Activity("Sailing", DateTime.Now, 80m, "Boat needed", Category.Water);
            Activity Act7 = new Activity("Parachuting", DateTime.Now, 200m, "May be dangerous", Category.Air);
            Activity Act8 = new Activity("Hand Gliding", DateTime.Now, 300m, "Totally safe", Category.Air);
            Activity Act9 = new Activity("Helicopter Tour", DateTime.Now, 1000m, "For the rich", Category.Air);

            //add to list
            activities.Add(Act1);
            activities.Add(Act2);
            activities.Add(Act3);
            activities.Add(Act4);
            activities.Add(Act5);
            activities.Add(Act6);
            activities.Add(Act7);
            activities.Add(Act8);
            activities.Add(Act9);

            //display in listbox
            LBXallactivites.ItemsSource = activities; //tell listbox that the source of items is the list activities

        }

        private void BTNadd_Click(object sender, RoutedEventArgs e)
        {

            //figure out what item is selected
            Activity selectedActivity = LBXallactivites.SelectedItem as Activity;
            //null check
            if(selectedActivity != null)
            {
                //move item from left to right
                activities.Remove(selectedActivity);
                selectedActivities.Add(selectedActivity);

                //method to refresh screen
                RefreshScreen();
            }

            //move item from left to right

        }

        private void BTNremove_Click(object sender, RoutedEventArgs e)
        {
            //figure out what item is selected
            Activity selectedActivity = LBXselectedactivities.SelectedItem as Activity;
            //null check
            if (selectedActivity != null)
            {
                //move item from left to right
                activities.Add(selectedActivity);
                selectedActivities.Remove(selectedActivity);

                //method to refresh screen
                RefreshScreen();
            }

            //move item from left to right


        }

        private void RefreshScreen()
        {
            LBXallactivites.ItemsSource = null;
            LBXallactivites.ItemsSource = activities;

            LBXselectedactivities.ItemsSource = null;
            LBXselectedactivities.ItemsSource = selectedActivities;
        }

        //handles all radio buttons
        private void RBall_Click(object sender, RoutedEventArgs e)
        {
            filteredactivities.Clear();

            if(RBall.IsChecked == true)
            {
                //show all bikes
                RefreshScreen();
            }
            else if(RBair.IsChecked == true)
            {
                //display air activities
                foreach(Activity activity in activities)
                {
                    if(activity.Category == Category.Air )
                    {
                        filteredactivities.Add(activity);
                        LBXallactivites.ItemsSource = null;
                        LBXallactivites.ItemsSource = filteredactivities;

                    }                          
                }

            }
            else if (RBland.IsChecked == true)
            {
                //display land activities

                foreach (Activity activity in activities)
                {
                    if (activity.Category == Category.Land)
                    {
                        filteredactivities.Add(activity);
                        LBXallactivites.ItemsSource = null;
                        LBXallactivites.ItemsSource = filteredactivities;

                    }
                }

            }
            else if (RBwater.IsChecked == true)
            {
                //display water activities
                foreach (Activity activity in activities)
                {
                    if (activity.Category == Category.Water)
                    {
                        filteredactivities.Add(activity);
                        LBXallactivites.ItemsSource = null;
                        LBXallactivites.ItemsSource = filteredactivities;

                    }
                }
                //displayer water activities

            }


        }

        //private void Window_Loaded(object sender, RoutedEventArgs e)
        //{
        //        //create 3 expense objects
        //        Activity e1 = GetRandomExpense();
        //        Activity e2 = GetRandomExpense();
        //        Activity e3 = GetRandomExpense();

        //    //add those to a list
        //    expenses = new ObservableCollection<Activity>();  //new list assigned on window load
        //    expenses.Add(e1);
        //    expenses.Add(e2);
        //    expenses.Add(e3);

        //    //display list in list box
        //    LBXallactivites.ItemsSource = expenses;
        //    TBLtotalcost.Text = Activity.TotalCost.ToString("C");

    }//end of method

    //method to add expense item
    //private void BTNadd_Click(object sender, RoutedEventArgs e)
    //{
    //    //add that to the list
    //    expenses.Add(GetRandomExpense());
    //    TBLtotalcost.Text = Activity.TotalCost.ToString();
    //}

    //private Activity GetRandomExpense()
    //{

    //        //    public Activity(string newname, DateTime newdate, decimal newcost, string newdesc)
    //        //get random category
    //        string[] Name = { "Mary", "John", "Jack" };
    //    int randomNumber = rng.Next(0, 3); //0, 1 or 2
    //  //  string category = categories[randomNumber];

    //    //get random amount
    //    randomNumber = rng.Next(1, 10001);
    //    decimal randomAmount = (decimal)randomNumber / 100;

    //    //get random date = in the last 30 days
    //    randomNumber = rng.Next(0, 31); //0 .. 30
    //    DateTime randomDate = DateTime.Now.AddDays(-randomNumber); //give a date in the last 30 days

    //        //create an expense object with random info
    //       // Activity e1 = new Activity(randomAmount, randomDate, category);

    //    //return random object
    //    //return e1;
    //}
}


