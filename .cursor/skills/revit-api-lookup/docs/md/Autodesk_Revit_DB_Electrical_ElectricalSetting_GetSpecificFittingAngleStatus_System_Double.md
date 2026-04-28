---
kind: method
id: M:Autodesk.Revit.DB.Electrical.ElectricalSetting.GetSpecificFittingAngleStatus(System.Double)
source: html/0d6e6888-83d5-89fb-77ba-dfab13f2ca81.htm
---
# Autodesk.Revit.DB.Electrical.ElectricalSetting.GetSpecificFittingAngleStatus Method

Gets the status of given specific fitting angle.

## Syntax (C#)
```csharp
public bool GetSpecificFittingAngleStatus(
	double angle
)
```

## Parameters
- **angle** (`System.Double`) - The specific fitting angle (in degree) that must be one of 90, 60, 45, 30, 22.5 or 11.25 degrees.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given value for angle must be 90, 60, 45, 30, 22.5 or 11.25 degrees.

