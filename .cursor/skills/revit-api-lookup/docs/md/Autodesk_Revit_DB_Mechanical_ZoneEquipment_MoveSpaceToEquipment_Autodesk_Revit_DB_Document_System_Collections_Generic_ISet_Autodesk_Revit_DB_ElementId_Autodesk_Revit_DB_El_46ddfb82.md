---
kind: method
id: M:Autodesk.Revit.DB.Mechanical.ZoneEquipment.MoveSpaceToEquipment(Autodesk.Revit.DB.Document,System.Collections.Generic.ISet{Autodesk.Revit.DB.ElementId},Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
source: html/00929605-db3f-e79e-31f5-4edac720948b.htm
---
# Autodesk.Revit.DB.Mechanical.ZoneEquipment.MoveSpaceToEquipment Method

Moves the selected analytical spaces from the identified zone equipment to another target zone equipment.

## Syntax (C#)
```csharp
public static void MoveSpaceToEquipment(
	Document document,
	ISet<ElementId> analyticalSpaceSet,
	ElementId originalZoneEquipmentId,
	ElementId targetZoneEquipmentId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document where the zone equipment and the analytical spaces exist.
- **analyticalSpaceSet** (`System.Collections.Generic.ISet < ElementId >`) - The specified analytical spaces to move.
- **originalZoneEquipmentId** (`Autodesk.Revit.DB.ElementId`) - The original equipment where the analytical spaces will be removed. If passing invalidElementId, the existing zone equipment is not removed.
- **targetZoneEquipmentId** (`Autodesk.Revit.DB.ElementId`) - The target zone equipment where the analytical spaces will be associated. If passing invalidElementId, the analytical spaces will not be assigned to any new zone equipment.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

