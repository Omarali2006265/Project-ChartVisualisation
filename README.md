[README_SHUber.md](https://github.com/user-attachments/files/32798084/README_SHUber.md)

# SHUBer Taxi Management System

A C# Windows Forms application that reads a SQLite taxi database and turns it into two bar-chart reports: the top 5 drivers and the top 5 customers. The SQL does the ranking and the app plots the results.

Built as a first-year project for the *Databases & System Modelling* module on the BEng (Hons) Software Engineering course at Sheffield Hallam University.

## Features

- **Main menu** that opens either report and returns to it from each report screen
- **Report 1: Top 5 drivers.** Ranks drivers by the number of journeys rated 4.5 or higher
- **Report 2: Top 5 customers.** Ranks customers by rides taken in the last 3 months, keeping only customers who also meet the spending and 5-star rating thresholds below
- **Bar charts** for both reports, drawn with the built-in .NET `System.Windows.Forms.DataVisualization` chart control, with value labels and axis titles
- **Relational database** with six linked tables and foreign keys that cascade on update and delete

## Tech Stack

| Area | Technology |
|---|---|
| Language | C# |
| UI | Windows Forms (.NET Framework 4.8) |
| Database | SQLite via `System.Data.SQLite` 1.0.119 (NuGet) |
| Charts | `System.Windows.Forms.DataVisualization` |
| IDE | Visual Studio 2022 |

## Database

The database file is `SHUber-ProjectDatabaseandSystemModelling.db.db`. It holds sample data for 10 customers, 10 drivers, 10 vehicles and 40 journeys, with a rating and a payment for each journey.

| Table | Purpose | Key relationships |
|---|---|---|
| `Customer` | Customer details and average rating | Primary key `Cust_ID` |
| `Driver` | Driver details and average rating | Primary key `Driver_ID` |
| `Vehicle` | A driver's vehicle (registration, make, model, colour, year) | `Driver_ID` refers to `Driver` |
| `Journey` | Each trip: pickup, drop-off, date and time, cost, ratings | `Cust_ID` refers to `Customer`, `Driver_ID` refers to `Driver` |
| `Rating` | Customer and driver ratings and comments for a journey | `Journey_ID` refers to `Journey` |
| `Payment` | Amount, date, method and status of a payment | `Journey_ID` refers to `Journey` |

All foreign keys use `ON DELETE CASCADE ON UPDATE CASCADE`.

## The Reports

### Report 1: Top 5 drivers by highly rated journeys

Joins `Journey` to `Driver`, keeps journeys where `Driver_Rating >= 4.5`, groups by driver and returns the five drivers with the most such journeys.

Concepts used: `INNER JOIN`, `WHERE`, `GROUP BY`, `COUNT`, `ORDER BY ... DESC`, `LIMIT`.

### Report 2: Top 5 customers by rides, spend and 5-star ratings

Joins `Customer`, `Journey` and `Rating` for journeys between 1 August and 31 October 2025. A customer is only included if they have:

- at least **3 rides** in the period
- an average monthly spend above **£100** (total cost divided by 3)
- at least **5 five-star ratings**

Customers are ranked by number of rides and the chart plots the top five.

Concepts used: three-table `INNER JOIN`, `GROUP BY`, `HAVING` with several conditions, `COUNT(CASE WHEN ...)`, `ROUND`, `SUM`, `LIMIT`.

With the included sample data, only two customers meet all three thresholds, so Report 2 shows two bars rather than five.

## Getting Started

### Prerequisites

- Windows
- [Visual Studio 2022](https://visualstudio.microsoft.com/) with the **.NET desktop development** workload (includes .NET Framework 4.8)

### Run the project

1. Clone the repository:
   ```bash
   git clone https://github.com/Omarali2006265/Project-ChartVisualisation.git
   ```
2. Open `Project ChartVisualisation.sln` in Visual Studio 2022.
3. Let NuGet restore the packages (`System.Data.SQLite.Core` 1.0.119) if prompted.
4. Press **F5** to build and run. The database file is copied to the output folder automatically, and the app opens it using a relative path.

## Project Structure

```
Project ChartVisualisation/
├── MainMenu.cs / .Designer.cs     Main menu with buttons for each report
├── Report1.cs / .Designer.cs      Top 5 drivers query and chart
├── Report2.cs / .Designer.cs      Top 5 customers query and chart
├── Program.cs                     Application entry point (opens MainMenu)
├── SHUber-ProjectDatabaseandSystemModelling.db.db   SQLite database
└── packages.config                NuGet dependencies
```

## Known Limitations

- The date range in Report 2 is hardcoded to August to October 2025 rather than calculated as "the last 3 months".
- The app only reads data. It has no screens for adding, editing or deleting customers, drivers or journeys.

## Possible Improvements

- Calculate Report 2's date range from the current date
- Add forms for creating and editing journeys, drivers and customers
- Show the report results in a table beside each chart

## Author

**Omar Ali**
[GitHub](https://github.com/Omarali2006265) · [LinkedIn](https://linkedin.com/in/omar-ali-368473371)
