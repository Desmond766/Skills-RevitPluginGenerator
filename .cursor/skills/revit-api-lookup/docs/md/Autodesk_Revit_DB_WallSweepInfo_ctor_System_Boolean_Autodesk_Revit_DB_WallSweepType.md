---
kind: method
id: M:Autodesk.Revit.DB.WallSweepInfo.#ctor(System.Boolean,Autodesk.Revit.DB.WallSweepType)
source: html/e64c66c8-a851-3062-feae-c969bb3d51d1.htm
---
# Autodesk.Revit.DB.WallSweepInfo.#ctor Method

Constructs a new WallSweepInfo instance.

## Syntax (C#)
```csharp
public WallSweepInfo(
	bool fixed,
	WallSweepType type
)
```

## Parameters
- **fixed** (`System.Boolean`) - True if the WallSweepInfo should be fixed (suitable for use in CompoundStructure.AddWallSweep()).
 False if the WallSweepInfo should be suitable for use in standalone wall sweep or reveal elements.
- **type** (`Autodesk.Revit.DB.WallSweepType`) - The type of the WallSweepInfo instance.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

