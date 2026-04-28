---
kind: method
id: M:Autodesk.Revit.DB.DividedSurface.GetGridNodeUV(Autodesk.Revit.DB.GridNode)
source: html/30c8cf73-bcc3-5241-b48f-ab5c7be834e8.htm
---
# Autodesk.Revit.DB.DividedSurface.GetGridNodeUV Method

Get the position of a grid node in UV
coordinates in the surface.

## Syntax (C#)
```csharp
public UV GetGridNodeUV(
	GridNode gridNode
)
```

## Parameters
- **gridNode** (`Autodesk.Revit.DB.GridNode`)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - Thrown
when the grid node indexes are outside the range
[ 0, NumberOfUGridlines - 1 ], [ 0, NumberOfVGridlines - 1 ].

