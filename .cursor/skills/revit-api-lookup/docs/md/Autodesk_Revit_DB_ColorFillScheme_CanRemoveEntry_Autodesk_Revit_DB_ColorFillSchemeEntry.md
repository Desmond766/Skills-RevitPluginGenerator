---
kind: method
id: M:Autodesk.Revit.DB.ColorFillScheme.CanRemoveEntry(Autodesk.Revit.DB.ColorFillSchemeEntry)
source: html/d19264f1-e9f1-462f-f2c3-7f4ae9f2c9d0.htm
---
# Autodesk.Revit.DB.ColorFillScheme.CanRemoveEntry Method

Checks whether entry can be removed from the scheme.

## Syntax (C#)
```csharp
public bool CanRemoveEntry(
	ColorFillSchemeEntry entry
)
```

## Parameters
- **entry** (`Autodesk.Revit.DB.ColorFillSchemeEntry`) - The entry to remove.

## Returns
Returns true if entry can be removed from the scheme, false otherwise.

## Remarks
An entry cannot be removed if it is in use or does not exist in the scheme.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

