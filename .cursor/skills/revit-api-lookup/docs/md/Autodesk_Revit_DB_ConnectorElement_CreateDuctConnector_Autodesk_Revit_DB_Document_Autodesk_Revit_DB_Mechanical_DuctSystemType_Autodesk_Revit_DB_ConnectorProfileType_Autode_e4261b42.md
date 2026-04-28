---
kind: method
id: M:Autodesk.Revit.DB.ConnectorElement.CreateDuctConnector(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Mechanical.DuctSystemType,Autodesk.Revit.DB.ConnectorProfileType,Autodesk.Revit.DB.Reference)
source: html/a2c97617-8407-b4e8-c2fa-f78585326b06.htm
---
# Autodesk.Revit.DB.ConnectorElement.CreateDuctConnector Method

Create a new duct ConnectorElement.

## Syntax (C#)
```csharp
public static ConnectorElement CreateDuctConnector(
	Document document,
	DuctSystemType ductSystemType,
	ConnectorProfileType profileShape,
	Reference planarFace
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document to add the connector to.
- **ductSystemType** (`Autodesk.Revit.DB.Mechanical.DuctSystemType`) - The DuctSystemType of the connector.
- **profileShape** (`Autodesk.Revit.DB.ConnectorProfileType`) - The profile shape of the duct.
- **planarFace** (`Autodesk.Revit.DB.Reference`) - The planar face to place the connector on.

## Returns
The duct ConnectorElement.

## Remarks
Regenerates the document.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The reference is not a planar face.
 -or-
 document is not a family document.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Connector creation is not allowed in this family.

