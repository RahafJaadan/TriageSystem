using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace TriageSystem.Pages;
using System.Linq;
public class DashboardModel : PageModel
{
    private readonly AppDbContext _context;

    public DashboardModel(AppDbContext context)
    {
        _context = context;
    }
    public int Level1Count { get; set; }
    public int Level2Count { get; set; }
    public int Level3Count { get; set; }
    public int Level4Count { get; set; }
    public int Level5Count { get; set; }
    public string? SelectedFilter { get; set; }

    public void OnGet(string filter)
    {
        SelectedFilter = filter ?? "today";

        DateTime startDate = DateTime.Today;

        if (SelectedFilter == "yesterday")
        {
            startDate = DateTime.Today.AddDays(-1);
        }
        else if (SelectedFilter == "week")
        {
            startDate = DateTime.Today.AddDays(-7);
        }
        else if (SelectedFilter == "month")
        {
            startDate = DateTime.Today.AddMonths(-1);
        }

        Level1Count = _context.Patients
        .Where(p => p.Level == 1 && p.CreatedAt >= startDate)
        .Count();

        Level2Count = _context.Patients
        .Where(p => p.Level == 2 && p.CreatedAt >= startDate)
        .Count();

        Level3Count = _context.Patients
        .Where(p => p.Level == 3 && p.CreatedAt >= startDate)
        .Count();

        Level4Count = _context.Patients
        .Where(p => p.Level == 4 && p.CreatedAt >= startDate)
        .Count();

        Level5Count = _context.Patients
        .Where(p => p.Level == 5 && p.CreatedAt >= startDate)
        .Count();
    }
}