---
kind: method
id: M:Autodesk.Revit.DB.Plumbing.FlexPipe.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId,System.Collections.Generic.IList{Autodesk.Revit.DB.XYZ})
zh: 创建、新建、生成、建立、新增
source: html/87bc8919-4eee-ac76-2e94-4a3d70e2826c.htm
---
# Autodesk.Revit.DB.Plumbing.FlexPipe.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new flexible pipe into the document, using a point array and flex pipe type.

## Syntax (C#)
```csharp
public static FlexPipe Create(
	Document document,
	ElementId systemTypeId,
	ElementId pipeTypeId,
	ElementId levelId,
	IList<XYZ> points
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **systemTypeId** (`Autodesk.Revit.DB.ElementId`) - The id of the piping system type.
- **pipeTypeId** (`Autodesk.Revit.DB.ElementId`) - The id of the flexible pipe.
- **levelId** (`Autodesk.Revit.DB.ElementId`) - The level id for the flexible pipe.
- **points** (`System.Collections.Generic.IList < XYZ >`) - The point array indicating the path of the flexible pipe, including the end point.

## Returns
If creation was successful then a new flexible pipe is returned, otherwise an exception with failure information will be thrown.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The systemTypeId is not valid piping system type.
 -or-
 The type pipeTypeId is not valid flexible pipe type.
 -or-
 The ElementId levelId is not a Level.
 -or-
 The valid number of points is less than two. In order to create a flex curve, at least two points are required. Note the duplicate points don't take into account.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.DisabledDisciplineException** - None of the following disciplines is enabled: Mechanical Electrical Piping.

