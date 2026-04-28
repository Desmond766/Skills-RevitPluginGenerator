---
kind: method
id: M:Autodesk.Revit.DB.Plumbing.Pipe.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ)
zh: 创建、新建、生成、建立、新增
source: html/9550265f-5760-3c28-d023-d0373285855b.htm
---
# Autodesk.Revit.DB.Plumbing.Pipe.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new pipe from two points.

## Syntax (C#)
```csharp
public static Pipe Create(
	Document document,
	ElementId systemTypeId,
	ElementId pipeTypeId,
	ElementId levelId,
	XYZ startPoint,
	XYZ endPoint
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **systemTypeId** (`Autodesk.Revit.DB.ElementId`) - The ElementId of the piping system type.
- **pipeTypeId** (`Autodesk.Revit.DB.ElementId`) - The ElementId of the pipe type.
- **levelId** (`Autodesk.Revit.DB.ElementId`) - The level ElementId for the pipe.
- **startPoint** (`Autodesk.Revit.DB.XYZ`) - The start point of the pipe.
- **endPoint** (`Autodesk.Revit.DB.XYZ`) - The end point of the pipe.

## Returns
The pipe.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The systemTypeId is not valid piping system type.
 -or-
 The pipe type pipeTypeId is not valid pipe type.
 -or-
 The ElementId levelId is not a Level.
 -or-
 The points of startPoint and endPoint are too close: for MEPCurve, the minimum length is 1/10 inch.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.DisabledDisciplineException** - None of the following disciplines is enabled: Mechanical Electrical Piping.

