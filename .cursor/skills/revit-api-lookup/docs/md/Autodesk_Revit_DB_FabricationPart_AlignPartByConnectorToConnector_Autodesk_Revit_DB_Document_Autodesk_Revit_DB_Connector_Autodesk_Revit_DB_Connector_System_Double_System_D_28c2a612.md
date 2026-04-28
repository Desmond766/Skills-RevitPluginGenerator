---
kind: method
id: M:Autodesk.Revit.DB.FabricationPart.AlignPartByConnectorToConnector(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Connector,Autodesk.Revit.DB.Connector,System.Double,System.Double,Autodesk.Revit.DB.Fabrication.FabricationPartJustification)
source: html/8a15ef1a-9736-1bc5-0ae6-e4ba7ea4ce1c.htm
---
# Autodesk.Revit.DB.FabricationPart.AlignPartByConnectorToConnector Method

Align a part by its connector to another connector. This will replace the FabricationPart::AlignPartByConnectors method.

## Syntax (C#)
```csharp
public static bool AlignPartByConnectorToConnector(
	Document document,
	Connector connector,
	Connector fixedConnector,
	double rotation,
	double slope,
	FabricationPartJustification justification
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **connector** (`Autodesk.Revit.DB.Connector`) - The connector of the fabrication part to move by in free space.
- **fixedConnector** (`Autodesk.Revit.DB.Connector`) - The connector for the fabrication part or family connector to align to.
- **rotation** (`System.Double`) - The rotation in radians.
- **slope** (`System.Double`) - The slope value to flex to match if possible in fractional units (eg.1/50). Positive values are up, negative are down. Slopes can only be applied
 to fittings, whilst straights will inherit the slope from the piece it is connecting to.
- **justification** (`Autodesk.Revit.DB.Fabrication.FabricationPartJustification`) - The justification to align eccentric parts.

## Returns
True if the alignment succeeds, false otherwise and the part will not move from the original position.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - For rectangular and oval parts the axis rotation must be a multiple of PI/2.
 -or-
 The connector does not belong to a fabrication part.
 -or-
 The fabrication part is connected.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

