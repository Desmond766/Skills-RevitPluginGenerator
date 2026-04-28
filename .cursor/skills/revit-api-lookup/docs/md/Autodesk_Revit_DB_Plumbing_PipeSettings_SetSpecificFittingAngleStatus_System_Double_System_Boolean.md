---
kind: method
id: M:Autodesk.Revit.DB.Plumbing.PipeSettings.SetSpecificFittingAngleStatus(System.Double,System.Boolean)
source: html/fe684616-5a84-6984-d731-b9efe21367ed.htm
---
# Autodesk.Revit.DB.Plumbing.PipeSettings.SetSpecificFittingAngleStatus Method

Sets the status of given specific angle.

## Syntax (C#)
```csharp
public void SetSpecificFittingAngleStatus(
	double angle,
	bool bStatus
)
```

## Parameters
- **angle** (`System.Double`) - The specific angle (in degree) that must be one of 60, 45, 30, 22.5 or 11.25 degrees.
- **bStatus** (`System.Boolean`) - Status, true - using the given angle during the pipe layout.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given value for angle must be 90, 60, 45, 30, 22.5 or 11.25 degrees.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Can not set an angle status for an invalid angle.

