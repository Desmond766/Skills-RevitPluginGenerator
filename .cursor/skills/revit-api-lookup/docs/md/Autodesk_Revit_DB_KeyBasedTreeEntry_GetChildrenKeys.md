---
kind: method
id: M:Autodesk.Revit.DB.KeyBasedTreeEntry.GetChildrenKeys
source: html/f3bfae7c-ab5a-41ec-8f10-e1fdab0383ef.htm
---
# Autodesk.Revit.DB.KeyBasedTreeEntry.GetChildrenKeys Method

Gets a collection containing the keys of all children entry objects from this entry.

## Syntax (C#)
```csharp
public IList<string> GetChildrenKeys()
```

## Returns
The collection containing the keys of all children entry objects from this entry.

## Remarks
To look up the entry object corresponding to the child keys using KeyBasedTreeEntries.FindEntry().

