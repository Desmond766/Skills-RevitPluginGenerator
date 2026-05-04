---
kind: method
id: M:Autodesk.Revit.DB.ColorFillSchemeEntry.CanSetValue(System.Double)
source: html/4aa0e494-8709-42ce-2a0a-a5c96a847f2d.htm
---
# Autodesk.Revit.DB.ColorFillSchemeEntry.CanSetValue Method

Checks whether StorageType of entry is Double and the value is no less than 0.0.

## Syntax (C#)
```csharp
public bool CanSetValue(
	double value
)
```

## Parameters
- **value** (`System.Double`) - New Double value.

## Returns
True if StorageType of the entry is Double and the value is finite, false otherwise.

