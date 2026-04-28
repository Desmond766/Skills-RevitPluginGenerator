---
kind: method
id: M:Autodesk.Revit.DB.ConnectorElement.CreateCableTrayConnector(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Reference,Autodesk.Revit.DB.Edge)
source: html/80f5ddbd-fdf4-6076-2a06-0cd185b3da78.htm
---
# Autodesk.Revit.DB.ConnectorElement.CreateCableTrayConnector Method

Create a new cable tray ConnectorElement.

## Syntax (C#)
```csharp
public static ConnectorElement CreateCableTrayConnector(
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
The cable tray ConnectorElement.

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

