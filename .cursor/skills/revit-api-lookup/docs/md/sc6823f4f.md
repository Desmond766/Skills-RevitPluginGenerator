---
kind: method
id: M:Autodesk.Revit.DB.HermiteSurface.Create(System.Int32,System.Int32,System.Collections.Generic.IList{Autodesk.Revit.DB.XYZ})
zh: 创建、新建、生成、建立、新增
source: html/cf4eb83b-5e6a-8f36-7c24-b215815b850b.htm
---
# Autodesk.Revit.DB.HermiteSurface.Create Method

**中文**: 创建、新建、生成、建立、新增

Create a non-periodic Hermite surface using a net of 3D points as input.

## Syntax (C#)
```csharp
public static HermiteSurface Create(
	int nU,
	int nV,
	IList<XYZ> points
)
```

## Parameters
- **nU** (`System.Int32`) - Number of points in U direction.
- **nV** (`System.Int32`) - Number of points in V direction.
- **points** (`System.Collections.Generic.IList < XYZ >`) - Array of points. Must contain nU*nV points.

## Returns
A Hermite surface object created from input data.

## Remarks
Points form a net of nU * nV 3D points. Suitable defaults will be used for other surface parameters.
 See other Create() functions if greater control over input is desired.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentsInconsistentException** - Thrown when the input arguments are inconsistent. The most common case is incorrect number of items in one of the lists.

