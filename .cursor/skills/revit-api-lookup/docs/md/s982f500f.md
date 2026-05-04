---
kind: method
id: M:Autodesk.Revit.DB.FabricationPart.CreateHanger(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.FabricationServiceButton,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.Connector,System.Double,System.Boolean)
source: html/9e3e7333-0662-57d9-e6c9-4c477ff652bd.htm
---
# Autodesk.Revit.DB.FabricationPart.CreateHanger Method

Creates a hanger on the fabrication part.

## Syntax (C#)
```csharp
public static FabricationPart CreateHanger(
	Document document,
	FabricationServiceButton button,
	ElementId hostId,
	Connector hostConnector,
	double distance,
	bool attachToStructure
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **button** (`Autodesk.Revit.DB.FabricationServiceButton`) - The fabrication service button to use. It finds the matching condition automatically if the button has multiple condition.
- **hostId** (`Autodesk.Revit.DB.ElementId`) - The host part id. The host should be one horizontal straight part.
- **hostConnector** (`Autodesk.Revit.DB.Connector`) - The connector of the host.
- **distance** (`System.Double`) - The distance from the input connector of the host part. Units are in feet (ft).
- **attachToStructure** (`System.Boolean`) - Attach to the nearest structural element. The structural element might be one of Floor/Roof/Stair/Structure Framing.

## Returns
The newly-created fabrication hanger.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Hangers may only be placed on straight horizontal fabrication segments and some kind of fittings.
 -or-
 Invalid fabrication service button.
 -or-
 The distance is out of range.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - cannot place hanger on the host.

