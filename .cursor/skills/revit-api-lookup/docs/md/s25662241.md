---
kind: method
id: M:Autodesk.Revit.DB.KeyBasedTreeEntriesLoadContent.AddEntry(Autodesk.Revit.DB.KeyBasedTreeEntry)
source: html/1c248f05-d3d2-66d7-c585-d1bc3e881f2d.htm
---
# Autodesk.Revit.DB.KeyBasedTreeEntriesLoadContent.AddEntry Method

Adds one KeyBasedTreeEntry to this KeyBasedTreeEntriesLoadContent, which is used to build a KeyBasedTreeEntries object by BuildEntries function.

## Syntax (C#)
```csharp
public bool AddEntry(
	KeyBasedTreeEntry entry
)
```

## Parameters
- **entry** (`Autodesk.Revit.DB.KeyBasedTreeEntry`) - The entry to be added.

## Returns
Returns true if an entry is added into the entry data set successfully,
 returns false if an entry fails to be added because this entry is invalid or a duplicate
 of one in the entry data set.

## Remarks
The entry will not be added if it is invalid or duplicate with the added entries.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The KeyBasedTreeEntry object is not appropriate to be added in this KeyBasedTreeEntriesLoadContent.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The KeyBasedTreeEntries object owned by this KeyBasedTreeEntriesLoadContent object is built already.
 Adding more KeyBasedTreeEntries as well as repeated building, is not supported.

