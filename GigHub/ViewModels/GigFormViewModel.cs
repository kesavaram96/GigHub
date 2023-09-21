using GigHub.Models;

namespace GigHub.ViewModels
{
    public class GigFormViewModel
    {
        public string Venue { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public int Genre { get; set; }
        public DateTime DateTime { 
            get {
                return DateTime.Parse(String.Format("{0} {1}", Date, Time));
            } 
        }


    }
}
