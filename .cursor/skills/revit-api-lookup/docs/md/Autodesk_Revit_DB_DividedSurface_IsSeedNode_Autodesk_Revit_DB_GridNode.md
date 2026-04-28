---
kind: method
id: M:Autodesk.Revit.DB.DividedSurface.IsSeedNode(Autodesk.Revit.DB.GridNode)
source: html/861a3148-b87c-315d-cde4-402428d5d470.htm
---
# Autodesk.Revit.DB.DividedSurface.IsSeedNode Method

Reports whether a grid node is a "seed node," a node
that is associated with one or more tiles.

## Syntax (C#)
```csharp
public bool IsSeedNode(
	GridNode gridNode
)
```

## Parameters
- **gridNode** (`Autodesk.Revit.DB.GridNode`)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - Thrown
when the grid node indexes are outside the range
[ 0, NumberOfUGridlines - 1 ], [ 0, NumberOfVGridlines - 1 ].

