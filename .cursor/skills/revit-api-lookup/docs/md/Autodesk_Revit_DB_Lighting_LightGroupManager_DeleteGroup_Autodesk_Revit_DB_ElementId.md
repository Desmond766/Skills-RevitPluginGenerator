---
kind: method
id: M:Autodesk.Revit.DB.Lighting.LightGroupManager.DeleteGroup(Autodesk.Revit.DB.ElementId)
source: html/64437c97-488a-d75f-6159-01be84f93ba5.htm
---
# Autodesk.Revit.DB.Lighting.LightGroupManager.DeleteGroup Method

Remove the given LightGroup object from the set of LightGroup objects

## Syntax (C#)
```csharp
public void DeleteGroup(
	ElementId groupId
)
```

## Parameters
- **groupId** (`Autodesk.Revit.DB.ElementId`) - The Id of the LightGroup object to remove

## Remarks
Note that only the group is deleted, not the lights contained in the group
 The lights will still exist but will not be in a group any longer

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given element Id does not correspond to a light group
 -or-
 The LightGroup is not contained by this LightGroupManager
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

