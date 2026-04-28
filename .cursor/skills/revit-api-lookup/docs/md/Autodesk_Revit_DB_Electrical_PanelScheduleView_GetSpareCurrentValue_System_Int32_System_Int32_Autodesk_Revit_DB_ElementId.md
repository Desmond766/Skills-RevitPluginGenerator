---
kind: method
id: M:Autodesk.Revit.DB.Electrical.PanelScheduleView.GetSpareCurrentValue(System.Int32,System.Int32,Autodesk.Revit.DB.ElementId)
source: html/89265725-fb79-a0ad-4c70-a9d178104f6d.htm
---
# Autodesk.Revit.DB.Electrical.PanelScheduleView.GetSpareCurrentValue Method

Gets the value of the apparent current parameter for a spare

## Syntax (C#)
```csharp
public double GetSpareCurrentValue(
	int row,
	int column,
	ElementId idCurrentParameter
)
```

## Parameters
- **row** (`System.Int32`) - A row where the valid spare is
- **column** (`System.Int32`) - A column where the valid spare is
- **idCurrentParameter** (`Autodesk.Revit.DB.ElementId`) - One of 4 valid current parameters: RBS_ELEC_APPARENT_CURRENT_PARAM, RBS_ELEC_APPARENT_CURRENT_PHASEA_PARAM, RBS_ELEC_APPARENT_CURRENT_PHASEB_PARAM, RBS_ELEC_APPARENT_CURRENT_PHASEC_PARAM

## Returns
The value of the spare's current parameter

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The current parameter id is not valid.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentsInconsistentException** - The row column combination does not represent a valid spare.

