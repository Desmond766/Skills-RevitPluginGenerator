---
kind: method
id: M:Autodesk.Revit.DB.ColorFillSchemeEntry.CanSetValue(Autodesk.Revit.DB.ElementId)
source: html/51c317a7-8664-a7f8-324f-c705f6542b82.htm
---
# Autodesk.Revit.DB.ColorFillSchemeEntry.CanSetValue Method

Checks whether StorageType of entry is ElementId.

## Syntax (C#)
```csharp
public bool CanSetValue(
	ElementId value
)
```

## Parameters
- **value** (`Autodesk.Revit.DB.ElementId`) - New ElementId value.

## Returns
True if StorageType of the entry is ElementId and the entry, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

