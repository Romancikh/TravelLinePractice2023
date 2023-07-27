namespace Core.Models
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Illness { get; set; } = string.Empty;
        public List<Reception> Receptions { get; set; } = new List<Reception>();

        public override string ToString()
        {
            return $"{PatientId}) {FirstName} {LastName} - {Illness}";
        }
    }
}
