---
kind: method
id: M:Autodesk.Revit.DB.Group.GetMemberIds
source: html/42a745b8-dc2e-ef06-0ad3-7e4c775eea9d.htm
---
# Autodesk.Revit.DB.Group.GetMemberIds Method

Retrieves all the member ElementIds of the group.

## Syntax (C#)
```csharp
public IList<ElementId> GetMemberIds()
```

## Returns
An ordered list of the members within the group. The order of this
list can be used to match members between other instances of the group.

