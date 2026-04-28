---
kind: method
id: M:Autodesk.Revit.DB.FabricationService.GetPaletteName(System.Int32)
source: html/0d12d23a-a3f0-48e6-fc70-be50d0ffeb23.htm
---
# Autodesk.Revit.DB.FabricationService.GetPaletteName Method

Gets the name of a palette based on palette index.

## Syntax (C#)
```csharp
public string GetPaletteName(
	int palette
)
```

## Parameters
- **palette** (`System.Int32`) - The index of the palette.

## Returns
The name of the palette.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The index palette is not larger or equal to 0 and less than PaletteCount.

