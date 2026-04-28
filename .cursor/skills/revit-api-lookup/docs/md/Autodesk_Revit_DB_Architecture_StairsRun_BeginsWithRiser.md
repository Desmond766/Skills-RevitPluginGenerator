---
kind: property
id: P:Autodesk.Revit.DB.Architecture.StairsRun.BeginsWithRiser
source: html/26a3216c-bafa-e8d3-a55d-1a3bf0a1f522.htm
---
# Autodesk.Revit.DB.Architecture.StairsRun.BeginsWithRiser Property

True if the stairs run begins with a riser, false otherwise.

## Syntax (C#)
```csharp
public bool BeginsWithRiser { get; set; }
```

## Remarks
If selected, Revit adds a riser to the beginning of the run.
 If you clear this option, Revit removes the beginning riser
 and positions the adjacent tread at the base elevation.
 Clearing this option will change the number of risers in the run.
 You will need to manually add a riser to maintain the original height.

