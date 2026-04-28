---
kind: method
id: M:Autodesk.Revit.DB.Architecture.MultistoryStairs.GetAllStairsIds
source: html/a66792ff-4d73-afc7-8df6-ae8733cf69de.htm
---
# Autodesk.Revit.DB.Architecture.MultistoryStairs.GetAllStairsIds Method

Gets the ids of all the stairs in this multistory stairs.

## Syntax (C#)
```csharp
public ISet<ElementId> GetAllStairsIds()
```

## Returns
The ids of the stairs elements that govern groups of stairs, and the stairs elements that represent individual stairs.

## Remarks
Stairs elements returned by this method will either be members of groups of identical stairs instances which share the same level height, or individual Stairs instances which are not connected to a group with the same level height.
 Use IsPinned(Stairs) to identify if a Stairs is a member of a group or not.

