namespace Sample8.DataModels
{
    public class CompaniesList : List<Company>
    {
        public CompaniesList() 
        {
            this.Add(new Company(1, "Тестовая компания", "7800245852", "mail@abc.com"));
        }
    }
}
