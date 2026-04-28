---
kind: method
id: M:Autodesk.Revit.DB.Electrical.PanelScheduleView.GetSpareLoadValue(System.Int32,System.Int32,Autodesk.Revit.DB.ElementId)
source: html/72f90a20-b987-e603-6f1a-2372d580b424.htm
---
# Autodesk.Revit.DB.Electrical.PanelScheduleView.GetSpareLoadValue Method

Gets the value of the apparent load parameter for a spare

## Syntax (C#)
```csharp
public double GetSpareLoadValue(
	int row,
	int column,
	ElementId idLoadParameter
)
```

## Parameters
- **row** (`System.Int32`) - A row where the valid spare is
- **column** (`System.Int32`) - A column where the valid spare is
- **idLoadParameter** (`Autodesk.Revit.DB.ElementId`) - One of 4 valid load parameters: RBS_ELEC_APPARENT_LOAD, RBS_ELEC_APPARENT_LOAD_PHASEA, RBS_ELEC_APPARENT_LOAD_PHASEB, RBS_ELEC_APPARENT_LOAD_PHASEC

## Returns
The value of the spare's load parameter

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The load parameter id is not valid.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentsInconsistentException** - The row column combination does not represent a valid spare.

