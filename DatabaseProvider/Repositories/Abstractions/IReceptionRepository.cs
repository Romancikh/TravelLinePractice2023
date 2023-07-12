using Core.Models;

namespace DatabaseProvider.Repositories.Abstractions
{
    public interface IReceptionRepository : IRepository<Reception>
    {
        public List<Reception> GetAll();
        public Reception? GetById( int id );
        public List<Reception> GetByPatientId( int id );
        public List<Reception> GetByDoctorId( int id );
    }
}
