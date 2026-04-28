---
kind: method
id: M:Autodesk.Revit.DB.CompoundStructure.SetNumberOfShellLayers(Autodesk.Revit.DB.ShellLayerType,System.Int32)
source: html/8b8ea4e3-e697-6176-92c0-dc2687723a71.htm
---
# Autodesk.Revit.DB.CompoundStructure.SetNumberOfShellLayers Method

Sets the number of interior or exterior shell layers.

## Syntax (C#)
```csharp
public void SetNumberOfShellLayers(
	ShellLayerType shellLayerType,
	int numLayers
)
```

## Parameters
- **shellLayerType** (`Autodesk.Revit.DB.ShellLayerType`) - If ShellLayerType.Exterior set the number of exterior shell layers (or top shell layers for a roof, floor, or ceiling type).
 If ShellLayerType.Interior set the number of interior shell layers (or bottom shell layers for a roof, floor, or ceiling type).
- **numLayers** (`System.Int32`) - The number of layers to be in the specified shell.

## Remarks
There must be at least one core layer, i.e. one layer which is not a shell layer.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - Number of shell layers is negative.
 -or-
 A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.ArgumentsInconsistentException** - Too many shell layers: there must be at least one core layer.

