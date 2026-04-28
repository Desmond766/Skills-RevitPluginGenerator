---
kind: method
id: M:Autodesk.Revit.DB.ColorFillScheme.UpdateEntry(Autodesk.Revit.DB.ColorFillSchemeEntry)
source: html/47fece43-de9a-e343-62be-e6907c584933.htm
---
# Autodesk.Revit.DB.ColorFillScheme.UpdateEntry Method

Updates the scheme entry with the same parameter value as the input entry.

## Syntax (C#)
```csharp
public void UpdateEntry(
	ColorFillSchemeEntry entry
)
```

## Parameters
- **entry** (`Autodesk.Revit.DB.ColorFillSchemeEntry`) - The entry to be updated.

## Remarks
The following entry fields can be updated: Color FillPattenId Caption IsVisible /

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The entry does not exist or the same as input one.
 -or-
 The entry does not exist or all the updating fields are the same as existing one.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

