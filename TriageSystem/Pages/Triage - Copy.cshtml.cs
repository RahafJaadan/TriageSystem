using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class TriageModel : PageModel
{
    [BindProperty]
    public double Temperature { get; set; }

    [BindProperty]
    public int Oxygen { get; set; }

    [BindProperty]
    public int Pulse { get; set; }

    [BindProperty]
    public int BloodPressure { get; set; }

    public int Level { get; set; }

    public void OnPost()
    {
        if (Oxygen < 90 || BloodPressure < 90)
            Level = 4;
        else if (Temperature >= 39)
            Level = 3;
        else if (Pulse > 100)
            Level = 2;
        else
            Level = 1;

    }
}

