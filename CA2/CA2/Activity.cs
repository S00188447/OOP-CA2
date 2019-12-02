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
        private decimal _amount;
        public decimal Amount
        {
            get { return _amount; }
            set
            {
                TotalCost += value;
                _amount = value;
            }
        }


        //Properties
        public string Name { get; set; }
        public DateTime ActivityDate { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }

        public static decimal TotalCost;

        

        public override string ToString()
        {
            return Name + " - " + ActivityDate; 
        }

        //Constructors - will return later
        //public Expense() : this(0, DateTime.Now, "unknown")
        // {

        //}


        public Activity(string newname, DateTime newdate, decimal newcost, string newdesc, Category newcategory)
        {
            Name = newname;
            ActivityDate = newdate;
            Cost = newcost;
            Description = newdesc;
            TotalCost += newcost;
            Category = newcategory;
        }


        //Methods
        //public override string ToString()
        //{
        //    return $"{Category} {Amount:C} on {ActivityDate.ToShortDateString()}";
        //}

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
