---
kind: property
id: P:Autodesk.Revit.DB.Architecture.StairsPathType.LineShapeAtCorner
source: html/8b7246ac-dfdb-da83-1c17-ebe4c9584828.htm
---
# Autodesk.Revit.DB.Architecture.StairsPathType.LineShapeAtCorner Property

The line shape of stairs path at the corner.

## Syntax (C#)
```csharp
public StairsPathLineShapeAtCorner LineShapeAtCorner { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: Either the stairs path direction is not AutomaticUpDown, or it is AlwaysUp but DrawForEachRun is false.

