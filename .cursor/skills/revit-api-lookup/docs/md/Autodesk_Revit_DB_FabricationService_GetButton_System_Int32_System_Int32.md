---
kind: method
id: M:Autodesk.Revit.DB.FabricationService.GetButton(System.Int32,System.Int32)
source: html/a07bb5f7-6c08-3d6b-25ea-5891cc2dfc5e.htm
---
# Autodesk.Revit.DB.FabricationService.GetButton Method

Gets the service button for a given palette index and button index from the service.

## Syntax (C#)
```csharp
public FabricationServiceButton GetButton(
	int paletteIndex,
	int buttonIndex
)
```

## Parameters
- **paletteIndex** (`System.Int32`) - The palette index.
- **buttonIndex** (`System.Int32`) - The button index.

## Returns
The service button.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The index paletteIndex is not larger or equal to 0 and less than PaletteCount.

