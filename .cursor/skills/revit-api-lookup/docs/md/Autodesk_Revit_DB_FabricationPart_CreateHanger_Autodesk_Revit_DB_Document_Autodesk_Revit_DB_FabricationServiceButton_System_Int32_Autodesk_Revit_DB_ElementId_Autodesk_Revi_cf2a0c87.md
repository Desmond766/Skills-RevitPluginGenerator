---
kind: method
id: M:Autodesk.Revit.DB.FabricationPart.CreateHanger(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.FabricationServiceButton,System.Int32,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.Connector,System.Double,System.Boolean)
source: html/3a1e5eb4-e997-6d95-4c9c-3614aba235d7.htm
---
# Autodesk.Revit.DB.FabricationPart.CreateHanger Method

Creates a hanger on the fabrication part.

## Syntax (C#)
```csharp
public static FabricationPart CreateHanger(
	Document document,
	FabricationServiceButton button,
	int condition,
	ElementId hostId,
	Connector hostConnector,
	double distance,
	bool attachToStructure
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **button** (`Autodesk.Revit.DB.FabricationServiceButton`) - The fabrication service button to use.
- **condition** (`System.Int32`) - The condition index. If the button has multiple conditions.
- **hostId** (`Autodesk.Revit.DB.ElementId`) - The host part id. The host should be one horizontal straight part.
- **hostConnector** (`Autodesk.Revit.DB.Connector`) - The connector of the host.
- **distance** (`System.Double`) - The distance from the input connector of the host part. Units are in feet (ft).
- **attachToStructure** (`System.Boolean`) - Attach to the nearest structural element. The structural element might be one of Floor/Roof/Stair/Structural Framing.

## Returns
The newly-created fabrication hanger.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Hangers may only be placed on straight horizontal fabrication segments and some kind of fittings.
 -or-
 Invalid fabrication service button.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The index condition is not larger or equal to 0 and less than ConditionCount.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - the distance is out of range.
 -or-
 cannot find suitable fabrication part for the host.
 -or-
 cannot place hanger on the host.

