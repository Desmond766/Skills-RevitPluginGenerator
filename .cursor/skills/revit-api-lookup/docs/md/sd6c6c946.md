---
kind: method
id: M:Autodesk.Revit.DB.Plumbing.PipeSettings.AddPipeSlope(System.Double)
source: html/8ae86cd1-edbe-be80-e8bc-eb7cbbb573d5.htm
---
# Autodesk.Revit.DB.Plumbing.PipeSettings.AddPipeSlope Method

Add a pipe slope value.

## Syntax (C#)
```csharp
public void AddPipeSlope(
	double slope
)
```

## Parameters
- **slope** (`System.Double`) - The pipe slope value. Revit stores the slope value as a percentage (0-100).

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given value for slope must be between 0 and 100. Slope value is stored in percentage. e.g. 100 means 100%, and it is 45 degree.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Can not add a pipe slope value that was already added.

