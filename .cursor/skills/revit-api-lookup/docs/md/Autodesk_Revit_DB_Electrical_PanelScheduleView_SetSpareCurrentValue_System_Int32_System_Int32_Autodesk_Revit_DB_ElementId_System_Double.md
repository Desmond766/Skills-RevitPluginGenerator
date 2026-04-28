---
kind: method
id: M:Autodesk.Revit.DB.Electrical.PanelScheduleView.SetSpareCurrentValue(System.Int32,System.Int32,Autodesk.Revit.DB.ElementId,System.Double)
source: html/8143eec6-4300-4eaf-f730-6ae19ec621c1.htm
---
# Autodesk.Revit.DB.Electrical.PanelScheduleView.SetSpareCurrentValue Method

Sets the value of the apparent current parameter for a spare

## Syntax (C#)
```csharp
public void SetSpareCurrentValue(
	int row,
	int column,
	ElementId idCurrentParameter,
	double value
)
```

## Parameters
- **row** (`System.Int32`) - A row where the valid spare is
- **column** (`System.Int32`) - A column where the valid spare is
- **idCurrentParameter** (`Autodesk.Revit.DB.ElementId`) - One of 4 valid current parameters: RBS_ELEC_APPARENT_CURRENT_PARAM, RBS_ELEC_APPARENT_CURRENT_PHASEA_PARAM, RBS_ELEC_APPARENT_CURRENT_PHASEB_PARAM, RBS_ELEC_APPARENT_CURRENT_PHASEC_PARAM
- **value** (`System.Double`) - The value of the spare's current for the given parameter

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The current parameter id is not valid.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given value for value must be non-negative.
- **Autodesk.Revit.Exceptions.ArgumentsInconsistentException** - The row column combination does not represent a valid spare.

