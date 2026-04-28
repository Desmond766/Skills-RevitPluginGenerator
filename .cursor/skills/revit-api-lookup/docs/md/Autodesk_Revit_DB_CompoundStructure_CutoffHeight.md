---
kind: property
id: P:Autodesk.Revit.DB.CompoundStructure.CutoffHeight
source: html/50227765-fb72-587a-38aa-0559877a790f.htm
---
# Autodesk.Revit.DB.CompoundStructure.CutoffHeight Property

Horizontal segments below or at the cutoff height have their distance to the wall bottom fixed, those above
 have their distance to the wall top fixed.

## Syntax (C#)
```csharp
public double CutoffHeight { get; set; }
```

## Remarks
This allows layers with one horizontal segment above and one below
 this line to be of variable height.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This operation is valid only for vertically compound structures.

