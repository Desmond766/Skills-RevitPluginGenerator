---
kind: method
id: M:Autodesk.Revit.DB.WallSweepInfo.#ctor(Autodesk.Revit.DB.WallSweepType,System.Boolean)
source: html/88df87e1-8312-cfc8-d00e-d53bd406277b.htm
---
# Autodesk.Revit.DB.WallSweepInfo.#ctor Method

Constructs a new WallSweepInfo instance.

## Syntax (C#)
```csharp
public WallSweepInfo(
	WallSweepType type,
	bool vertical
)
```

## Parameters
- **type** (`Autodesk.Revit.DB.WallSweepType`) - The type of the WallSweepInfo instance.
- **vertical** (`System.Boolean`) - True to construct a vertical wall sweep, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

