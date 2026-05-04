---
kind: method
id: M:Autodesk.Revit.DB.MultiSegmentGrid.AreGridsInSameMultiSegmentGrid(Autodesk.Revit.DB.Grid,Autodesk.Revit.DB.Grid)
source: html/742243de-2773-a7c5-7b6d-ee4ce3b4b7d1.htm
---
# Autodesk.Revit.DB.MultiSegmentGrid.AreGridsInSameMultiSegmentGrid Method

Determine whether two Grids are members of the same GridChain.

## Syntax (C#)
```csharp
public static bool AreGridsInSameMultiSegmentGrid(
	Grid grid1,
	Grid grid2
)
```

## Parameters
- **grid1** (`Autodesk.Revit.DB.Grid`) - A Grid.
- **grid2** (`Autodesk.Revit.DB.Grid`) - A Grid.

## Returns
Returns true if both of the specified Grids are associated to the same MultiSegmentGrid,
 i.e. getMultiSegementGridId returns the same valid element id for both Grids.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

