---
kind: method
id: M:Autodesk.Revit.DB.Plumbing.PipeSettings.GetSpecificFittingAngleStatus(System.Double)
source: html/251d69ee-91fa-38fe-3868-35b82f1866de.htm
---
# Autodesk.Revit.DB.Plumbing.PipeSettings.GetSpecificFittingAngleStatus Method

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

