---
kind: property
id: P:Autodesk.Revit.DB.BuiltInFailures.RoomFailures.OptionConflictInLinkRoomOverlapOption
source: html/2b855aff-0da4-486e-fc20-ec493ccd6798.htm
---
# Autodesk.Revit.DB.BuiltInFailures.RoomFailures.OptionConflictInLinkRoomOverlapOption Property

Option conflict between rooms in the Revit link '[Link Instance Name]'.\nA room in the Revit link's option '[Option #1 Name in Link]' overlaps a room in the Revit link's option '[Option #2 Name in Link]'.\nTo resolve the issue, open the Revit link file for editing, and delete the duplicate room or use room separation lines to divide the space in the main model.

## Syntax (C#)
```csharp
public static FailureDefinitionId OptionConflictInLinkRoomOverlapOption { get; }
```

