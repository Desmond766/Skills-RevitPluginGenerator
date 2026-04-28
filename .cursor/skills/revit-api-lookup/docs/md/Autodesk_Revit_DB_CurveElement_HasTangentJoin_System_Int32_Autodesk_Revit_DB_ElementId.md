---
kind: method
id: M:Autodesk.Revit.DB.CurveElement.HasTangentJoin(System.Int32,Autodesk.Revit.DB.ElementId)
source: html/a7b2da39-2bab-5cea-5441-eb3ad476a81f.htm
---
# Autodesk.Revit.DB.CurveElement.HasTangentJoin Method

Tests whether this curve element and the input curve element have common tangent join at the given end-point.

## Syntax (C#)
```csharp
public bool HasTangentJoin(
	int end,
	ElementId other
)
```

## Parameters
- **end** (`System.Int32`) - Index of one of the curve's end. Values '0' and '1' indicate the start or end point, respectively.
- **other** (`Autodesk.Revit.DB.ElementId`) - ElementId of another Curve Element from the same document.

## Returns
Returns True if the two curve elements have a tangent join at the given end-point.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

