---
kind: property
id: P:Autodesk.Revit.DB.FamilyInstance.ToRoom
zh: 族实例
source: html/939e9c7b-072a-7be9-105f-64e1aa1f3a97.htm
---
# Autodesk.Revit.DB.FamilyInstance.ToRoom Property

**中文**: 族实例

The "To Room" set for the door or window in the last phase of the project.

## Syntax (C#)
```csharp
public Room ToRoom { get; }
```

## Remarks
Revit automatically calculates the "To Room" for a given door or window. This is the default shown when creating a door or window
schedule and adding the "To Room" properties. The user can opt to swap the "From Room" and "To Room" values via the schedule if they choose.
The method FlipFromToRoom () () () also can be used to swap the values.

