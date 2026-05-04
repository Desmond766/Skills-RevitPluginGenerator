---
kind: property
id: P:Autodesk.Revit.DB.RoofBase.SlabShapeEditor
source: html/d652eb15-1891-d926-1258-94908d8c51d7.htm
---
# Autodesk.Revit.DB.RoofBase.SlabShapeEditor Property

Get the SlabShapeEditor used for slab shape editing.

## Syntax (C#)
```csharp
[ObsoleteAttribute("This method is deprecated in Revit 2024 and may be removed in a future version of Revit. Use GetSlabShapeEditor() instead.")]
public SlabShapeEditor SlabShapeEditor { get; }
```

## Remarks
Roofs cannot be attached to another roof, and the roof cannot be a curtain roof. If either of these conditions is not met, the ShapeEditor will be Nothing nullptr a null reference ( Nothing in Visual Basic) .

