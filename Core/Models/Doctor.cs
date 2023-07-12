namespace Core.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Specialty { get; set; }
        public List<Reception> Receptions { get; set; } = new List<Reception>();
        public override string ToString()
        {
            return $"{FirstName} {LastName} - {Specialty}";
        }
    }
}
