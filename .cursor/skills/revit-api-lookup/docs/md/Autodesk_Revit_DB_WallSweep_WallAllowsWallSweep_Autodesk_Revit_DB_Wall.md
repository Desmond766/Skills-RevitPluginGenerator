---
kind: method
id: M:Autodesk.Revit.DB.WallSweep.WallAllowsWallSweep(Autodesk.Revit.DB.Wall)
source: html/cf1d6b0c-e109-3571-e2d3-ae55d35c0d48.htm
---
# Autodesk.Revit.DB.WallSweep.WallAllowsWallSweep Method

Validates that the wall is of a type that may be a host for a wall sweep or reveal.

## Syntax (C#)
```csharp
public static bool WallAllowsWallSweep(
	Wall wall
)
```

## Parameters
- **wall** (`Autodesk.Revit.DB.Wall`) - The wall.

## Returns
True if the wall may host a wall sweep, false otherwise.

## Remarks
This function excludes curtain walls and the main wall of a set of stacked walls.
 The wall must be fully regenerated for this function to work correctly.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

