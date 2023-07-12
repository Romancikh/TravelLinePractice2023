namespace Core.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Specialty { get; set; } = string.Empty;
        public List<Reception> Receptions { get; set; } = new List<Reception>();
        public override string ToString()
        {
            return $"{DoctorId}) {FirstName} {LastName} - {Specialty}";
        }
    }
}
