---
kind: method
id: M:Autodesk.Revit.DB.DirectShapeType.Create(Autodesk.Revit.DB.Document,System.String,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.DirectShapeTypeOptions)
zh: 创建、新建、生成、建立、新增
source: html/be6be1e1-bca3-2431-9000-4481b9f8b98a.htm
---
# Autodesk.Revit.DB.DirectShapeType.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a DirectShapeType element.

## Syntax (C#)
```csharp
public static DirectShapeType Create(
	Document document,
	string name,
	ElementId categoryId,
	DirectShapeTypeOptions options
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - Document to which the created element will be added.
- **name** (`System.String`) - Name of the DirectShapeType.
- **categoryId** (`Autodesk.Revit.DB.ElementId`) - Id of the category assigned to this DirectShapeType. Must be a valid category id.
- **options** (`Autodesk.Revit.DB.DirectShapeTypeOptions`) - Options that can be used to control the behavior of DirectShapeType being created.

## Returns
The new DirectShapeType.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Document document may not contain DirectShape or DirectShapeType objects.
 -or-
 Element id categoryId may not be used as a DirectShape category.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

