---
kind: property
id: P:Autodesk.Revit.DB.BuiltInFailures.RoomFailures.RoomsInSameRegionSpaces
source: html/6e5bceec-5c87-f083-bd4d-12fa7ba78383.htm
---
# Autodesk.Revit.DB.BuiltInFailures.RoomFailures.RoomsInSameRegionSpaces Property

Multiple [Room] are in the same enclosed region. The correct area and perimeter will be assigned to one [Room] and the others will display "Redundant [Room]." You should separate the regions, delete the extra [Room], or move them into different regions.

## Syntax (C#)
```csharp
public static FailureDefinitionId RoomsInSameRegionSpaces { get; }
```

