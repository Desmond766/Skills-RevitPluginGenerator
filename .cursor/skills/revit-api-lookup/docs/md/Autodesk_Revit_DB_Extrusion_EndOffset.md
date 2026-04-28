---
kind: property
id: P:Autodesk.Revit.DB.Extrusion.EndOffset
source: html/70118c6f-c3da-5492-86b2-892d852b8c2d.htm
---
# Autodesk.Revit.DB.Extrusion.EndOffset Property

The offset of the end of the extrusion relative to the sketch plane.

## Syntax (C#)
```csharp
public double EndOffset { get; set; }
```

## Remarks
The direction of the offset is based on the normal of the extrusion's sketch 
plane: a positive value is in the direction of the normal, a negative value is in the 
other direction.

