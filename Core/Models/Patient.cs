namespace Core.Models
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Illness { get; set; }
        public List<Reception> Receptions { get; set; } = new List<Reception>();
        public override string ToString()
        {
            return $"{FirstName} {LastName} - {Illness}";
        }
    }
}
