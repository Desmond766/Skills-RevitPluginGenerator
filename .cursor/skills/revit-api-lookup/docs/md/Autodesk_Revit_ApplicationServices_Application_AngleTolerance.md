---
kind: property
id: P:Autodesk.Revit.ApplicationServices.Application.AngleTolerance
source: html/132bbed4-856d-6271-ff13-0f4a7fc84c00.htm
---
# Autodesk.Revit.ApplicationServices.Application.AngleTolerance Property

Angle tolerance.

## Syntax (C#)
```csharp
public double AngleTolerance { get; }
```

## Remarks
Value is in radians.
 Two angle measurements closer than this value are considered identical.
 Do not use this value for any purpose other than its intended purpose,
 which is to check if two angles are the same within this tolerance value.
 Do not use this value to set the value of an angle.
 Doing so will result in unstable behavior.

