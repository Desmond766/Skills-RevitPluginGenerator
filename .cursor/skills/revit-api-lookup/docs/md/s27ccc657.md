---
kind: method
id: M:Autodesk.Revit.DB.CompoundStructure.GetNumberOfShellLayers(Autodesk.Revit.DB.ShellLayerType)
source: html/68e04211-03ea-f0c6-50d5-b38fee4e7536.htm
---
# Autodesk.Revit.DB.CompoundStructure.GetNumberOfShellLayers Method

Retrieves the number of interior or exterior shell layers.

## Syntax (C#)
```csharp
public int GetNumberOfShellLayers(
	ShellLayerType shellLayerType
)
```

## Parameters
- **shellLayerType** (`Autodesk.Revit.DB.ShellLayerType`) - If ShellLayerType.Exterior return the number of exterior shell layers (or top shell layers for a roof, floor, or ceiling type).
 If ShellLayerType.Interior return the number of interior shell layers (or bottom shell layers for a roof, floor, or ceiling type).

## Returns
The number of shell layers in the interior or exterior shell, as specified by shellLayerType.

## Remarks
There will always be at least one core layer, i.e. one layer which is not a shell layer. You can change the shell/core layer
 boundary using SetNumberOfShellLayers(ShellLayerType, Int32) .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

