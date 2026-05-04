---
kind: method
id: M:Autodesk.Revit.DB.FabricationService.IsPaletteExcluded(System.Int32)
source: html/a19ff9d5-04f1-dc18-d591-66f6f9c9bfa0.htm
---
# Autodesk.Revit.DB.FabricationService.IsPaletteExcluded Method

Get whether a service palette is excluded from being used by the Route and Fill, Design to Fabrication, or Multi Point Routing commands. The default configuration values may be overridden by SetServicePaletteExclusions.

## Syntax (C#)
```csharp
public bool IsPaletteExcluded(
	int paletteIndex
)
```

## Parameters
- **paletteIndex** (`System.Int32`) - The index of the palete.

## Returns
Returns true if the palette indexed by paletteIndex is currently to be excluded.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The index paletteIndex is not larger or equal to 0 and less than PaletteCount.

