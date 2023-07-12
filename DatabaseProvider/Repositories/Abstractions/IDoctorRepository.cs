using Core.Models;

namespace DatabaseProvider.Repositories.Abstractions
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        public List<Doctor> GetAll();
        public Doctor GetById( int id );
    }
}
