---
kind: method
id: M:Autodesk.Revit.DB.Electrical.PanelScheduleView.SetSpareLoadValue(System.Int32,System.Int32,Autodesk.Revit.DB.ElementId,System.Double)
source: html/ebe7e739-a294-5fdd-123b-fc7e185c671d.htm
---
# Autodesk.Revit.DB.Electrical.PanelScheduleView.SetSpareLoadValue Method

Sets the value of the apparent load parameter for a spare

## Syntax (C#)
```csharp
public void SetSpareLoadValue(
	int row,
	int column,
	ElementId idLoadParameter,
	double value
)
```

## Parameters
- **row** (`System.Int32`) - A row where the valid spare is
- **column** (`System.Int32`) - A column where the valid spare is
- **idLoadParameter** (`Autodesk.Revit.DB.ElementId`) - One of 4 valid load parameters: RBS_ELEC_APPARENT_LOAD, RBS_ELEC_APPARENT_LOAD_PHASEA, RBS_ELEC_APPARENT_LOAD_PHASEB, RBS_ELEC_APPARENT_LOAD_PHASEC
- **value** (`System.Double`) - The value of the spare's load for the given parameter

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The load parameter id is not valid.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given value for value must be non-negative.
- **Autodesk.Revit.Exceptions.ArgumentsInconsistentException** - The row column combination does not represent a valid spare.

