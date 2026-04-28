---
kind: method
id: M:Autodesk.Revit.DB.ConnectorElement.CreatePipeConnector(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Plumbing.PipeSystemType,Autodesk.Revit.DB.Reference,Autodesk.Revit.DB.Edge)
source: html/0b7d2ba8-2c72-aeb0-5936-effad6cc7bf6.htm
---
# Autodesk.Revit.DB.ConnectorElement.CreatePipeConnector Method

Create a new pipe ConnectorElement with a face and an edge.

## Syntax (C#)
```csharp
public static ConnectorElement CreatePipeConnector(
	Document document,
	PipeSystemType pipeSystemType,
	Reference planarFace,
	Edge edge
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document to add the connector to.
- **pipeSystemType** (`Autodesk.Revit.DB.Plumbing.PipeSystemType`) - The PipeSystemType of the connector.
- **planarFace** (`Autodesk.Revit.DB.Reference`) - The planar face to place the connector on.
- **edge** (`Autodesk.Revit.DB.Edge`) - One of the edges in the edge loop that defines the connector location on the planar face.

## Returns
The pipe ConnectorElement.

## Remarks
Regenerates the document.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The reference is not a planar face.
 -or-
 document is not a family document.
 -or-
 Thrown when the edge does not belong to the face.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Connector creation is not allowed in this family.

