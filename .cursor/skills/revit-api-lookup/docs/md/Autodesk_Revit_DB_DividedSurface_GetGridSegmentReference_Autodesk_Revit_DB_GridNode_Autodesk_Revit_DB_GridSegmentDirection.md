---
kind: method
id: M:Autodesk.Revit.DB.DividedSurface.GetGridSegmentReference(Autodesk.Revit.DB.GridNode,Autodesk.Revit.DB.GridSegmentDirection)
source: html/ac22065a-c06b-a610-8274-b7e9f6e6dacd.htm
---
# Autodesk.Revit.DB.DividedSurface.GetGridSegmentReference Method

Get a reference to a line segment connecting
two adjacent grid nodes.

## Syntax (C#)
```csharp
public Reference GetGridSegmentReference(
	GridNode gridNode,
	GridSegmentDirection gridSegmentDirection
)
```

## Parameters
- **gridNode** (`Autodesk.Revit.DB.GridNode`)
- **gridSegmentDirection** (`Autodesk.Revit.DB.GridSegmentDirection`)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - Thrown
when the grid node indexes are outside the range
[ 0, NumberOfUGridlines - 1 ], [ 0, NumberOfVGridlines - 1 ],
or when the adjacent grid node specified by
gridSegmentDirection is out of range.

