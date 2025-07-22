using System.ComponentModel.DataAnnotations;

namespace test_one.Model
{
    public class Customer
    {
        [Key] public int Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
