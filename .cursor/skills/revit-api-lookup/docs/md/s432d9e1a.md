---
kind: method
id: M:Autodesk.Revit.DB.DividedSurface.GetTileFamilyInstance(Autodesk.Revit.DB.GridNode,System.Int32)
source: html/173b76c6-254c-a9a3-83de-b7384e1ecae7.htm
---
# Autodesk.Revit.DB.DividedSurface.GetTileFamilyInstance Method

Get a reference to a tile element
associated with a given seed node.

## Syntax (C#)
```csharp
public FamilyInstance GetTileFamilyInstance(
	GridNode gridNode,
	int tileIndex
)
```

## Parameters
- **gridNode** (`Autodesk.Revit.DB.GridNode`)
- **tileIndex** (`System.Int32`)

## Returns
A FamilyInstance object. Returns Nothing nullptr a null reference ( Nothing in Visual Basic) if
the ObjectType property is not a FamilySymbol.
Returns Nothing nullptr a null reference ( Nothing in Visual Basic) 
if the grid node is not a "seed node", or
if the tile is omitted due to boundary conditions.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - Thrown if the grid node is outside of the range specified
by NumberOfUGridlines and NumberOfVGridlines,
or if tileIndex is outside the range [0, TilesPerSeedNode-1].

