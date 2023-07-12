using Core.Models;
using DatabaseProvider;
using DatabaseProvider.Repositories.Abstractions;
using DatabaseProvider.Repositories.Implementations;

namespace HospitalDb
{
    public class Program
    {
        private const string connectionString =
                "Data Source=MILKYWAY\\SQLEXPRESS;Initial Catalog=HospitalDb;Pooling=true;Integrated Security=SSPI";
        private static ApplicationContext _applicationContext;
        private static IDoctorRepository _doctorRepository;
        private static IPatientRepository _patientRepository;
        private static IReceptionRepository _receptionRepository;
        public static void Main( string[] args )
        {
            _applicationContext = new ApplicationContext( connectionString );
            _doctorRepository = new DoctorRepository( _applicationContext );
            _patientRepository = new PatientRepository( _applicationContext );
            _receptionRepository = new ReceptionRepository( _applicationContext );
            PrintCommandsList();
            ProcessComands();
        }
        static void PrintCommandsList()
        {
            Console.WriteLine( "Available commands:" );
            Console.WriteLine( "\tadd-doctor [firstName] [lastName] [specialty]" );
            Console.WriteLine( "\tremove-doctor [doctorId]" );
            Console.WriteLine( "\tadd-patient [firstName] [lastName] [illness]" );
            Console.WriteLine( "\tremove-patient [patientId]" );
            Console.WriteLine( "\tadd-reception [roomNumber] [doctorId] [patientId]" );
            Console.WriteLine( "\tremove-reception [receptionId]" );
            Console.WriteLine( "\tlist-doctors" );
            Console.WriteLine( "\tlist-patients" );
            Console.WriteLine( "\tlist-receptions" );
            Console.WriteLine( "\tlist-receptions-by-doctor [doctorId]" );
            Console.WriteLine( "\tlist-receptions-by-patient [patientId]" );
            Console.WriteLine( "\texit" );
        }
        static void ProcessComands()
        {
            while ( true )
            {
                Console.Write( "Enter command: " );
                string[] commandLine = Console.ReadLine()!.Split( ' ' );
                string command = commandLine[ 0 ];
                List<string> parameters = commandLine.Skip( 1 ).ToList();
                switch ( command )
                {
                    case "exit":
                        return;
                    case "add-doctor":
                        AddDoctor( parameters );
                        break;
                    case "remove-doctor":
                        RemoveDoctor( parameters );
                        break;
                    case "add-patient":
                        AddPatient( parameters );
                        break;
                    case "remove-patient":
                        RemovePatient( parameters );
                        break;
                    case "add-reception":
                        AddReception( parameters );
                        break;
                    case "remove-reception":
                        RemoveReception( parameters );
                        break;
                    case "list-doctors":
                        ListDoctors();
                        break;
                    case "list-patients":
                        ListPatients();
                        break;
                    case "list-receptions":
                        ListReceptions();
                        break;
                    case "list-receptions-by-doctor":
                        ListReceptionsByDoctor( parameters );
                        break;
                    case "list-receptions-by-patient":
                        ListReceptionsByPatient( parameters );
                        break;
                    default:
                        break;

                }
            }
        }
        static void AddDoctor( List<string> parameters )
        {
            Doctor doctor = new()
            {
                FirstName = parameters[ 0 ],
                LastName = parameters[ 1 ],
                Specialty = parameters[ 2 ]
            };
            _doctorRepository?.Add( doctor );
            _doctorRepository?.SaveChanges();
        }
        static void RemoveDoctor( List<string> parameters )
        {
            int doctorId = int.Parse( parameters[ 0 ] );
            Doctor? doctor = _doctorRepository.GetById( doctorId );
            if ( doctor != null )
            {
                _doctorRepository.Remove( doctor );
                _doctorRepository.SaveChanges();
            }
        }
        static void AddPatient( List<string> parameters )
        {
            Patient patient = new()
            {
                FirstName = parameters[ 0 ],
                LastName = parameters[ 1 ],
                Illness = parameters[ 2 ]
            };
            _patientRepository.Add( patient );
            _patientRepository.SaveChanges();
        }
        static void RemovePatient( List<string> parameters )
        {
            int patientId = int.Parse( parameters[ 0 ] );
            Patient? patient = _patientRepository.GetById( patientId );
            if ( patient != null )
            {
                _patientRepository.Remove( patient );
                _patientRepository.SaveChanges();
            }
        }
        static void AddReception( List<string> parameters )
        {
            int roomNumber = int.Parse( parameters[ 0 ] );
            int doctorId = int.Parse( parameters[ 1 ] );
            int patientId = int.Parse( parameters[ 2 ] );
            Doctor? doctor = _doctorRepository.GetById( doctorId );
            Patient? patient = _patientRepository.GetById( patientId );
            if ( patient != null && doctor != null )
            {
                Reception reception = new()
                {
                    RoomNumber = roomNumber,
                    DoctorId = doctorId,
                    Doctor = doctor,
                    PatientId = patientId,
                    Patient = patient
                };
                _receptionRepository.Add( reception );
                _receptionRepository.SaveChanges();
            }
        }
        static void RemoveReception( List<string> parameters )
        {
            int receptionId = int.Parse( parameters[ 0 ] );
            Reception? reception = _receptionRepository.GetById( receptionId );
            if ( reception != null )
            {
                _receptionRepository.Remove( reception );
                _receptionRepository.SaveChanges();
            }
        }
        static void ListDoctors()
        {
            _doctorRepository.GetAll().ForEach( ( doctor ) => Console.WriteLine( doctor ) );
        }
        static void ListPatients()
        {
            _patientRepository.GetAll().ForEach( ( patient ) => Console.WriteLine( patient ) );
        }
        static void ListReceptions()
        {
            _receptionRepository.GetAll().ForEach( ( reception ) => Console.WriteLine( reception ) );
        }
        static void ListReceptionsByDoctor( List<string> parameters )
        {
            int doctorId = int.Parse( parameters[ 0 ] );
            _receptionRepository.GetByDoctorId( doctorId ).ForEach( ( reception ) => Console.WriteLine( reception ) );
        }
        static void ListReceptionsByPatient( List<string> parameters )
        {
            int patientId = int.Parse( parameters[ 0 ] );
            _receptionRepository.GetByPatientId( patientId ).ForEach( ( reception ) => Console.WriteLine( reception ) );
        }
    }
}
