---
kind: method
id: M:Autodesk.Revit.DB.DividedSurface.GetTileReference(Autodesk.Revit.DB.GridNode,System.Int32)
source: html/2ef73679-a240-0240-90c5-d08d2593de73.htm
---
# Autodesk.Revit.DB.DividedSurface.GetTileReference Method

Get a reference to one of the tile surfaces
associated with a given seed node.

## Syntax (C#)
```csharp
public Reference GetTileReference(
	GridNode gridNode,
	int tileIndex
)
```

## Parameters
- **gridNode** (`Autodesk.Revit.DB.GridNode`)
- **tileIndex** (`System.Int32`) - An integer between 0 and T-1,
where T is TilesPerSeedNode .

## Returns
A reference to a Face (surface). Returns Nothing nullptr a null reference ( Nothing in Visual Basic) 
if the grid node is not a "seed node", or
if the tile is omitted due to boundary conditions.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - Thrown if the grid node is outside of the range specified
by NumberOfUGridlines and NumberOfVGridlines,
or if tileIndex is outside the range [0, TilesPerSeedNode-1].

