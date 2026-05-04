---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarTrimExtendData.GetAddedBarGeometry(System.Int32)
source: html/64c06ae1-86b7-4e86-94df-2a6d99084a11.htm
---
# Autodesk.Revit.DB.Structure.RebarTrimExtendData.GetAddedBarGeometry Method

Gets the added curves that will represent the bar at index barIndex.

## Syntax (C#)
```csharp
public IList<Curve> GetAddedBarGeometry(
	int barIndex
)
```

## Parameters
- **barIndex** (`System.Int32`) - The index of the bar. Should be a number between 0 and GetNumberOfBarGeometry() - 1.

## Returns
Returns the curves that will represent the bar at index barIndex. The hooks plane normals will be applied on these curves.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - barIndex is not in the range [ 0, GetNumberOfBarGeometry()-1 ].

