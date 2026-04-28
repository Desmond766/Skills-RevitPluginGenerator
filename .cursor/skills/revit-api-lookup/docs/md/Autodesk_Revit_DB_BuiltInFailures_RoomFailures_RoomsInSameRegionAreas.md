---
kind: property
id: P:Autodesk.Revit.DB.BuiltInFailures.RoomFailures.RoomsInSameRegionAreas
source: html/1458218b-908a-8b69-cf09-fad368f2c30b.htm
---
# Autodesk.Revit.DB.BuiltInFailures.RoomFailures.RoomsInSameRegionAreas Property

Multiple [Room] are in the same enclosed region. The correct area and perimeter will be assigned to one [Room] and the others will display "Redundant [Room]." You should separate the regions, delete the extra [Room], or move them into different regions.

## Syntax (C#)
```csharp
public static FailureDefinitionId RoomsInSameRegionAreas { get; }
```

