---
kind: property
id: P:Autodesk.Revit.DB.BuiltInFailures.RoomFailures.RoomsInSameRegionLoadAreas
source: html/de7cd931-8db1-b191-566f-558113e4c7a2.htm
---
# Autodesk.Revit.DB.BuiltInFailures.RoomFailures.RoomsInSameRegionLoadAreas Property

Multiple [Room] are in the same enclosed region. The correct area and perimeter will be assigned to one [Room] and the others will display "Redundant [Room]." You should separate the regions, delete the extra [Room], or move them into different regions.

## Syntax (C#)
```csharp
public static FailureDefinitionId RoomsInSameRegionLoadAreas { get; }
```

