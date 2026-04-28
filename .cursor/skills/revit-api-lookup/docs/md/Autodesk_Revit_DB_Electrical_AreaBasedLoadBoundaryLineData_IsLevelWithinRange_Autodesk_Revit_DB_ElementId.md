---
kind: method
id: M:Autodesk.Revit.DB.Electrical.AreaBasedLoadBoundaryLineData.IsLevelWithinRange(Autodesk.Revit.DB.ElementId)
source: html/b32cd564-681a-c6c6-4c74-cc708b3d31c4.htm
---
# Autodesk.Revit.DB.Electrical.AreaBasedLoadBoundaryLineData.IsLevelWithinRange Method

Checks whether the given level is between the bottom level and the top level (including
 the bottom level and the top level) of the area based load boundary line.

## Syntax (C#)
```csharp
public bool IsLevelWithinRange(
	ElementId levelId
)
```

## Parameters
- **levelId** (`Autodesk.Revit.DB.ElementId`) - The id of the Level.

## Returns
True if given level is between the bottom level and the top level, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The ElementId levelId is not a Level.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

