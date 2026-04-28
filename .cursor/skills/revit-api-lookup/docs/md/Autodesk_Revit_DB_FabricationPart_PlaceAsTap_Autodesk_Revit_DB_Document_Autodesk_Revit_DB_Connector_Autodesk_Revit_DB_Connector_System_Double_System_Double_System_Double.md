---
kind: method
id: M:Autodesk.Revit.DB.FabricationPart.PlaceAsTap(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Connector,Autodesk.Revit.DB.Connector,System.Double,System.Double,System.Double)
source: html/d58b8fa2-3747-2d66-3de5-0d92803abcf7.htm
---
# Autodesk.Revit.DB.FabricationPart.PlaceAsTap Method

Places the part by its connector to a specific position on the straight part at the specified distance from the host part connector.

## Syntax (C#)
```csharp
public static void PlaceAsTap(
	Document document,
	Connector tapPartConnector,
	Connector hostPartConnector,
	double distance,
	double axisRotation,
	double secondaryAxisRotation
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **tapPartConnector** (`Autodesk.Revit.DB.Connector`) - The connector of the part to place.
- **hostPartConnector** (`Autodesk.Revit.DB.Connector`) - The connector of host part.
- **distance** (`System.Double`) - The distance to host part connector where to place the part.
- **axisRotation** (`System.Double`) - The axis rotation in radians.
- **secondaryAxisRotation** (`System.Double`) - The secondary axis rotation in radians.

## Remarks
Tap cannot be placed if it is already connected.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - It is not a valid part to place as tap.
 -or-
 Tap should be placed on straight part.
 -or-
 The distance is out of range.
 -or-
 For rectangular and oval parts the axis rotation must be a multiple of PI/2.
 -or-
 Invalid tap for host's profile type.
 -or-
 The fabrication part is connected.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - tap is not connected by its primary connector.
- **[!:Autodesk::Revit::Exceptions::InvalidOpertationException]** - tap does not fit on the host.

