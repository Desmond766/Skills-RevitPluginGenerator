---
kind: method
id: M:Autodesk.Revit.DB.FabricationPart.AlignPartByConnector(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Connector,Autodesk.Revit.DB.XYZ,System.Double,System.Double,System.Double,Autodesk.Revit.DB.Fabrication.FabricationPartJustification,Autodesk.Revit.DB.Transform)
source: html/894f5ea4-60ba-55be-65ef-4e4cb66e04ae.htm
---
# Autodesk.Revit.DB.FabricationPart.AlignPartByConnector Method

Align the part by its connector to a point and rotation in free space.

## Syntax (C#)
```csharp
public static bool AlignPartByConnector(
	Document document,
	Connector connector,
	XYZ position,
	double rotation,
	double rotationPerpendicular,
	double slope,
	FabricationPartJustification justification,
	Transform trf
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **connector** (`Autodesk.Revit.DB.Connector`) - The connector to align in free space.
- **position** (`Autodesk.Revit.DB.XYZ`) - The position to move the connector to.
- **rotation** (`System.Double`) - The rotation in radians.
- **rotationPerpendicular** (`System.Double`) - The perpendicular rotation for free placement around the Y axis direction of connection - angle in radians.
- **slope** (`System.Double`) - The slope value to flex to match if possible in fractional units (eg.1/50). Positive values are up, negative are down. Slopes can only be applied
 to fittings, whilst straights will inherit the slope from the piece it is connecting to.
- **justification** (`Autodesk.Revit.DB.Fabrication.FabricationPartJustification`) - The justification to align eccentric parts.
- **trf** (`Autodesk.Revit.DB.Transform`) - Optional alignment transformation matrix, eg. a Trf that describes plan or side elevation.

## Returns
True if the alignment succeeds, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The connector does not belong to a fabrication part.
 -or-
 The fabrication part is connected.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

