using Sample8.DataModels;

namespace Sample8.Domain
{
    public interface ICompanyService
    {
        /// <summary>
        /// Получение списка компаний
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Company> GetAll();
        /// <summary>
        /// Получение реквизитов компании по ид
        /// </summary>
        /// <param name="id">Ид компании</param>
        /// <returns>Реквизиты компании</returns>
        public Company GetById(int id);
        /// <summary>
        /// Добавление новой коспании в список
        /// </summary>
        /// <param name="company">Реквизиты добавляемой компании</param>
        public void AppendCompany(Company company);
        /// <summary>
        /// Обновление реквизитов компании
        /// </summary>
        /// <param name="id">Ид компании</param>
        /// <param name="company">Новые реквизиты</param>
        public void UpdateCompany(Company company);
        /// <summary>
        /// Удаление компании из списка
        /// </summary>
        /// <param name="id">Ид компании</param>
        public void DeleteCompany(int id);
    }
}
