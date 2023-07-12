using Core.Models;

namespace DatabaseProvider.Repositories.Abstractions
{
    public interface IPatientRepository : IRepository<Patient>
    {
        public List<Patient> GetAll();
        public Patient GetById( int id );
    }
}
