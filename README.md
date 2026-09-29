[README_SHUber.md](https://github.com/user-attachments/files/32797336/README_SHUber.md)
# SHUBer Taxi Management System

A C# Windows Forms desktop application for managing a taxi business, backed by a SQLite relational database. It stores customers, drivers, vehicles, journeys, payments and ratings, and uses SQL reports and charts to show which drivers and customers perform best.

Built as a first-year project for the BEng (Hons) Software Engineering course at Sheffield Hallam University.


## Features

- **Relational database** with six linked tables: `Customer`, `Driver`, `Journey`, `Payment`, `Rating` and `Vehicle`
- **Top 5 drivers report:** ranks drivers by the number of journeys rated 4.5 or higher
- **Top 5 customers report:** ranks customers by recent rides, total spending and 5-star ratings given
- **Chart visualisation** of the report results inside the Windows Forms interface
- **Data manipulation** through SQL queries (joins, aggregation, ordering and filtering)

## Tech Stack

| Area | Technology |
|---|---|
| Language | C# |
| UI | Windows Forms |
| Database | SQLite |
| Queries | SQL |
| IDE | Visual Studio 2022 |

## Database Design

| Table | Purpose |
|---|---|
| Customer | People who book journeys |
| Driver | Drivers who complete journeys |
| Vehicle | Vehicles used by drivers |
| Journey | Each trip, linking a customer, driver and vehicle |
| Payment | Payment made for a journey |
| Rating | Rating given to a driver for a journey |

<!-- Optional: add an ER diagram image here, e.g. ![ER diagram](screenshots/erd.png) -->

## Getting Started

### Prerequisites

- Windows
- [Visual Studio 2022](https://visualstudio.microsoft.com/) with the **.NET desktop development** workload
- [FILL IN: .NET version, e.g. .NET Framework 4.8 / .NET 8]

### Run the project

1. Clone the repository:
   ```bash
   git clone https://github.com/Omarali2006265/Project-ChartVisualisation.git
   ```
2. Open the `.sln` file in Visual Studio 2022.
3. Restore NuGet packages if prompted. [FILL IN: e.g. System.Data.SQLite]
4. Make sure the SQLite database file is in [FILL IN: folder/file name] and is copied to the output directory.
5. Press **F5** to build and run.

## How It Works

1. The app connects to the SQLite database when it starts.
2. SQL queries join the Journey, Driver, Customer and Rating tables to build the reports.
3. The results are shown in the Windows Forms interface and plotted as charts.

## What I Learned

- Designing and normalising a relational database
- Writing SQL queries that combine several tables
- Connecting a C# Windows Forms application to SQLite
- Presenting query results as charts

## Author

**Omar Ali**
[GitHub](https://github.com/Omarali2006265) · [LinkedIn](https://linkedin.com/in/omar-ali-368473371)
