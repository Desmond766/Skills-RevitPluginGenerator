---
kind: method
id: M:Autodesk.Revit.DB.CompoundStructure.GetWallSweepsInfo(Autodesk.Revit.DB.WallSweepType)
source: html/f8140797-a9ac-234b-cb54-5a1c56ce45bf.htm
---
# Autodesk.Revit.DB.CompoundStructure.GetWallSweepsInfo Method

Obtains a list of the intrinsic wall sweeps or reveals in this CompoundStructure.

## Syntax (C#)
```csharp
public IList<WallSweepInfo> GetWallSweepsInfo(
	WallSweepType wallSweepType
)
```

## Parameters
- **wallSweepType** (`Autodesk.Revit.DB.WallSweepType`) - Whether to obtain wall sweeps or reveals.

## Returns
An array which describes the intrinsic wall sweeps or reveals.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

