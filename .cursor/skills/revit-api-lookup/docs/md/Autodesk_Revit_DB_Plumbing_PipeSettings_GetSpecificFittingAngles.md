---
kind: method
id: M:Autodesk.Revit.DB.Plumbing.PipeSettings.GetSpecificFittingAngles
source: html/be4b50bb-22ce-550e-babf-573de87a344e.htm
---
# Autodesk.Revit.DB.Plumbing.PipeSettings.GetSpecificFittingAngles Method

Gets the list of specific fitting angles.

## Syntax (C#)
```csharp
public IList<double> GetSpecificFittingAngles()
```

## Returns
Angles (in degrees).

## Remarks
Revit will only use the angles specified during the pipe layout or modifying the pipe layout.
 When laying out the pipes, if the angle between two pipes is close to the allowed angle,
 the specific angle is used for that pipe fitting.

