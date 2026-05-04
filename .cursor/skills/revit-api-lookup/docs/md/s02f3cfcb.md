---
kind: property
id: P:Autodesk.Revit.DB.GroupType.Groups
source: html/e16f237c-0055-ba0e-d6ee-5d8182fcfabd.htm
---
# Autodesk.Revit.DB.GroupType.Groups Property

Retrieve a set of all the groups that have this type.

## Syntax (C#)
```csharp
public GroupSet Groups { get; }
```

## Returns
A set of group objects that all share this group type.

## Remarks
All groups returned by this property belong to this group type. A groups type can be
changed by using the GroupType property on the group object, in which case it will no longer
belong to this type but it will belong to the new type instead.

