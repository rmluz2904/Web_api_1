using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_api_1.Model
{
    [Table("employee")]
    public class Employee
    {
        [Key]
        public int id { get; private set; }
        public string name { get; private set; }
        public int age { get; private set; }

        public Employee(string name, int age)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.age = age;
        }
    }
}