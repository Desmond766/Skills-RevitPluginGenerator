---
kind: method
id: M:Autodesk.Revit.DB.FabricationPart.RotateConnectedPartByConnector(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Connector,System.Double)
source: html/02210a65-3a33-96c0-f727-d29b8e27594b.htm
---
# Autodesk.Revit.DB.FabricationPart.RotateConnectedPartByConnector Method

Rotates a connected fabrication part around the axis of the specified connector.

## Syntax (C#)
```csharp
public static void RotateConnectedPartByConnector(
	Document document,
	Connector connector,
	double axisRotationBy
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **connector** (`Autodesk.Revit.DB.Connector`) - The connected connector of the fabrication part to be rotated.
- **axisRotationBy** (`System.Double`) - The angle in radians to rotate by.

## Remarks
Attempts to resize rectangular and oval ends if the angle is a multiple of PI/2.
 Taps cannot be rotated.
 For rectangular and oval profiles only 90, 180 and 270 degree rotations are valid.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - For rectangular and oval parts the axis rotation must be a multiple of PI/2.
 -or-
 The connector does not belong to a fabrication part.
 -or-
 Connector is not connected.
 -or-
 Connector belongs to a fabrication part tap.
 -or-
 Fabrication part cannot be rotated because it is either unable to be re-sized or it is too constrained.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - rotate failed because the fabrication part geometry could not be modified accordingly.

