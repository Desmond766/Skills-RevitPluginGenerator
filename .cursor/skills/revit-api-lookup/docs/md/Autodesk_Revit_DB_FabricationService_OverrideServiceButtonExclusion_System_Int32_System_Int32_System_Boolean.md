---
kind: method
id: M:Autodesk.Revit.DB.FabricationService.OverrideServiceButtonExclusion(System.Int32,System.Int32,System.Boolean)
source: html/5a0ce9ef-042c-def5-2d9a-c5f15e308040.htm
---
# Autodesk.Revit.DB.FabricationService.OverrideServiceButtonExclusion Method

Overrides the default service button exclusions, used by Route and Fill, Design to Fabrication, or Multi Point Routing for the current user and session only.

## Syntax (C#)
```csharp
public void OverrideServiceButtonExclusion(
	int paletteIndex,
	int buttonIndex,
	bool exclude
)
```

## Parameters
- **paletteIndex** (`System.Int32`) - The index of the service palette to exclude the service button from.
- **buttonIndex** (`System.Int32`) - The index of the service button to exclude.
- **exclude** (`System.Boolean`) - Pass true to exclude from being used by Route and Fill or Design to Fabrication.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The index paletteIndex is not larger or equal to 0 and less than PaletteCount.
- **Autodesk.Revit.Exceptions.DisabledDisciplineException** - None of the following disciplines is enabled: Mechanical Electrical Piping.

