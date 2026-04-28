---
kind: method
id: M:Autodesk.Revit.DB.FabricationPart.AlignPartByConnectors(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Connector,Autodesk.Revit.DB.Connector,System.Double)
source: html/b3a20dcf-d275-f308-f0ed-23d502bf2433.htm
---
# Autodesk.Revit.DB.FabricationPart.AlignPartByConnectors Method

Moves fabrication part by one of its connectors and aligns it to another connector.

## Syntax (C#)
```csharp
public static bool AlignPartByConnectors(
	Document document,
	Connector connector,
	Connector toConnector,
	double axisRotation
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **connector** (`Autodesk.Revit.DB.Connector`) - The connector of the fabrication part to move and align by.
- **toConnector** (`Autodesk.Revit.DB.Connector`) - The connector of the fabrication part or family to align to.
- **axisRotation** (`System.Double`) - Rotation around the direction of connection - angle between width vectors in radians.

## Returns
True if alignment succeeds, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - For rectangular and oval parts the axis rotation must be a multiple of PI/2.
 -or-
 The connector does not belong to a fabrication part.
 -or-
 The fabrication part is connected.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

