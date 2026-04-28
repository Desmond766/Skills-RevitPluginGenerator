---
kind: method
id: M:Autodesk.Revit.DB.FabricationHostedInfo.PlaceOnHost(Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.Connector,System.Double)
source: html/66f2c679-d136-7252-d417-5cb122c9840d.htm
---
# Autodesk.Revit.DB.FabricationHostedInfo.PlaceOnHost Method

Places the part on the specified host.

## Syntax (C#)
```csharp
public void PlaceOnHost(
	ElementId hostId,
	Connector hostConnector,
	double distance
)
```

## Parameters
- **hostId** (`Autodesk.Revit.DB.ElementId`) - Identifier of the host fabrication part.
- **hostConnector** (`Autodesk.Revit.DB.Connector`) - The connector of the host.
- **distance** (`System.Double`) - The distance from the connector to place the hosted part. Units are in feet (ft).

## Remarks
The document must be regenerated before the fabrication part can be used.
 Check ValidationStatus after regeneration to see if the part is valid for fabrication.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Invalid fabrication part host. The host should be a straight fabrication part.
 -or-
 Invalid connector of fabrication part host.
 -or-
 The distance is out of range.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

