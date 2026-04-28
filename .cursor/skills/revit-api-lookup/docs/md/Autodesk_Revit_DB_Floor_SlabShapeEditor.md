---
kind: property
id: P:Autodesk.Revit.DB.Floor.SlabShapeEditor
zh: 楼板、板、地板
source: html/efa9b741-145a-b1e1-a1ec-40abda11919d.htm
---
# Autodesk.Revit.DB.Floor.SlabShapeEditor Property

**中文**: 楼板、板、地板

Get the SlabShapeEditor used for slab shape editing.

## Syntax (C#)
```csharp
[ObsoleteAttribute("This method is deprecated in Revit 2024 and may be removed in a future version of Revit. Use GetSlabShapeEditor() instead.")]
public SlabShapeEditor SlabShapeEditor { get; }
```

## Remarks
Only flat and horizontal floor is valid for slab shape edit. Otherwise, ShapeEditor will be Nothing nullptr a null reference ( Nothing in Visual Basic) .

