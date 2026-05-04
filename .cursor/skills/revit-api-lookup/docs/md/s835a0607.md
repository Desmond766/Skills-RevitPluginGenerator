---
kind: method
id: M:Autodesk.Revit.DB.Mechanical.MechanicalUtils.ConnectAirTerminalOnDuct(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
source: html/809187c2-49fe-38b1-59ee-9adf2a9765e4.htm
---
# Autodesk.Revit.DB.Mechanical.MechanicalUtils.ConnectAirTerminalOnDuct Method

Connects an air terminal to a duct directly (without the need for a tee or takeoff).

## Syntax (C#)
```csharp
public static bool ConnectAirTerminalOnDuct(
	Document document,
	ElementId airTerminalId,
	ElementId ductCurveId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **airTerminalId** (`Autodesk.Revit.DB.ElementId`) - The air terminal id.
- **ductCurveId** (`Autodesk.Revit.DB.ElementId`) - The duct curve id.

## Returns
True if connection succeeds, false otherwise.

## Remarks
The current location of the air terminal will be projected to the duct centerline, and if the point can be successfully projected,
 the air terminal will be placed on the most suitable face of the duct.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The familyinstance is not air terminal.
 -or-
 The element is not duct curve.
 -or-
 The air terminal already has physical connection.
 -or-
 The air terminal connector origin doesn't project within the center line of the duct.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

