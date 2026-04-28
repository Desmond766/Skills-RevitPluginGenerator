---
kind: property
id: P:Autodesk.Revit.DB.Extrusion.StartOffset
source: html/d60688d0-7a5f-4d36-7897-b1c590aafd3d.htm
---
# Autodesk.Revit.DB.Extrusion.StartOffset Property

The offset of the start of the extrusion relative to the sketch plane.

## Syntax (C#)
```csharp
public double StartOffset { get; set; }
```

## Remarks
The direction of the offset is based on the normal of the extrusion's sketch 
plane: a positive value is in the direction of the normal, a negative value is in the 
other direction.

