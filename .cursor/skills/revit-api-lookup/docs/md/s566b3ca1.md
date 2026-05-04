---
kind: method
id: M:Autodesk.Revit.DB.Material.IsMaterialOrValidDefault(Autodesk.Revit.DB.Element,Autodesk.Revit.DB.ElementId)
zh: 材质、材料
source: html/5337f779-e4d7-4f61-0ed5-df974b111543.htm
---
# Autodesk.Revit.DB.Material.IsMaterialOrValidDefault Method

**中文**: 材质、材料

Validates whether the specified element id is a material element.

## Syntax (C#)
```csharp
public static bool IsMaterialOrValidDefault(
	Element pElem,
	ElementId materialId
)
```

## Parameters
- **pElem** (`Autodesk.Revit.DB.Element`) - An element which will be applied the material
- **materialId** (`Autodesk.Revit.DB.ElementId`) - The element id to be checked.

## Returns
True if the element a material element or invalidElementId, which means take material from category, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

