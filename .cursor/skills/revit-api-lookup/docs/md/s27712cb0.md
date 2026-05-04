---
kind: method
id: M:Autodesk.Revit.DB.CompoundStructure.IsCoreLayer(System.Int32)
source: html/b71b0e57-fcdc-2b51-0418-7317ee135c3c.htm
---
# Autodesk.Revit.DB.CompoundStructure.IsCoreLayer Method

Checks if the specified layer is a core layer.

## Syntax (C#)
```csharp
public bool IsCoreLayer(
	int layerIdx
)
```

## Parameters
- **layerIdx** (`System.Int32`) - The index of a layer in this CompoundStructure.

## Returns
Returns true if the layer is within the core layer boundary, false if it is in the interior or exterior shell layers.

## Remarks
You can change the shell/core layer boundary using SetNumberOfShellLayers(ShellLayerType, Int32) .

