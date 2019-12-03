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

        //Creating lists
        List<Activity> activities = new List<Activity>();
        List<Activity> selectedActivities = new List<Activity>();
        List<Activity> filteredactivities = new List<Activity>();
        //variable
        decimal total = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Creating values for the list
            Activity Act1 = new Activity("Treking", new DateTime(2019, 06, 03), 30m, "A trek to the mountains", Category.Land);
            Activity Act2 = new Activity("Mountain Bike", new DateTime(2011, 01, 02), 50m, "Mountain biking, all equipment provided", Category.Land);
            Activity Act3 = new Activity("Absailing", new DateTime(2017, 12, 12), 70m, "Up to 1000m high", Category.Water);
            Activity Act4 = new Activity("Kayaking", new DateTime(2015, 03, 06), 70m, "Travel to an island picnic", Category.Water);
            Activity Act5 = new Activity("Surfing", new DateTime(2000, 11, 07), 50m, "2 hour long surd", Category.Water);
            Activity Act6 = new Activity("Sailing", new DateTime(2014, 07, 08), 80m, "Boat needed", Category.Water);
            Activity Act7 = new Activity("Parachuting", new DateTime(2019, 02, 01), 200m, "May be dangerous", Category.Air);
            Activity Act8 = new Activity("Hand Gliding", new DateTime(2018, 07, 10), 300m, "Totally safe", Category.Air);
            Activity Act9 = new Activity("Helicopter Tour", new DateTime(2016, 12, 02), 1000m, "For the rich", Category.Air);

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
            LBXallactivites.ItemsSource = activities; //tell listbox that the source of items is the list activitie
        }

        //If the buttonAdd is clicked this method executes 
        private void BTNadd_Click(object sender, RoutedEventArgs e)
        {
            //figure out what item is selected
            Activity selectedActivity = LBXallactivites.SelectedItem as Activity;
            //if selected activity is not null executes code
            if (selectedActivity != null)
            {
                //move item from left to right
                activities.Remove(selectedActivity);
                selectedActivities.Add(selectedActivity);   

                //shows description when item is selected
                TBLdesc.Text = selectedActivity.Name + "  Type: " + selectedActivity.Category;

                //method to refresh screen
                RefreshScreen();

                //add to total cost
                total += selectedActivity.TotalCost;
                TBLtotalcost.Text = total.ToString();
            }
            //if nothing is selected error message displays
            else
            {
                ErrorMessage();
            }
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

                //add to total cost
                total -= selectedActivity.TotalCost;
                TBLtotalcost.Text = total.ToString();
            }
            //if nothing is selected error message displays
            else
            {
                ErrorMessage();
            }
        }

        private void RefreshScreen()
        {
            //Makes list box null and then fills it with activities again,
            LBXallactivites.ItemsSource = null;
            LBXallactivites.ItemsSource = activities;

            //same as above but with a different list box, this is to prevent overlapping
            LBXselectedactivities.ItemsSource = null;
            LBXselectedactivities.ItemsSource = selectedActivities;
        }

        private void ErrorMessage()
        {
            //if nothing is selected an error message will display
            //Creating an error message and giving the text block it's value (if the if statement is true)
            string errorMessage = "ERROR: Nothing has been selected";
            TBLdesc.Text = errorMessage;

        }

        //handles all radio buttons
        private void RBall_Click(object sender, RoutedEventArgs e)
        {
            //clears previous filter
            filteredactivities.Clear();

            //if the radio button all is clicked
            if (RBall.IsChecked == true)
            {
                //show all bikes
                RefreshScreen();
            }

            //if the radio button air is clicked
            else if (RBair.IsChecked == true)
            {
                //display air activities
                foreach (Activity activity in activities)
                {
                    if (activity.Category == Category.Air)
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
            }
        }
    }
}


