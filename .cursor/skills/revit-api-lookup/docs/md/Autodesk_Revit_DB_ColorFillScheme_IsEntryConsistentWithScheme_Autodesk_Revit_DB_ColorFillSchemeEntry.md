---
kind: method
id: M:Autodesk.Revit.DB.ColorFillScheme.IsEntryConsistentWithScheme(Autodesk.Revit.DB.ColorFillSchemeEntry)
source: html/887cb0a0-2ad3-9a2c-8f46-c86e404539f8.htm
---
# Autodesk.Revit.DB.ColorFillScheme.IsEntryConsistentWithScheme Method

Checks whether an entry can be added to the scheme or not.

## Syntax (C#)
```csharp
public EntryAndSchemeConsistency IsEntryConsistentWithScheme(
	ColorFillSchemeEntry entry
)
```

## Parameters
- **entry** (`Autodesk.Revit.DB.ColorFillSchemeEntry`) - The entry to check.

## Returns
The state of entry and scheme consistency.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

