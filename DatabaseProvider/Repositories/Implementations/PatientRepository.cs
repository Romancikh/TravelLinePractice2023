using Core.Models;
using DatabaseProvider.Repositories.Abstractions;

namespace DatabaseProvider.Repositories.Implementations
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        public PatientRepository( ApplicationContext context ) : base( context ) { }
        public List<Patient> GetAll()
        {
            return Entities.ToList();
        }
        public Patient? GetById( int id )
        {
            return Entities.Where( p => p.PatientId == id ).FirstOrDefault();
        }
    }
}
