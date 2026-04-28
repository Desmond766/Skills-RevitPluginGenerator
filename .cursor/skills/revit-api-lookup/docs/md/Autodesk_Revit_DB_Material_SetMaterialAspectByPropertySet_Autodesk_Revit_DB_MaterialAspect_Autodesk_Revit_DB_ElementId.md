---
kind: method
id: M:Autodesk.Revit.DB.Material.SetMaterialAspectByPropertySet(Autodesk.Revit.DB.MaterialAspect,Autodesk.Revit.DB.ElementId)
zh: 材质、材料
source: html/73438593-0643-93d6-5c58-1fb39e2efd47.htm
---
# Autodesk.Revit.DB.Material.SetMaterialAspectByPropertySet Method

**中文**: 材质、材料

Sets an aspect of the material to a shared property set.

## Syntax (C#)
```csharp
public void SetMaterialAspectByPropertySet(
	MaterialAspect aspect,
	ElementId propertySetId
)
```

## Parameters
- **aspect** (`Autodesk.Revit.DB.MaterialAspect`) - The material aspect.
- **propertySetId** (`Autodesk.Revit.DB.ElementId`) - Identifier of a shared property set (an instance of PropertySetElement).

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

