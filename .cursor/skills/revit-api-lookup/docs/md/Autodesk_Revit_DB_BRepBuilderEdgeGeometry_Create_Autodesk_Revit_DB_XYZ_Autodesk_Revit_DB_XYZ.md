---
kind: method
id: M:Autodesk.Revit.DB.BRepBuilderEdgeGeometry.Create(Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ)
zh: 创建、新建、生成、建立、新增
source: html/f2d295f0-1ff9-a8c4-d723-6e521fcbab9c.htm
---
# Autodesk.Revit.DB.BRepBuilderEdgeGeometry.Create Method

**中文**: 创建、新建、生成、建立、新增

Constructs a BRepBuilderEdgeGeometry representing a straight line between the two given points.

## Syntax (C#)
```csharp
public static BRepBuilderEdgeGeometry Create(
	XYZ startPoint,
	XYZ endPoint
)
```

## Parameters
- **startPoint** (`Autodesk.Revit.DB.XYZ`)
- **endPoint** (`Autodesk.Revit.DB.XYZ`)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentsInconsistentException** - The vectors startPoint and endPoint are coincident.

