---
kind: method
id: M:Autodesk.Revit.DB.KeyBasedTreeEntriesLoadContent.CanAddEntry(Autodesk.Revit.DB.KeyBasedTreeEntry)
source: html/c0e29109-3a20-6860-4099-c09b976d0939.htm
---
# Autodesk.Revit.DB.KeyBasedTreeEntriesLoadContent.CanAddEntry Method

Verifies if the KeyBasedTreeEntry could be added in this KeyBasedTreeEntriesLoadContent.

## Syntax (C#)
```csharp
public bool CanAddEntry(
	KeyBasedTreeEntry entry
)
```

## Parameters
- **entry** (`Autodesk.Revit.DB.KeyBasedTreeEntry`) - The KeyBasedTreeEntry object to be checked.

## Returns
True if the KeyBasedTreeEntry could be added in, otherwise false.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

