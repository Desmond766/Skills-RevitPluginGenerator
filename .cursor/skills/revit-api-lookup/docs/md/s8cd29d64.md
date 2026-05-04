---
kind: method
id: M:Autodesk.Revit.DB.ColorFillScheme.AreEntriesConsistentWithScheme(System.Collections.Generic.IList{Autodesk.Revit.DB.ColorFillSchemeEntry})
source: html/a368c926-4d60-0fde-4e21-0a7c815db691.htm
---
# Autodesk.Revit.DB.ColorFillScheme.AreEntriesConsistentWithScheme Method

Checks whether the entries can be set to the scheme or not.

## Syntax (C#)
```csharp
public EntryAndSchemeConsistency AreEntriesConsistentWithScheme(
	IList<ColorFillSchemeEntry> entries
)
```

## Parameters
- **entries** (`System.Collections.Generic.IList < ColorFillSchemeEntry >`) - The entries to check.

## Returns
The state of the entries and scheme consistency.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

