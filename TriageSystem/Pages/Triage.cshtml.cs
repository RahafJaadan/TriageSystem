using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Reflection.Emit;

public class TriageModel1 : PageModel
{
    private readonly AppDbContext _context;

    public TriageModel1(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public int Temperature { get; set; }

    [BindProperty]
    public int Oxygen { get; set; }

    [BindProperty]
    public int Pulse { get; set; }

    [BindProperty]
    public int BloodPressure { get; set; }

    [BindProperty]
    public int RespiratoryRate { get; set; }
    
    [BindProperty]
    public int Level { get; set; }

    [BindProperty]
    public int PatientsBeforeCount { get; set; }

    public void OnPost()
    {
        if (Oxygen < 90 || BloodPressure < 90 || RespiratoryRate > 30)
        {
            Level = 1;
        }
        else if (Temperature > 39 || RespiratoryRate > 22)
        {
            Level = 2;
        }
        else if (Pulse > 100)
        {
            Level = 3;
        }
        else if (Temperature >= 37.5)
        {
            Level = 4;
        }
        else 
        { 
            Level = 5;
        }

        var newPatient = new Patient
        {
            Temperature = Temperature,
            Oxygen = Oxygen,
            Pulse = Pulse,
            BloodPressure = BloodPressure,
            RespiratoryRate = RespiratoryRate,
            Level = Level
        };


        _context.Patients.Add(newPatient);
        _context.SaveChanges();

        PatientsBeforeCount = _context.Patients
        .Where(p => p.Level == newPatient.Level && p.Id < newPatient.Id)
        .Count();
    }
}