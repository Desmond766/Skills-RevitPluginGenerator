---
kind: property
id: P:Autodesk.Revit.DB.FabricationPart.Material
zh: 材质、材料
source: html/d86b29d3-b030-5f11-4bf3-c5ef677918b4.htm
---
# Autodesk.Revit.DB.FabricationPart.Material Property

**中文**: 材质、材料

The fabrication material identifier.

## Syntax (C#)
```csharp
public int Material { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: the material is not valid for the fabrication part's specification.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: the material is not able to be modified.
 -or-
 When setting this property: the fabrication part is connected to more than one item.
 -or-
 When setting this property: the material fails to be set by identifier: materialId.

