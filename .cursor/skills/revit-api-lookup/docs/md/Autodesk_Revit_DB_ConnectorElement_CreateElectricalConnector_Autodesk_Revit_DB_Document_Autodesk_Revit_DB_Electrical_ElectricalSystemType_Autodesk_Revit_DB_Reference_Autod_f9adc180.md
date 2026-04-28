---
kind: method
id: M:Autodesk.Revit.DB.ConnectorElement.CreateElectricalConnector(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Electrical.ElectricalSystemType,Autodesk.Revit.DB.Reference,Autodesk.Revit.DB.Edge)
source: html/b98681a1-6e45-0eae-e2ce-2a6bb425d810.htm
---
# Autodesk.Revit.DB.ConnectorElement.CreateElectricalConnector Method

Create a new electrical ConnectorElement.

## Syntax (C#)
```csharp
public static ConnectorElement CreateElectricalConnector(
	Document document,
	ElectricalSystemType electricalSystemType,
	Reference planarFace,
	Edge edge
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document to add the connector to.
- **electricalSystemType** (`Autodesk.Revit.DB.Electrical.ElectricalSystemType`) - The ElectricalSystemTYpe of the connector.
- **planarFace** (`Autodesk.Revit.DB.Reference`) - The planar face to place the connector on.
- **edge** (`Autodesk.Revit.DB.Edge`) - One of the edges in the edge loop that defines the connector location on the planar face.

## Returns
The electrical ConnectorElement.

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

