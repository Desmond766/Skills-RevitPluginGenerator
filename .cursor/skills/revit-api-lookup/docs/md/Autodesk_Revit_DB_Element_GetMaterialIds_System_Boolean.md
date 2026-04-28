---
kind: method
id: M:Autodesk.Revit.DB.Element.GetMaterialIds(System.Boolean)
zh: 构件、图元、元素
source: html/6011352e-151b-b8ac-14cc-45970f2fe5ad.htm
---
# Autodesk.Revit.DB.Element.GetMaterialIds Method

**中文**: 构件、图元、元素

Gets the element ids of all materials present in the element.

## Syntax (C#)
```csharp
public ICollection<ElementId> GetMaterialIds(
	bool returnPaintMaterials
)
```

## Parameters
- **returnPaintMaterials** (`System.Boolean`) - If true, this returns material ids assigned to element faces by the Paint tools. If false, this returns ids associated to the material through
 its geometry or compound structure layers.

## Returns
The set of material ids.

## Remarks
The returned collection of materials will be empty in any of the following situations:
 The returnPaintMaterials flag is false, and the Category.HasMaterialQuantities property of the element's Category is false. The returnPaintMaterials flag is true, and the the element does not have any painted faces. 
 Any material ids returned by this method can be used in GetMaterialArea() to get the calculated area associated to the material.
 Non-paint materials ids returned by this method can be used in GetMaterialVolume() to get the volume associated to the material.

