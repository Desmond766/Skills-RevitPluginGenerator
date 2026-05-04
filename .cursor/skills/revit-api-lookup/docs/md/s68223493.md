---
kind: method
id: M:Autodesk.Revit.DB.Analysis.EnergyDataSettings.CheckProjectReportType(Autodesk.Revit.DB.Analysis.HVACLoadLoadsReportType)
source: html/a81fd0d4-13b2-1a7c-b1a1-e9290dc45336.htm
---
# Autodesk.Revit.DB.Analysis.EnergyDataSettings.CheckProjectReportType Method

Checks that the project report type falls within an appropriate range.

## Syntax (C#)
```csharp
public static bool CheckProjectReportType(
	HVACLoadLoadsReportType projectReportType
)
```

## Parameters
- **projectReportType** (`Autodesk.Revit.DB.Analysis.HVACLoadLoadsReportType`) - The project report type to be checked.

## Returns
True if the project report type falls within an appropriate range, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

