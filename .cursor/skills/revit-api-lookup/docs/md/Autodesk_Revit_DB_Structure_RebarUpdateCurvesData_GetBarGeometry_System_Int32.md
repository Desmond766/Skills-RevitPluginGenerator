---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarUpdateCurvesData.GetBarGeometry(System.Int32)
source: html/fdbf4cd8-3066-2768-d94d-d8ebfb92009f.htm
---
# Autodesk.Revit.DB.Structure.RebarUpdateCurvesData.GetBarGeometry Method

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

