using System.ComponentModel.DataAnnotations;

namespace Sample8.DataAccess
{
    public class Company 
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "Не указано Наименование")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Не указан ИНН компании")]
        public string Inn { get; set; }
        public string? Email { get; set; }

        public Company(int id, string name, string inn, string email)
        {
            Id = id;
            Name = name;
            Inn = inn;
            Email = email;
        }
    }
}
