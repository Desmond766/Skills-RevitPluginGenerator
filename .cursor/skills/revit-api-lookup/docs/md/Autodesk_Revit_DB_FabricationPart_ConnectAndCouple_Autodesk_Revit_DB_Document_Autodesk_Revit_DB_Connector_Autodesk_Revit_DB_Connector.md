---
kind: method
id: M:Autodesk.Revit.DB.FabricationPart.ConnectAndCouple(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Connector,Autodesk.Revit.DB.Connector)
source: html/bc819018-e7e1-efef-596d-742ad92b5693.htm
---
# Autodesk.Revit.DB.FabricationPart.ConnectAndCouple Method

Makes a connection between the specified connectors and adds coupling if necessary.

## Syntax (C#)
```csharp
public static bool ConnectAndCouple(
	Document document,
	Connector connector,
	Connector toConnector
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **connector** (`Autodesk.Revit.DB.Connector`) - The connector of the fabrication part.
- **toConnector** (`Autodesk.Revit.DB.Connector`) - The connector of the fabrication part or family to connect to.

## Returns
True if connection succeeded, false otherwise.

## Remarks
This function does not place and align the fabrication part. Call AlignPartByConnectors before connecting.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The connector does not belong to a fabrication part.
 -or-
 The fabrication part connectors are not aligned, call AlignPartByConnectors to align them.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

