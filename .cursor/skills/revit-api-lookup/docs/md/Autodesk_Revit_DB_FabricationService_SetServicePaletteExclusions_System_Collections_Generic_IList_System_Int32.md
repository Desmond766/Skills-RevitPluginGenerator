---
kind: method
id: M:Autodesk.Revit.DB.FabricationService.SetServicePaletteExclusions(System.Collections.Generic.IList{System.Int32})
source: html/c00b14ba-4728-c10d-8c07-28244dc84dcb.htm
---
# Autodesk.Revit.DB.FabricationService.SetServicePaletteExclusions Method

Sets the service palette exclusions, used by Route and Fill or Design to Fabrication commands, for the current user and session only. This will alter them from the default configuration exclusions to only exclude those palettes passed.

## Syntax (C#)
```csharp
public bool SetServicePaletteExclusions(
	IList<int> excludedPalettes
)
```

## Parameters
- **excludedPalettes** (`System.Collections.Generic.IList < Int32 >`) - A list of service palette indexes to be excluded.

## Returns
Returns true if succeeded to set the exclusions to the specified palette(s).

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - Palette indices contains an index that is not larger or equal to 0 and less than PaletteCount.
- **Autodesk.Revit.Exceptions.DisabledDisciplineException** - None of the following disciplines is enabled: Mechanical Electrical Piping.

