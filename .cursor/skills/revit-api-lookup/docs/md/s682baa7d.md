---
kind: method
id: M:Autodesk.Revit.DB.FabricationHostedInfo.PlaceOnHost(Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.Connector,System.Double,System.Double)
source: html/aba22d62-a05c-0d34-91c8-e2a08041994f.htm
---
# Autodesk.Revit.DB.FabricationHostedInfo.PlaceOnHost Method

Places the part on the specified host.

## Syntax (C#)
```csharp
public void PlaceOnHost(
	ElementId hostId,
	Connector hostConnector,
	double distance,
	double axisRotation
)
```

## Parameters
- **hostId** (`Autodesk.Revit.DB.ElementId`) - Identifier of the host fabrication part.
- **hostConnector** (`Autodesk.Revit.DB.Connector`) - The connector of the host.
- **distance** (`System.Double`) - The distance from the connector to place the hosted part. Units are in feet (ft).
- **axisRotation** (`System.Double`) - The axis rotation in radians.

## Remarks
The document must be regenerated before the fabrication part can be used.
 Check ValidationStatus after regeneration to see if the part is valid for fabrication.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Invalid fabrication part host. The host should be a straight fabrication part.
 -or-
 Invalid connector of fabrication part host.
 -or-
 The distance is out of range.
 -or-
 For rectangular and oval parts the axis rotation must be a multiple of PI/2.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

