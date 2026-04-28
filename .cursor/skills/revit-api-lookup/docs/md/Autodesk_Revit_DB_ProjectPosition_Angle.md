---
kind: property
id: P:Autodesk.Revit.DB.ProjectPosition.Angle
source: html/c8cf6834-f84c-fa2e-4249-276a7f510f2f.htm
---
# Autodesk.Revit.DB.ProjectPosition.Angle Property

Angle from True North.

## Syntax (C#)
```csharp
public double Angle { get; set; }
```

## Remarks
This is the angle difference between project north and true north measured in
 radians. It can have a value from -PI to PI.
 If the parameter value is outside that range, it
 will be shifted by 2*PI until it falls into range.

