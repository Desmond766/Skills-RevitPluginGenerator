---
kind: method
id: M:Autodesk.Revit.Creation.Document.NewFlexPipe(Autodesk.Revit.DB.Connector,Autodesk.Revit.DB.Connector,Autodesk.Revit.DB.Plumbing.FlexPipeType)
zh: 文档、文件
source: html/d43da744-8bf9-b2a5-e489-67e6d46bef2a.htm
---
# Autodesk.Revit.Creation.Document.NewFlexPipe Method

**中文**: 文档、文件

Adds a new flexible pipe into the document, 
using two connector, and flexible pipe type.

## Syntax (C#)
```csharp
public FlexPipe NewFlexPipe(
	Connector connector1,
	Connector connector2,
	FlexPipeType pipeType
)
```

## Parameters
- **connector1** (`Autodesk.Revit.DB.Connector`) - The first connector to be connected to the pipe.
- **connector2** (`Autodesk.Revit.DB.Connector`) - The second connector to be connected to the pipe.
- **pipeType** (`Autodesk.Revit.DB.Plumbing.FlexPipeType`) - The type of the flexible pipe.

## Returns
If creation was successful then a new flexible pipe is returned, 
otherwise an exception with failure information will be thrown.

## Remarks
If the connectors are fitting or equipment connectors of the correct domain, 
and if the connectors' direction match the direction of the flexible pipe to be created, 
the connectors will be automatically connected. A transition fitting will be added 
at the connector(s) if necessary. If the connector's type, domain, 
does not match the one of the input connectors, no connection will be established.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input argument connector1 or connector2 is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the flexible pipe cannot be created or regenerate fails.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the flexible pipe type does not exist in the given document.

