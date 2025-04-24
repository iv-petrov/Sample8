using Sample8.Domain;
using Sample8.DataModels;

namespace Sample8.Controllers
{
    public class CompanyService : ICompanyService
    {
        public List<Company> Companies { get; set; }
        public CompanyService() 
        {
            Companies = new CompaniesList();
        }
        /// <inheritdoc/>
        public IEnumerable<Company> GetAll()
        {
            return Companies;
        }
        /// <inheritdoc/>
        public Company GetById(int id)
        {
            return Companies.FirstOrDefault(x => x.Id == id);
        }
        /// <inheritdoc/>
        public void AppendCompany(Company company) 
        {
            ArgumentNullException.ThrowIfNull(company);

            if (Companies.Any(c => c.Inn == company.Inn)) 
            {
                throw new ArgumentException("ИНН не должен дублироваться");
            }
            if (Companies.Count == 0)
            {
                company.Id = 1;
            }
            else
            {
                company.Id = Companies.Max(x => x.Id) + 1;
            }
            Companies.Add(company);
        }
        /// <inheritdoc/>
        public void UpdateCompany(Company company)
        {
            ArgumentNullException.ThrowIfNull(company);

            if (!Companies.Any(x => x.Id == company.Id))
            {
                throw new ArgumentException(@"Компании {company.id} не существует");
            }
            int i = Companies.FindIndex(x => x.Id == company.Id);
            Companies[i] = company;
        }
        /// <inheritdoc/>
        public void DeleteCompany(int id) 
        {
            if (!Companies.Any(x => x.Id == id))
            {
                throw new ArgumentException(@"Компании {id} не существует");
            }
            Companies.Remove(GetById(id));
        }
    }
}
