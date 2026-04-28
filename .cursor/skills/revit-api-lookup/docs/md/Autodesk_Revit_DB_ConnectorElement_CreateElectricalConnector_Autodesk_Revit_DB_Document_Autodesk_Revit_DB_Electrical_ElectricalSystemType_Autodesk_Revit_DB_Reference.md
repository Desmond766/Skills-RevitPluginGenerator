---
kind: method
id: M:Autodesk.Revit.DB.ConnectorElement.CreateElectricalConnector(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Electrical.ElectricalSystemType,Autodesk.Revit.DB.Reference)
source: html/ba37da90-c759-890b-2a9f-a037ef54c971.htm
---
# Autodesk.Revit.DB.ConnectorElement.CreateElectricalConnector Method

Create a new electrical ConnectorElement.

## Syntax (C#)
```csharp
public static ConnectorElement CreateElectricalConnector(
	Document document,
	ElectricalSystemType electricalSystemType,
	Reference planarFace
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document to add the connector to.
- **electricalSystemType** (`Autodesk.Revit.DB.Electrical.ElectricalSystemType`) - The ElectricalSystemTYpe of the connector.
- **planarFace** (`Autodesk.Revit.DB.Reference`) - The planar face to place the connector on.

## Returns
The electrical ConnectorElement.

## Remarks
Regenerates the document.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The reference is not a planar face.
 -or-
 document is not a family document.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Connector creation is not allowed in this family.

