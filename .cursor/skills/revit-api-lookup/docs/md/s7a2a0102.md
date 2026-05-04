---
kind: method
id: M:Autodesk.Revit.DB.ConnectorElement.CreatePipeConnector(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Plumbing.PipeSystemType,Autodesk.Revit.DB.Reference)
source: html/6fdcd1e4-61d0-2a01-2e5b-b5d918f0cfee.htm
---
# Autodesk.Revit.DB.ConnectorElement.CreatePipeConnector Method

Create a new pipe ConnectorElement.

## Syntax (C#)
```csharp
public static ConnectorElement CreatePipeConnector(
	Document document,
	PipeSystemType pipeSystemType,
	Reference planarFace
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document to add the connector to.
- **pipeSystemType** (`Autodesk.Revit.DB.Plumbing.PipeSystemType`) - The PipeSystemType of the connector.
- **planarFace** (`Autodesk.Revit.DB.Reference`) - The planar face to place the connector on.

## Returns
The pipe ConnectorElement.

## Remarks
Regenerates the document.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The reference is not a planar face.
 -or-
 document is not a family document.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Connector creation is not allowed in this family.

