---
kind: method
id: M:Autodesk.Revit.Creation.ItemFactoryBase.NewGroup(System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId})
source: html/8bdb7337-7063-cff8-28a4-958464f2fa5b.htm
---
# Autodesk.Revit.Creation.ItemFactoryBase.NewGroup Method

Creates a new type of group.

## Syntax (C#)
```csharp
public Group NewGroup(
	ICollection<ElementId> elementIds
)
```

## Parameters
- **elementIds** (`System.Collections.Generic.ICollection < ElementId >`) - A set of elements which will be made into the new group.

## Returns
A new instance of a group containing the elements specified.

## Remarks
The new group may contain more members than just the set input to this method. Elements
which are closely connected with the inputs (such as sketch and sketch plane) will also be added to
the group. Initially the group will have a generic name, such as Group 1. This can be changed by
changing the name of the group type as follows: newGroup.GroupType.Name = newName . If a newly-created element is being added to a group, calling document.Regenerate() may be needed to avoid
a warning visible in the UI that the group has changed outside group edit mode.

