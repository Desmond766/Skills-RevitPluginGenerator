---
kind: method
id: M:Autodesk.Revit.DB.CurveElement.GetTangentLock(System.Int32,Autodesk.Revit.DB.ElementId)
source: html/7544e419-0805-5c12-8c12-9599e1b16065.htm
---
# Autodesk.Revit.DB.CurveElement.GetTangentLock Method

Returns the state of a tangent join between this and another curve element at the given end-point.

## Syntax (C#)
```csharp
public bool GetTangentLock(
	int end,
	ElementId other
)
```

## Parameters
- **end** (`System.Int32`) - Index of one of the curve's end. Values '0' and '1' indicate the start or end point, respectively.
- **other** (`Autodesk.Revit.DB.ElementId`) - ElementId of another Curve Element from the same document.

## Returns
Returns True if this curve element has a tangent joint with the other input element and the join is curently locked; returns False otherwise.

## Remarks
The return value indicates whether there is such tangent join and if it is currently locked.
 A negative value indicates that there either is no tangent join with the other element
 at the given end-point, or the join between those two curve element is not currently locked.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given Id does not represent any of the two end-points of a curve element.
 A valid value of either '0' or '1' is expected.
 -or-
 The given ElementId (%elementId) is not of a valid Curve Element.
 A valid Curve Element must be in the same document and must be
 diferent than this curve elements self.
 -or-
 This element has no tangent join with the input element at the given end-point.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

