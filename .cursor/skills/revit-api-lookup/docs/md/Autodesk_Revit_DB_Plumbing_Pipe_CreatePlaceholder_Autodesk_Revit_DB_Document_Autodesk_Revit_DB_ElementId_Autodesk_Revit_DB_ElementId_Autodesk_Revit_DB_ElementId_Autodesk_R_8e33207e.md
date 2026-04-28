---
kind: method
id: M:Autodesk.Revit.DB.Plumbing.Pipe.CreatePlaceholder(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ)
zh: 管道、水管、管线
source: html/f291f914-aa0c-f6b0-c824-3fffe0191aba.htm
---
# Autodesk.Revit.DB.Plumbing.Pipe.CreatePlaceholder Method

**中文**: 管道、水管、管线

Creates a new placeholder pipe.

## Syntax (C#)
```csharp
public static Pipe CreatePlaceholder(
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
- **levelId** (`Autodesk.Revit.DB.ElementId`) - The level id for the pipe.
- **startPoint** (`Autodesk.Revit.DB.XYZ`) - The first point of the placeholder line.
- **endPoint** (`Autodesk.Revit.DB.XYZ`) - The second point of the placeholder line.

## Returns
The placeholder pipe.

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

