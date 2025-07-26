using System.ComponentModel.DataAnnotations;

namespace test_one.Model
{
    public class Customer
    {
        [Key] public int id { get; set; }
        public string name { get; set; }
        public int number { get; set; }
        public string email { get; set; }
        public string address { get; set; }
    }
}
