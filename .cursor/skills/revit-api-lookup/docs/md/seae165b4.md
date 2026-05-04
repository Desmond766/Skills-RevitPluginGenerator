---
kind: method
id: M:Autodesk.Revit.DB.Point.Create(Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.ElementId)
zh: 创建、新建、生成、建立、新增
source: html/000086a5-6616-2780-2fc8-0460ab9a3e5b.htm
---
# Autodesk.Revit.DB.Point.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a point at the given coordinates and assigns it the specified GraphicsStyle.

## Syntax (C#)
```csharp
public static Point Create(
	XYZ coord,
	ElementId id
)
```

## Parameters
- **coord** (`Autodesk.Revit.DB.XYZ`) - The coordinates where the point will be created.
- **id** (`Autodesk.Revit.DB.ElementId`) - The id of the GraphicsStyle element from which to apply the point properties.

## Returns
A Point object.

