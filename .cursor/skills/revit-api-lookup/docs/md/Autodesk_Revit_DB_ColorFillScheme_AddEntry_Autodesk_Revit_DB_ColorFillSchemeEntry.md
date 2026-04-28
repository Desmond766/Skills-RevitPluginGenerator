---
kind: method
id: M:Autodesk.Revit.DB.ColorFillScheme.AddEntry(Autodesk.Revit.DB.ColorFillSchemeEntry)
source: html/8c7f6d04-66ab-19ef-d00c-445aa4570f82.htm
---
# Autodesk.Revit.DB.ColorFillScheme.AddEntry Method

Adds new entry to the scheme.

## Syntax (C#)
```csharp
public void AddEntry(
	ColorFillSchemeEntry entry
)
```

## Parameters
- **entry** (`Autodesk.Revit.DB.ColorFillSchemeEntry`)

## Remarks
To make sure that entry can be added to the scheme, call IsEntryConsistentWithScheme(ColorFillSchemeEntry) first.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - There already exists an entry with the same value in the scheme.
 -or-
 The entry value is out of range.
 -or-
 The scheme and the entry have different parameter storage type.
 -or-
 The fill pattern id is not valid for scheme.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

