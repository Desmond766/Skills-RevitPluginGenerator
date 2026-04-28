---
kind: method
id: M:Autodesk.Revit.DB.CurveElement.IsAdjoinedCurveElement(System.Int32,Autodesk.Revit.DB.ElementId)
source: html/c72d52bd-4ca6-c3ea-1666-436d3f317456.htm
---
# Autodesk.Revit.DB.CurveElement.IsAdjoinedCurveElement Method

This method tests whether this and the given curve elements are joined at the given end.

## Syntax (C#)
```csharp
public bool IsAdjoinedCurveElement(
	int end,
	ElementId other
)
```

## Parameters
- **end** (`System.Int32`) - Index of one of the curve's end. Values '0' and '1' indicate the start or end point, respectively.
- **other** (`Autodesk.Revit.DB.ElementId`) - ElementId of another Curve Element from the same document.

## Returns
Returns True if the input curve element joins This curve element at the given end-point; returns False otherwise.

## Remarks
The input end is relative to this curve element.
 The other curve element can be joined at any of its end-points.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given Id does not represent any of the two end-points of a curve element.
 A valid value of either '0' or '1' is expected.
 -or-
 The given ElementId (%elementId) is not of a valid Curve Element.
 A valid Curve Element must be in the same document and must be
 diferent than this curve elements self.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

