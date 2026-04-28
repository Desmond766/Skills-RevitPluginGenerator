---
kind: method
id: M:Autodesk.Revit.DB.Mechanical.ZoneEquipment.GetAssociatedZoneEquipment(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/3668167f-4abc-763c-45b2-24cf02545dea.htm
---
# Autodesk.Revit.DB.Mechanical.ZoneEquipment.GetAssociatedZoneEquipment Method

Gets the associated zone equipment of the specified analytical space.

## Syntax (C#)
```csharp
public static ISet<ElementId> GetAssociatedZoneEquipment(
	Document document,
	ElementId spaceElementId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document where the analytical spaces and zone equipment exist.
- **spaceElementId** (`Autodesk.Revit.DB.ElementId`) - The specified analytical spaces.

## Returns
All associated zone equipment, either explicitly assigned or implicitly assigned via system-zone.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

