---
kind: method
id: M:Autodesk.Revit.DB.Mechanical.ZoneEquipment.GetAssociatedZoneEquipment(Autodesk.Revit.DB.Document,System.Collections.Generic.ISet{Autodesk.Revit.DB.ElementId})
source: html/68d30140-93f9-9956-2d31-84b3c7b45af8.htm
---
# Autodesk.Revit.DB.Mechanical.ZoneEquipment.GetAssociatedZoneEquipment Method

Gets the associated zone equipment of all specified analytical spaces.

## Syntax (C#)
```csharp
public static ISet<ElementId> GetAssociatedZoneEquipment(
	Document document,
	ISet<ElementId> spaces
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document where the analytical spaces and zone equipment exist.
- **spaces** (`System.Collections.Generic.ISet < ElementId >`) - The specified analytical spaces.

## Returns
All associated zone equipment, either explicitly assigned or implicitly assigned via system-zone.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

