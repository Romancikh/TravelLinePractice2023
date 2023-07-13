using Core.Models;
using DatabaseProvider.Repositories.Abstractions;

namespace DatabaseProvider.Repositories.Implementations
{
    public class ReceptionRepository : Repository<Reception>, IReceptionRepository
    {
        public ReceptionRepository( ApplicationContext context ) : base( context ) { }
        public List<Reception> GetAll()
        {
            return Entities.ToList();
        }
        public Reception? GetById( int id )
        {
            return Entities.FirstOrDefault( r => r.ReceptionId == id );
        }
        public List<Reception> GetByDoctorId( int id )
        {
            return Entities.Where( r => r.DoctorId == id ).ToList();
        }
        public List<Reception> GetByPatientId( int id )
        {
            return Entities.Where( r => r.PatientId == id ).ToList();
        }
    }
}
