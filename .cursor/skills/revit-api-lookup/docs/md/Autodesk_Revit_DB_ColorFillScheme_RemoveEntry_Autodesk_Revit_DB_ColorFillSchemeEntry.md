---
kind: method
id: M:Autodesk.Revit.DB.ColorFillScheme.RemoveEntry(Autodesk.Revit.DB.ColorFillSchemeEntry)
source: html/e7441d50-0e17-21be-8ff6-aadadacad417.htm
---
# Autodesk.Revit.DB.ColorFillScheme.RemoveEntry Method

Removes an entry whose parameter value is the same as the input from the scheme

## Syntax (C#)
```csharp
public void RemoveEntry(
	ColorFillSchemeEntry entry
)
```

## Parameters
- **entry** (`Autodesk.Revit.DB.ColorFillSchemeEntry`) - The entry to remove.

## Remarks
The entry can not be removed if it is in use.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The entry cannot be removed from the scheme.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

