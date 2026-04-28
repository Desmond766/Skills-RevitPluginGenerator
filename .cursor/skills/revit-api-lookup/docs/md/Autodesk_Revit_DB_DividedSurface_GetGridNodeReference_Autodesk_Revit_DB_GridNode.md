---
kind: method
id: M:Autodesk.Revit.DB.DividedSurface.GetGridNodeReference(Autodesk.Revit.DB.GridNode)
source: html/62738bc9-7201-894a-20bc-954e106b2061.htm
---
# Autodesk.Revit.DB.DividedSurface.GetGridNodeReference Method

Get a reference to the geometric point
associated with a grid node.

## Syntax (C#)
```csharp
public Reference GetGridNodeReference(
	GridNode gridNode
)
```

## Parameters
- **gridNode** (`Autodesk.Revit.DB.GridNode`)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - Thrown
when the grid node indexes are outside the range
[ 0, NumberOfUGridlines - 1 ], [ 0, NumberOfVGridlines - 1 ].

