---
kind: method
id: M:Autodesk.Revit.DB.CompoundStructure.IsVerticallyHomogeneous
source: html/7f06ea80-ba2f-aecb-be51-cb463769ae1b.htm
---
# Autodesk.Revit.DB.CompoundStructure.IsVerticallyHomogeneous Method

Indicates whether this CompoundStructure represents a single set of parallel layers.

## Syntax (C#)
```csharp
public bool IsVerticallyHomogeneous()
```

## Returns
True if this CompoundStructure represents a series of parallel layers that stretch from bottom to top, false otherwise.

## Remarks
Differs from IsVerticallyCompound as a vertically compound structure might happen not to have
 any horizontal breaks. For that situation, both IsVerticallyCompound and this method will return true.

