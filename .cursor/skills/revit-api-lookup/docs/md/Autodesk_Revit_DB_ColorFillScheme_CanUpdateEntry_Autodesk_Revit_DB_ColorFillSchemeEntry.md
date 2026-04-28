---
kind: method
id: M:Autodesk.Revit.DB.ColorFillScheme.CanUpdateEntry(Autodesk.Revit.DB.ColorFillSchemeEntry)
source: html/f7f0bdd9-8076-69f1-bf81-776c40f42a22.htm
---
# Autodesk.Revit.DB.ColorFillScheme.CanUpdateEntry Method

Checks whether entry exists in the scheme and not the same as input one.

## Syntax (C#)
```csharp
public bool CanUpdateEntry(
	ColorFillSchemeEntry entry
)
```

## Parameters
- **entry** (`Autodesk.Revit.DB.ColorFillSchemeEntry`) - The entry to be updated.

## Returns
Returns true if entry exist in scheme and not the same as input one, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

