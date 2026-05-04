---
kind: property
id: P:Autodesk.Revit.DB.Architecture.StairsRun.EndsWithRiser
source: html/e41f2154-eb17-c301-592a-30e35c982e67.htm
---
# Autodesk.Revit.DB.Architecture.StairsRun.EndsWithRiser Property

True if the stairs run ends with a riser, false otherwise.

## Syntax (C#)
```csharp
public bool EndsWithRiser { get; set; }
```

## Remarks
If selected, Revit adds a riser to the end of the run.
 Clearing this option will change the number of risers in the run.
 You will need to manually add or remove risers to maintain the original height.

