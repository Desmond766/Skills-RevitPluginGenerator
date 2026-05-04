---
kind: method
id: M:Autodesk.Revit.DB.DividedSurface.GetGridNodeLocation(Autodesk.Revit.DB.GridNode)
source: html/688f7190-8b0f-e7f0-f9a6-2dc9298efc2a.htm
---
# Autodesk.Revit.DB.DividedSurface.GetGridNodeLocation Method

Specify whether a particular grid node is 
interior to the surface, on the boundary, or outside
the boundary.

## Syntax (C#)
```csharp
public GridNodeLocation GetGridNodeLocation(
	GridNode gridNode
)
```

## Parameters
- **gridNode** (`Autodesk.Revit.DB.GridNode`)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - Thrown
when the grid node indexes are outside the range
[ 0, NumberOfUGridlines - 1 ], [ 0, NumberOfVGridlines - 1 ].

