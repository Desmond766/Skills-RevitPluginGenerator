---
kind: method
id: M:Autodesk.Revit.DB.FabricationService.GetButtonCount(System.Int32)
source: html/c80b99e4-736f-e357-2d3c-efe0ed2fa91d.htm
---
# Autodesk.Revit.DB.FabricationService.GetButtonCount Method

Gets the number of buttons for a given palette in the service.

## Syntax (C#)
```csharp
public int GetButtonCount(
	int palette
)
```

## Parameters
- **palette** (`System.Int32`) - The index of the palette

## Returns
The number of buttons.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The index palette is not larger or equal to 0 and less than PaletteCount.

