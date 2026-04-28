---
kind: method
id: M:Autodesk.Revit.DB.ConnectorElement.CreateDuctConnector(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Mechanical.DuctSystemType,Autodesk.Revit.DB.ConnectorProfileType,Autodesk.Revit.DB.Reference,Autodesk.Revit.DB.Edge)
source: html/66f1e4a9-71b0-93da-b8be-56a743012fcf.htm
---
# Autodesk.Revit.DB.ConnectorElement.CreateDuctConnector Method

Create a new duct ConnectorElement.

## Syntax (C#)
```csharp
public static ConnectorElement CreateDuctConnector(
	Document document,
	DuctSystemType ductSystemType,
	ConnectorProfileType profileShape,
	Reference planarFace,
	Edge edge
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document to add the connector to.
- **ductSystemType** (`Autodesk.Revit.DB.Mechanical.DuctSystemType`) - The DuctSystemType of the connector.
- **profileShape** (`Autodesk.Revit.DB.ConnectorProfileType`) - The profile shape of the duct.
- **planarFace** (`Autodesk.Revit.DB.Reference`) - The planar face to place the connector on.
- **edge** (`Autodesk.Revit.DB.Edge`) - One of the edges in the edge loop that defines the connector location on the planar face.

## Returns
The duct ConnectorElement.

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

