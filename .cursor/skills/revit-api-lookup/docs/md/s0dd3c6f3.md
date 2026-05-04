---
kind: method
id: M:Autodesk.Revit.DB.CompoundStructure.GetWidth
source: html/fcd2ffc8-05bc-5d3c-f4e2-b62d5a3376ce.htm
---
# Autodesk.Revit.DB.CompoundStructure.GetWidth Method

The width implied by this compound structure.

## Syntax (C#)
```csharp
public double GetWidth()
```

## Returns
The width of a host object with this compound structure.

## Remarks
If the structure is not vertically compound, then
 this is simply the sum of all layers' widths. If the structure is vertically compound,
 this is the width of the rectangular grid stored in the vertically compound structure.
 The presence of a layer with variable width has no effect on the value returned by this method. The
 value returned assumes that all layers have their specified width.

