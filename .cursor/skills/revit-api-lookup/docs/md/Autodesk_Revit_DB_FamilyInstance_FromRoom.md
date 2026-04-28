---
kind: property
id: P:Autodesk.Revit.DB.FamilyInstance.FromRoom
zh: 族实例
source: html/d6658841-da29-ead4-049b-3036cbd4951a.htm
---
# Autodesk.Revit.DB.FamilyInstance.FromRoom Property

**中文**: 族实例

The "From Room" set for the door or window in the last phase of the project.

## Syntax (C#)
```csharp
public Room FromRoom { get; }
```

## Remarks
Revit automatically calculates the "From Room" for a given door or window. This is the default shown when creating a door or window
schedule and adding the "From Room" properties. The user can opt to swap the "From Room" and "To Room" values via the schedule if they choose.
The method FlipFromToRoom () () () also can be used to swap the values.

