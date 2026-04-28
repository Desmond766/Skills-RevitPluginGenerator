---
kind: method
id: M:Autodesk.Revit.DB.Plumbing.Pipe.IsPipeTypeId(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
zh: 管道、水管、管线
source: html/49856957-ee68-6497-37e4-032f84f4e193.htm
---
# Autodesk.Revit.DB.Plumbing.Pipe.IsPipeTypeId Method

**中文**: 管道、水管、管线

Checks if given type is valid pipe type.

## Syntax (C#)
```csharp
public static bool IsPipeTypeId(
	Document document,
	ElementId pipeTypeId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **pipeTypeId** (`Autodesk.Revit.DB.ElementId`) - ElementId of the pipe type to check.

## Returns
True if pipe type can used for this pipe, false otherwise.

## Remarks
A type is valid for pipe if it can be used to the pipe element.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

