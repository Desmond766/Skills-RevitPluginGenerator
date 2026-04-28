---
kind: method
id: M:Autodesk.Revit.DB.CompoundStructure.CanLayerBeStructuralMaterial(System.Int32)
source: html/68844a06-8e4c-2647-946e-13bb7f7b0816.htm
---
# Autodesk.Revit.DB.CompoundStructure.CanLayerBeStructuralMaterial Method

Identifies if the input layer can be designated as defining the structural material for this structure.

## Syntax (C#)
```csharp
public bool CanLayerBeStructuralMaterial(
	int layerIndex
)
```

## Parameters
- **layerIndex** (`System.Int32`) - Index of a layer in the CompoundStructure.

## Returns
True if the input layer may be used to define the structural material and false otherwise.

## Remarks
Only core layers may be designated as defining the structural material.

