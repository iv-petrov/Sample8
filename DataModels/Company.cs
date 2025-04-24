using System.ComponentModel.DataAnnotations;

namespace Sample8.DataModels
{
    public class Company 
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Inn { get; set; }
        public string? Email { get; set; }

        public Company() 
        { 
        }
        public Company(int id, string name, string inn, string email)
        {
            Id = id;
            Name = name;
            Inn = inn;
            Email = email;
        }
    }
}
