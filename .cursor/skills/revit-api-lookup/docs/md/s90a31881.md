---
kind: method
id: M:Autodesk.Revit.DB.ConicalSurface.IsValidConeAngle(System.Double)
source: html/33f4d39f-a8b1-ef85-d423-fdc5044b8253.htm
---
# Autodesk.Revit.DB.ConicalSurface.IsValidConeAngle Method

Checks whether the input value lies is not 0, greater than -PI/2 and lesser than PI/2.

## Syntax (C#)
```csharp
public static bool IsValidConeAngle(
	double halfAngle
)
```

## Parameters
- **halfAngle** (`System.Double`) - Cone half-angle parameter.

## Returns
True if input is not 0, lesser than PI/2 and greater than -PI/2, false otherwise.

