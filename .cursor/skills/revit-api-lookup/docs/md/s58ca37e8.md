---
kind: method
id: M:Autodesk.Revit.DB.Arc.Create(Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ)
zh: 创建、新建、生成、建立、新增
source: html/e17d73ff-ee72-bfde-776b-328359f7022b.htm
---
# Autodesk.Revit.DB.Arc.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new geometric arc object based on three points.

## Syntax (C#)
```csharp
public static Arc Create(
	XYZ end0,
	XYZ end1,
	XYZ pointOnArc
)
```

## Parameters
- **end0** (`Autodesk.Revit.DB.XYZ`) - The start point of the arc.
- **end1** (`Autodesk.Revit.DB.XYZ`) - The end point of the arc.
- **pointOnArc** (`Autodesk.Revit.DB.XYZ`) - A point on the arc.

## Returns
The new arc.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was NULL
- **Autodesk.Revit.Exceptions.ArgumentsInconsistentException** - The vectors end0 and end1 are coincident.
 -or-
 The vectors end0 and pointOnArc are coincident.
 -or-
 The vectors end1 and pointOnArc are coincident.
 -or-
 Cannot create an arc.
 -or- 
 Curve length is too small for Revit's tolerance (as identified by Application.ShortCurveTolerance).

