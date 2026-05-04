---
kind: method
id: M:Autodesk.Revit.DB.Architecture.StairsPath.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.LinkElementId,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
zh: 创建、新建、生成、建立、新增
source: html/be12fdab-ac49-fa9f-0085-1c3bbad1461a.htm
---
# Autodesk.Revit.DB.Architecture.StairsPath.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new stairs path for the specified stairs with the specified stairs path type only in the plan view.

## Syntax (C#)
```csharp
public static StairsPath Create(
	Document document,
	LinkElementId stairsId,
	ElementId typeId,
	ElementId planViewId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **stairsId** (`Autodesk.Revit.DB.LinkElementId`) - The id of the stairs element either in the host document or in a linked document.
- **typeId** (`Autodesk.Revit.DB.ElementId`) - The type of stairs path.
- **planViewId** (`Autodesk.Revit.DB.ElementId`) - The plan view in which the stairs path will be shown.

## Returns
The new stairs path.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The stairsId is not a valid stairs.
 -or-
 The typeId is not a valid stairs path type.
 -or-
 The planViewId is not a valid plan view.
 -or-
 The stairsId already has a stairs path.
 -or-
 The stairsId is not visible in planViewId.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

