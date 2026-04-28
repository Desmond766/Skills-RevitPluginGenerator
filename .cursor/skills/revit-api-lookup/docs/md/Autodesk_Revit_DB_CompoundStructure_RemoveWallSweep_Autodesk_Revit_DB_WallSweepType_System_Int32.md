---
kind: method
id: M:Autodesk.Revit.DB.CompoundStructure.RemoveWallSweep(Autodesk.Revit.DB.WallSweepType,System.Int32)
source: html/e3f2b69a-e4ea-5781-8285-6c2e183933a8.htm
---
# Autodesk.Revit.DB.CompoundStructure.RemoveWallSweep Method

Removes a single sweep or reveal from the compound structure.

## Syntax (C#)
```csharp
public void RemoveWallSweep(
	WallSweepType wallSweepType,
	int id
)
```

## Parameters
- **wallSweepType** (`Autodesk.Revit.DB.WallSweepType`) - The type of a wall sweep.
- **id** (`System.Int32`) - The id of the sweep or reveal to remove.

## Remarks
No validation of input arguments is performed. If no reveal or sweep
 has the specified id, no action is performed.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This operation is valid only for vertically compound structures.

