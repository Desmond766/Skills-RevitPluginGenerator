---
kind: method
id: M:Autodesk.Revit.DB.DirectShapeType.Create(Autodesk.Revit.DB.Document,System.String,Autodesk.Revit.DB.ElementId)
zh: 创建、新建、生成、建立、新增
source: html/59f825ef-d5dc-c04d-3252-f91230068305.htm
---
# Autodesk.Revit.DB.DirectShapeType.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a DirectShapeType element.

## Syntax (C#)
```csharp
public static DirectShapeType Create(
	Document document,
	string name,
	ElementId categoryId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - Document to which the created element will be added. Must be a project document.
- **name** (`System.String`) - Name of the DirectShapeType.
- **categoryId** (`Autodesk.Revit.DB.ElementId`) - Id of the category assigned to this DirectShapeType. Must be a valid category id.

## Returns
The new DirectShapeType.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - document is not a project document.
 -or-
 Document document may not contain DirectShape or DirectShapeType objects.
 -or-
 Element id categoryId may not be used as a DirectShape category.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

