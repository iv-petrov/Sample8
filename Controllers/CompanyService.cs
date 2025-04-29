using Sample8.DataAccess;
using Sample8.Domain;

namespace Sample8.Controllers
{
    public class CompanyService : ICompanyService
    {
        private ApplicationDbContext _context;
        public CompanyService(ApplicationDbContext context)
        {
            _context = context;
        }
        /// <inheritdoc/>
        public IEnumerable<Company> GetAll()
        {
            return _context.Companies;
        }
        /// <inheritdoc/>
        public Company GetById(int id)
        {
            return _context.Companies.FirstOrDefault(x => x.Id == id);
        }
        /// <inheritdoc/>
        public void AppendCompany(Company company) 
        {
            ArgumentNullException.ThrowIfNull(company);

            if (_context.Companies.Any(c => c.Inn == company.Inn)) 
            {
                throw new ArgumentException("ИНН не должен дублироваться");
            }
            if (!_context.Companies.Any())
            {
                company.Id = 1;
            }
            else
            {
                company.Id = _context.Companies.Max(x => x.Id) + 1;
            }
            _context.Companies.Add(company);
            _context.SaveChanges();
        }
        /// <inheritdoc/>
        public void UpdateCompany(Company company)
        {
            ArgumentNullException.ThrowIfNull(company);

            if (!_context.Companies.Any(x => x.Id == company.Id))
            {
                throw new ArgumentException(@"Компании {company.id} не существует");
            }
            _context.Companies.Update(company);
            _context.SaveChanges();
        }
        /// <inheritdoc/>
        public void DeleteCompany(int id) 
        {
            if (!_context.Companies.Any(x => x.Id == id))
            {
                throw new ArgumentException(@"Компании {id} не существует");
            }
            _context.Companies.Remove(GetById(id));
            _context.SaveChanges();
        }
    }
}
