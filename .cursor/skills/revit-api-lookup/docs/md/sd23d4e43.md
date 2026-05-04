---
kind: method
id: M:Autodesk.Revit.DB.KeyBasedTreeEntriesLoadContent.BuildEntries
source: html/fb60dfd3-e356-dadb-49b0-f8516b8e73a8.htm
---
# Autodesk.Revit.DB.KeyBasedTreeEntriesLoadContent.BuildEntries Method

Builds a KeyBasedTreeEntries object.

## Syntax (C#)
```csharp
public void BuildEntries()
```

## Remarks
This method will take all the entries that have been added, create a KeyBasedTreeEntries object out of these entries,
 and also record possible errors that occurred while constructing this KeyBasedTreeEntries object.
 After this function is called, no more entries can be added. And repeated calling of this function is not allowed either.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The KeyBasedTreeEntries object owned by this KeyBasedTreeEntriesLoadContent object is built already.
 Adding more KeyBasedTreeEntries as well as repeated building, is not supported.

