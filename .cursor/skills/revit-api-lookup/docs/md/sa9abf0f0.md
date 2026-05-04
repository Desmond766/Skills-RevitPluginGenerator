---
kind: method
id: M:Autodesk.Revit.DB.Structure.AnalyticalMember.SetCurve(Autodesk.Revit.DB.Curve)
source: html/a1808afa-ba67-381b-ea28-4e8b2d9e5516.htm
---
# Autodesk.Revit.DB.Structure.AnalyticalMember.SetCurve Method

Sets the curve for the Analytical Member.

## Syntax (C#)
```csharp
public void SetCurve(
	Curve curve
)
```

## Parameters
- **curve** (`Autodesk.Revit.DB.Curve`)

## Remarks
End nodes connection will be lost if the curve changes position.
 The curve must be bounded.
 The curve can be:
 Line Arc Ellipse

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input curve is not bound.
 -or-
 The provided curve is not supported.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

