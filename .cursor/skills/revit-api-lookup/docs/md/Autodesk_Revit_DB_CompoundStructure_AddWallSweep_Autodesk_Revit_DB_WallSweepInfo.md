---
kind: method
id: M:Autodesk.Revit.DB.CompoundStructure.AddWallSweep(Autodesk.Revit.DB.WallSweepInfo)
source: html/3f95013f-ae34-e068-96b5-a930fb26d2a5.htm
---
# Autodesk.Revit.DB.CompoundStructure.AddWallSweep Method

Adds a new wall sweep or reveal to the compound structure.

## Syntax (C#)
```csharp
public void AddWallSweep(
	WallSweepInfo wallSweepInfo
)
```

## Parameters
- **wallSweepInfo** (`Autodesk.Revit.DB.WallSweepInfo`) - The wall sweep info to create a wall sweep.

## Remarks
A wall sweep is an object that is created by sweeping a closed 2d profile along a horizontal line
 that is positioned on one side (exterior or interior) of the hosting wall.
 A reveal is a special wall sweep with a void shape that is subtracted from the hosting wall. The id field of the WallSweepInfo must be populated with a non-negative integer value.
 If there already is a sweep defined for this id, its parameters will be changed.
 A new sweep will be created if no existing one has matching id.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The wall sweep info does not represent a fixed wall sweep. Only fixed wall sweeps may be assigned to vertical compound structures.
 -or-
 The WallSweepInfo has an invalid id for a fixed wall sweep.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This operation is valid only for vertically compound structures.

