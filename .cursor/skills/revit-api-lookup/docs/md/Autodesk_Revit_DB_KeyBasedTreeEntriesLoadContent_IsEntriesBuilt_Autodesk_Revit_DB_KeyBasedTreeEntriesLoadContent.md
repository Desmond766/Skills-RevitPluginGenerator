---
kind: method
id: M:Autodesk.Revit.DB.KeyBasedTreeEntriesLoadContent.IsEntriesBuilt(Autodesk.Revit.DB.KeyBasedTreeEntriesLoadContent)
source: html/1689029e-a383-3e34-204f-86b72b20d4cf.htm
---
# Autodesk.Revit.DB.KeyBasedTreeEntriesLoadContent.IsEntriesBuilt Method

Verifies that the KeyBasedTreeEntries object owned by a KeyBasedTreeEntriesLoadContent object is built.

## Syntax (C#)
```csharp
public static bool IsEntriesBuilt(
	KeyBasedTreeEntriesLoadContent content
)
```

## Parameters
- **content** (`Autodesk.Revit.DB.KeyBasedTreeEntriesLoadContent`) - The KeyBasedTreeEntriesLoadContent object to be checked.

## Returns
True if the KeyBasedTreeEntries object is built already, otherwise false.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

