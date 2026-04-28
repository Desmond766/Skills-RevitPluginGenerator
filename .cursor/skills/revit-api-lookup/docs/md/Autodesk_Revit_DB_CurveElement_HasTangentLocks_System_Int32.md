---
kind: method
id: M:Autodesk.Revit.DB.CurveElement.HasTangentLocks(System.Int32)
source: html/1be690bc-28ee-5d33-b253-7835c35cb158.htm
---
# Autodesk.Revit.DB.CurveElement.HasTangentLocks Method

Tests whether this curve element has any locked tangent joins at the given end-point.

## Syntax (C#)
```csharp
public bool HasTangentLocks(
	int end
)
```

## Parameters
- **end** (`System.Int32`) - Index of one of the curve's end. Values '0' and '1' indicate the start or end point, respectively.

## Returns
Returns True if the curve element is tangentially locked to at least one other curve element at the given end-point; returns False otherwise.

## Remarks
Note that tangent locks between two elements at their joined ends are always kept in
 sync with each other. It means that if one curve element is locked to another curve,
 the other curve will be automatically locked to the first curve at the shared join.

