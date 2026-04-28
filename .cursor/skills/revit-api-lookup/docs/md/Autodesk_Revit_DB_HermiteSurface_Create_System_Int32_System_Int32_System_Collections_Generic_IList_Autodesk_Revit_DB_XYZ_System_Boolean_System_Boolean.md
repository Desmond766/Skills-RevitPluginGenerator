---
kind: method
id: M:Autodesk.Revit.DB.HermiteSurface.Create(System.Int32,System.Int32,System.Collections.Generic.IList{Autodesk.Revit.DB.XYZ},System.Boolean,System.Boolean)
zh: 创建、新建、生成、建立、新增
source: html/e4480853-0cfd-3856-d931-a0b456a09fe5.htm
---
# Autodesk.Revit.DB.HermiteSurface.Create Method

**中文**: 创建、新建、生成、建立、新增

Create a Hermite surface using a net of 3D points as input. Specify periodicity in U and V direction.

## Syntax (C#)
```csharp
public static HermiteSurface Create(
	int nU,
	int nV,
	IList<XYZ> points,
	bool periodicU,
	bool periodicV
)
```

## Parameters
- **nU** (`System.Int32`) - Number of points in U direction.
- **nV** (`System.Int32`) - Number of points in V direction.
- **points** (`System.Collections.Generic.IList < XYZ >`) - Array of points. Must contain nU*nV points.
- **periodicU** (`System.Boolean`) - Periodicity in U direction
- **periodicV** (`System.Boolean`) - Periodicity in V direction

## Returns
A Hermite surface object created from input data.

## Remarks
Points form a net of nU * nV (less one each if periodic) 3D points.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentsInconsistentException** - Thrown when the input arguments are inconsistent. The most common case is incorrect number of items in one of the lists.

