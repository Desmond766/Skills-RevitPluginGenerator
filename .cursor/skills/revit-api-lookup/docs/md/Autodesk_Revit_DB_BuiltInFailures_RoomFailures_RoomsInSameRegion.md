---
kind: property
id: P:Autodesk.Revit.DB.BuiltInFailures.RoomFailures.RoomsInSameRegion
source: html/b37ffa39-c5b3-c7d5-b510-13c718cefa09.htm
---
# Autodesk.Revit.DB.BuiltInFailures.RoomFailures.RoomsInSameRegion Property

Multiple [Room] are in the same enclosed region. The correct area and perimeter will be assigned to one [Room] and the others will display "Redundant [Room]." You should separate the regions, delete the extra [Room], or move them into different regions.

## Syntax (C#)
```csharp
public static FailureDefinitionId RoomsInSameRegion { get; }
```

