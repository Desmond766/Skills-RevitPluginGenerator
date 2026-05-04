---
kind: method
id: M:Autodesk.Revit.DB.FabricationPart.PlaceFittingAsCutIn(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.Connector,System.Double)
source: html/850f4c8a-03e3-9463-f4f5-df58ac201143.htm
---
# Autodesk.Revit.DB.FabricationPart.PlaceFittingAsCutIn Method

Places the fitting on the straight part by cut in, use the fitting's focal point as the insertion position.

## Syntax (C#)
```csharp
public static bool PlaceFittingAsCutIn(
	Document document,
	ElementId straightId,
	ElementId fittingId,
	XYZ position,
	Connector fittingConnector,
	double axisRotation
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **straightId** (`Autodesk.Revit.DB.ElementId`) - Identifier of the straight to be cut in.
- **fittingId** (`Autodesk.Revit.DB.ElementId`) - Identifier of the fitting to cut in.
- **position** (`Autodesk.Revit.DB.XYZ`) - The position to cut in the straight.
- **fittingConnector** (`Autodesk.Revit.DB.Connector`) - The connector of the fitting to align with the primary connector of the straight part.
- **axisRotation** (`System.Double`) - Rotation around the direction of connection - angle between width vectors in radians.

## Returns
True if cuts in successful.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - For rectangular and oval parts the axis rotation must be a multiple of PI/2.
 -or-
 The fitting connector is not a connector of the fitting.
 -or-
 The fitting connector is not valid, it is not within a pair connector for cutting in.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Failed to align fitting to the straight to cut in.
 -or-
 There is no enough room in the run for cut in.

