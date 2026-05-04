---
kind: method
id: M:Autodesk.Revit.DB.Analysis.EnergyDataSettings.CheckServiceType(Autodesk.Revit.DB.Analysis.gbXMLServiceType)
source: html/b6738580-e388-c47d-e678-562eddee4690.htm
---
# Autodesk.Revit.DB.Analysis.EnergyDataSettings.CheckServiceType Method

Checks that the service type falls within an appropriate range.

## Syntax (C#)
```csharp
public static bool CheckServiceType(
	gbXMLServiceType serviceType
)
```

## Parameters
- **serviceType** (`Autodesk.Revit.DB.Analysis.gbXMLServiceType`) - The service type to be checked.

## Returns
True if the service type falls within an appropriate range, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

