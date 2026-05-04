---
kind: method
id: M:Autodesk.Revit.DB.Group.GetAvailableAttachedDetailGroupTypeIds
source: html/dd127374-e2c5-9c5e-3edd-c1b0ec60e30d.htm
---
# Autodesk.Revit.DB.Group.GetAvailableAttachedDetailGroupTypeIds Method

Returns the attached detail groups available for this group type.

## Syntax (C#)
```csharp
public ISet<ElementId> GetAvailableAttachedDetailGroupTypeIds()
```

## Returns
Returns the collection of attached detail group Ids that match this group's type.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The input group is not a model group and can therefore not have attached detail groups.

