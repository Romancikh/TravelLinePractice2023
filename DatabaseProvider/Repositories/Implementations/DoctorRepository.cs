using Core.Models;
using DatabaseProvider.Repositories.Abstractions;

namespace DatabaseProvider.Repositories.Implementations
{
    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {
        public DoctorRepository( ApplicationContext context ) : base( context ) { }

        public List<Doctor> GetAll()
        {
            return Entities.ToList();
        }

        public Doctor GetById( int id )
        {
            return Entities.FirstOrDefault( d => d.DoctorId == id );
        }
    }
}
