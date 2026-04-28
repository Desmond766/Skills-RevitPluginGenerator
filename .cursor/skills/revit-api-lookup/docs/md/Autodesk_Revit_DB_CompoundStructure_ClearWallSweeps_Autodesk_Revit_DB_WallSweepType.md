---
kind: method
id: M:Autodesk.Revit.DB.CompoundStructure.ClearWallSweeps(Autodesk.Revit.DB.WallSweepType)
source: html/afc7fce6-66db-aa6f-6afe-85dd4bf2578b.htm
---
# Autodesk.Revit.DB.CompoundStructure.ClearWallSweeps Method

Removes all sweeps or reveals from the compound structure.

## Syntax (C#)
```csharp
public void ClearWallSweeps(
	WallSweepType wallSweepType
)
```

## Parameters
- **wallSweepType** (`Autodesk.Revit.DB.WallSweepType`) - The type of a wall sweep.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This operation is valid only for vertically compound structures.

