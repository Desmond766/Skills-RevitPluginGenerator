---
kind: method
id: M:Autodesk.Revit.DB.SweptProfile.GetDrivingCurve
source: html/f77a5f4f-92ca-5224-6894-f62be990ce24.htm
---
# Autodesk.Revit.DB.SweptProfile.GetDrivingCurve Method

Provides access to the curve that dictates the path of the swept profile.

## Syntax (C#)
```csharp
public Curve GetDrivingCurve()
```

## Returns
A curve that defines the path of the swept profile.

## Remarks
The profile may not be swept the entire length of this curve. One should check the
 set back properties on this object to locate how far the actual sweep is from the ends of the curve.

