using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2
{

    public enum Category {Air, Water, Land }
    public class Activity : IComparable
    {
        //Properties
        public decimal Cost { get; set;}
        public string Name { get; set; }
        public DateTime ActivityDate { get; set; }
        public static string Description { get; set; }
        public Category Category { get; set; }
        public decimal TotalCost { get; set; }
        public override string ToString()
        {
            return $" {Name}{" - "}{ ActivityDate.ToShortDateString() }"; 
        }
        public Activity(string newname, DateTime newdate, decimal newcost, string newdesc, Category newcategory)
        {
            Name = newname;
            ActivityDate = newdate;
            Cost = newcost;
            Description = newdesc;
            TotalCost += newcost;
            Category = newcategory;
        }

        public int CompareTo(object obj)
        {
            //get a reference to the next object in the list
            Activity objectthatIamcomparingto = (Activity)obj;

            //choosing the video I am comparing
            int returnValue = this.ActivityDate.CompareTo(objectthatIamcomparingto.ActivityDate);

            //return
            return returnValue;
        }      
    }
}
