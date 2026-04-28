---
kind: method
id: M:Autodesk.Revit.DB.Mechanical.DuctSettings.GetSpecificFittingAngleStatus(System.Double)
source: html/3d357c63-7ac9-01d1-7468-ebd4a3bf998a.htm
---
# Autodesk.Revit.DB.Mechanical.DuctSettings.GetSpecificFittingAngleStatus Method

Gets the status of given specific angle.

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

