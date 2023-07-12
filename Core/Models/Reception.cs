namespace Core.Models
{
    public class Reception
    {
        public int ReceptionId { get; set; }
        public int DoctorId { get; set; }
        public Doctor? Doctor { get; set; }
        public int PatientId { get; set; }
        public Patient? Patient { get; set; }
        public int RoomNumber { get; set; }
        public override string ToString()
        {
            if ( Doctor == null || Patient == null ) return $"{ReceptionId} - {RoomNumber}";
            return $"{Doctor}, {Patient} - {RoomNumber}";
        }

    }
}
