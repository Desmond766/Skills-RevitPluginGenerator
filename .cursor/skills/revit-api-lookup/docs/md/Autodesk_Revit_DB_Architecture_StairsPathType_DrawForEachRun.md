---
kind: property
id: P:Autodesk.Revit.DB.Architecture.StairsPathType.DrawForEachRun
source: html/f6dcd6ab-6f15-e30c-f6f5-ab8abbe4606c.htm
---
# Autodesk.Revit.DB.Architecture.StairsPathType.DrawForEachRun Property

True if stairs paths should be drawn for each run, false if it should be drawn for the whole stairs.

## Syntax (C#)
```csharp
public bool DrawForEachRun { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: The StairsPathType is not fixed up direction so the data being set is not applicable.

