---
kind: method
id: M:Autodesk.Revit.DB.Mechanical.DuctSettings.GetSpecificFittingAngles
source: html/0f140871-90cc-03cb-81f7-0cc33a1b24bc.htm
---
# Autodesk.Revit.DB.Mechanical.DuctSettings.GetSpecificFittingAngles Method

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

