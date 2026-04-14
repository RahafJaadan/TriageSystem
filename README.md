# TriageSystem


## Emergency Triage System
A smart emergency triage web application built using ASP.NET Core that classifies patients based on vital signs and provides real-time dashboard insights.


## Overview
This system simulates a real emergency department workflow by:
- Classifying patients into triage levels automatically
- Tracking patient flow and waiting order
- Displaying real-time statistics through a dashboard
- Providing daily analytics (updated every 24 hours)


## Features
Triage Classification

Patients are categorized into 4 levels based on:
- Temperature
- Oxygen Saturation (SpO₂)
- Pulse Rate
- Blood Pressure
- Respiratory Rate
- The system automatically assigns a level using predefined logic.


## Waiting Queue Logic
- Displays how many patients are ahead in the same triage level
- Works continuously (not affected by daily reset)
- Reflects real-world emergency department behavior


## Dashboard Analytics
- Real-time visualization of patient distribution
- Doughnut chart representing triage levels 
- Total patient count
- Filtered views:
  
     Today

     Yesterday
  
     Last 7 days
  
     Last 30 days


## Automatic Daily Reset
- Dashboard statistics reset automatically at 12:00 AM
- Historical data is preserved in the database
- No manual reset require


## Technologies Used
- ASP.NET Core Razor Pages
- C#
- Entity Framework Core
- SQLite
- Chart.js
- HTML / CSS


## System Logic (Simplified)
```
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
else if (Temperature >= 38)
{
    Level = 4;
}
else
{
    Level = 5; 
}
```

## Project Structure
```
/Pages
  ├── Triage.cshtml
  ├── Triage.cshtml.cs
  ├── Dashboard.cshtml
  ├── Dashboard.cshtml.cs

/Models
  └── Patient.cs

/wwwroot
  └── css
      └── site.css

```

## Getting Started
1- Clone the repository:
```
git clone https://github.com/RahafJaadan/triage-system.git
```
2- Open the project in Visual Studio

3- Run the application

4- Start adding patients and explore the dashboard


## Future Improvements
- Patient status tracking (Waiting / Completed)
- Export reports (Excel / PDF)
- User authentication
- Integration with hospital systems


## License
This project is for educational and demonstration purposes.

