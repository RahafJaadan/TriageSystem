using System;

public class Patient
{
    public int Id { get; set; }

    public int Temperature { get; set; }
    public int Oxygen { get; set; }
    public int Pulse { get; set; }
    public int BloodPressure { get; set; }
    public int RespiratoryRate { get; set; }
        


    public int Level { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;


   
}
