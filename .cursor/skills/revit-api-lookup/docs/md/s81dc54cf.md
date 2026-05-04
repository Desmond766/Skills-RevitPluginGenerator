---
kind: method
id: M:Autodesk.Revit.DB.Group.UngroupMembers
source: html/086b03c7-6a46-a825-1cae-9739a7819d4f.htm
---
# Autodesk.Revit.DB.Group.UngroupMembers Method

Ungroups the group.

## Syntax (C#)
```csharp
public ICollection<ElementId> UngroupMembers()
```

## Returns
If successful, the ids of the members of group are returned.

## Remarks
Removes all the members from the group and deletes the group. Note that the reference to this group object will become invalid once this method
is called.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown if the group cannot be ungrouped.

