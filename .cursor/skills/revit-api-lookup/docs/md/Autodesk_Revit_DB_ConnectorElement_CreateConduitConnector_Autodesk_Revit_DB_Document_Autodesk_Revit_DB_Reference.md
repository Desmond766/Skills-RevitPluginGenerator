---
kind: method
id: M:Autodesk.Revit.DB.ConnectorElement.CreateConduitConnector(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Reference)
source: html/7941cb35-59a1-1218-9272-844e20bbcc8a.htm
---
# Autodesk.Revit.DB.ConnectorElement.CreateConduitConnector Method

Create a new conduit ConnectorElement.

## Syntax (C#)
```csharp
public static ConnectorElement CreateConduitConnector(
	Document document,
	Reference planarFace
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document to add the connector to.
- **planarFace** (`Autodesk.Revit.DB.Reference`) - The planar face to place the connector on.

## Returns
The conduit ConnectorElement.

## Remarks
Regenerates the document.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The reference is not a planar face.
 -or-
 document is not a family document.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Connector creation is not allowed in this family.

