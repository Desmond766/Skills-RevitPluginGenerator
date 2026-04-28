---
kind: method
id: M:Autodesk.Revit.DB.Plumbing.Pipe.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.Connector,Autodesk.Revit.DB.Connector)
zh: 创建、新建、生成、建立、新增
source: html/705a520c-2546-322a-1b35-b3df66960674.htm
---
# Autodesk.Revit.DB.Plumbing.Pipe.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new pipe that connects to two connectors.

## Syntax (C#)
```csharp
public static Pipe Create(
	Document document,
	ElementId pipeTypeId,
	ElementId levelId,
	Connector startConnector,
	Connector endConnector
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **pipeTypeId** (`Autodesk.Revit.DB.ElementId`) - The ElementId of the new pipe type.
- **levelId** (`Autodesk.Revit.DB.ElementId`) - The level ElementId for the new pipe.
- **startConnector** (`Autodesk.Revit.DB.Connector`) - The first connector where the new pipe starts.
- **endConnector** (`Autodesk.Revit.DB.Connector`) - The second point of the new pipe.

## Returns
The pipe.

## Remarks
The new pipe will have the same diameter and system type as the start connector. The creation will also connect the new pipe
 to two component who owns the specified connectors. If necessary, additional fitting(s) are included to make a valid connection.
 If the new pipe can not be connected to the next component (e.g., mismatched direction, no valid fitting, and etc), the new pipe
 will still be created at the specified connector position, and an InvalidOperationException is thrown.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The pipe type pipeTypeId is not valid pipe type.
 -or-
 The ElementId levelId is not a Level.
 -or-
 The connector domain is not Domain.Piping.
 -or-
 The points of startConnector and endConnector are too close: for MEPCurve, the minimum length is 1/10 inch.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.DisabledDisciplineException** - None of the following disciplines is enabled: Mechanical Electrical Piping.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the new pipe fails to connect with the connector.

