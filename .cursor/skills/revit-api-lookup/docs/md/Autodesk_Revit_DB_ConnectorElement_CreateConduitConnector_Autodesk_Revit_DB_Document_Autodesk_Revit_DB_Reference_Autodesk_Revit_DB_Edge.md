---
kind: method
id: M:Autodesk.Revit.DB.ConnectorElement.CreateConduitConnector(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Reference,Autodesk.Revit.DB.Edge)
source: html/d048d302-c184-b1b9-54c9-1b8fb7e35cab.htm
---
# Autodesk.Revit.DB.ConnectorElement.CreateConduitConnector Method

Create a new conduit ConnectorElement.

## Syntax (C#)
```csharp
public static ConnectorElement CreateConduitConnector(
	Document document,
	Reference planarFace,
	Edge edge
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document to add the connector to.
- **planarFace** (`Autodesk.Revit.DB.Reference`) - The planar face to place the connector on.
- **edge** (`Autodesk.Revit.DB.Edge`) - One of the edges in the edge loop that defines the connector location on the planar face.

## Returns
The conduit ConnectorElement.

## Remarks
Regenerates the document.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The reference is not a planar face.
 -or-
 document is not a family document.
 -or-
 Thrown when the edge does not belong to the face.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Connector creation is not allowed in this family.

