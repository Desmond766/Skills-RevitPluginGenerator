---
kind: method
id: M:Autodesk.Revit.Creation.Document.NewFlexPipe(System.Collections.Generic.IList{Autodesk.Revit.DB.XYZ},Autodesk.Revit.DB.Plumbing.FlexPipeType)
zh: 文档、文件
source: html/4c34f62d-8690-fcf4-5606-9cf42b703f2e.htm
---
# Autodesk.Revit.Creation.Document.NewFlexPipe Method

**中文**: 文档、文件

Adds a new flexible pipe into the document, 
using a point array and pipe type.

## Syntax (C#)
```csharp
public FlexPipe NewFlexPipe(
	IList<XYZ> points,
	FlexPipeType pipeType
)
```

## Parameters
- **points** (`System.Collections.Generic.IList < XYZ >`) - The point array indicating the path of the flexible pipe, including the end points.
- **pipeType** (`Autodesk.Revit.DB.Plumbing.FlexPipeType`) - The type of the flexible pipe.

## Returns
If creation was successful then a new flexible pipe is returned, 
otherwise an exception with failure information will be thrown.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input argument points is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the flexible pipe cannot be created or regenerate fails.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the flexible pipe type does not exist in the given document.

