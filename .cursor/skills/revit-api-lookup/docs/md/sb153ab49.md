---
kind: method
id: M:Autodesk.Revit.DB.KeyBasedTreeEntriesLoadResults.GetKeyBasedTreeEntryErrors(Autodesk.Revit.DB.KeyBasedTreeEntryErrorType)
source: html/0c106d01-5ef7-a7a9-41a0-d54327c727d4.htm
---
# Autodesk.Revit.DB.KeyBasedTreeEntriesLoadResults.GetKeyBasedTreeEntryErrors Method

Gets information about specific KeyBasedTreeEntry objects that could not be included in the KeyBasedTreeEntries
 object due to errors of a particular type.

## Syntax (C#)
```csharp
public IList<KeyBasedTreeEntryError> GetKeyBasedTreeEntryErrors(
	KeyBasedTreeEntryErrorType type
)
```

## Parameters
- **type** (`Autodesk.Revit.DB.KeyBasedTreeEntryErrorType`) - The type of KeyBasedTreeEntryError to be returned.

## Returns
An array of copies of the KeyBasedTreeEntryErrors contained in this object matching the type specified.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

