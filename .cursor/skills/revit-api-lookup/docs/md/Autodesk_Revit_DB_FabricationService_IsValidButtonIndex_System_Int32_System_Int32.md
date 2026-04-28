---
kind: method
id: M:Autodesk.Revit.DB.FabricationService.IsValidButtonIndex(System.Int32,System.Int32)
source: html/1936cceb-ffc4-9631-2d90-28e937bf2578.htm
---
# Autodesk.Revit.DB.FabricationService.IsValidButtonIndex Method

Validates the button index.

## Syntax (C#)
```csharp
public bool IsValidButtonIndex(
	int paletteIndex,
	int buttonIndex
)
```

## Parameters
- **paletteIndex** (`System.Int32`) - The palette index.
- **buttonIndex** (`System.Int32`) - The button index to check.

## Returns
True if larger or equal to 0 and less than PaletteCount.

