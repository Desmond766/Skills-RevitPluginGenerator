---
kind: method
id: M:Autodesk.Revit.DB.ConnectorElement.CreateCableTrayConnector(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Reference)
source: html/39ed9c20-4f8b-6087-2913-580028822284.htm
---
# Autodesk.Revit.DB.ConnectorElement.CreateCableTrayConnector Method

Create a new cable tray ConnectorElement.

## Syntax (C#)
```csharp
public static ConnectorElement CreateCableTrayConnector(
	Document document,
	Reference planarFace
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document to add the connector to.
- **planarFace** (`Autodesk.Revit.DB.Reference`) - The planar face to place the connector on.

## Returns
The cable tray ConnectorElement.

## Remarks
Regenerates the document.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The reference is not a planar face.
 -or-
 document is not a family document.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Connector creation is not allowed in this family.

