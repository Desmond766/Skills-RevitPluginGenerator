---
kind: property
id: P:Autodesk.Revit.DB.LocationCurve.ElementsAtJoin(System.Int32)
source: html/ddb745bd-7bf5-1e2d-6166-1dffa8427565.htm
---
# Autodesk.Revit.DB.LocationCurve.ElementsAtJoin Property

Get all elements joining to the end of this element's location curve or change the order of elements participation in the end join with this location curve's end.

## Syntax (C#)
```csharp
public ElementArray this[
	int end
] { get; set; }
```

## Parameters
- **end** (`System.Int32`) - The end at which the join occurs.

## Remarks
The list of elements is expected to be a permutation of the elements already in the join at the end.
It is expected that no new elements will be introduced, and existing ones will not be removed.

