using desafio_rsm.Models;
using desafio_rsm.Dtos;

namespace desafio_rsm.Repository
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetPeoplePaginated(PaginationFilter paginationFilter);
        Task<IEnumerable<Person>> GetPeople();
        Task<Person> GetPerson(long id);
        Task<int> CountPeople();
        void CreatePerson(Person person);
        void UpdatePerson(Person person);
        void DeletePerson(Person person);
        Task<bool> SaveChangesAsync();
    }
}