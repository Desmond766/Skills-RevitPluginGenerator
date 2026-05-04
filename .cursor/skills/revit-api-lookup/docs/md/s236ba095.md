---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarHandlePositionData.GetBarGeometry(System.Int32)
source: html/9486bba5-4657-637c-41e9-7337ca8e6a7c.htm
---
# Autodesk.Revit.DB.Structure.RebarHandlePositionData.GetBarGeometry Method

Returns the geometry for a bar at the specified index currently in the Rebar.

## Syntax (C#)
```csharp
public IList<Curve> GetBarGeometry(
	int barIndex
)
```

## Parameters
- **barIndex** (`System.Int32`) - The index of the bar. Should be a number between 0 and GetNumberOfBars() - 1.

## Returns
Returns an array of curves that defines the bar at the specified index.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - barIndex is not in the range [ 0, GetNumberOfBars()-1 ].

