---
kind: method
id: M:Autodesk.Revit.Creation.Document.NewFlexPipe(Autodesk.Revit.DB.Connector,System.Collections.Generic.IList{Autodesk.Revit.DB.XYZ},Autodesk.Revit.DB.Plumbing.FlexPipeType)
zh: 文档、文件
source: html/1a0bb277-6f31-b344-bbcc-e5593826ae54.htm
---
# Autodesk.Revit.Creation.Document.NewFlexPipe Method

**中文**: 文档、文件

Adds a new flexible pipe into the document, 
using a connector, point array and pipe type.

## Syntax (C#)
```csharp
public FlexPipe NewFlexPipe(
	Connector connector,
	IList<XYZ> points,
	FlexPipeType pipeType
)
```

## Parameters
- **connector** (`Autodesk.Revit.DB.Connector`) - The connector to be connected to the flexible pipe, including the end points.
- **points** (`System.Collections.Generic.IList < XYZ >`) - The point array indicating the path of the flexible pipe.
- **pipeType** (`Autodesk.Revit.DB.Plumbing.FlexPipeType`) - The type of the flexible pipe.

## Returns
If creation was successful then a new flexible pipe is returned, 
otherwise an exception with failure information will be thrown.

## Remarks
If the connector is a fitting or equipment connector of the correct domain, 
and if the connector's direction matches the direction of the flexible pipe to be created, 
the connectors will be automatically connected. A transition fitting will be added 
at the connector(s) if necessary. If the connector's type, domain, 
does not match the one of the input connector, no connection will be established.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input argument connector or points is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the flexible pipe cannot be created or regenerate fails.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the flexible pipe type does not exist in the given document.

