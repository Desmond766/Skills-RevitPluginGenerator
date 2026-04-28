---
kind: method
id: M:Autodesk.Revit.DB.CompoundStructure.CanLayerBeVariable(System.Int32)
source: html/b2a3d8c3-39e0-d924-2047-32015ba66075.htm
---
# Autodesk.Revit.DB.CompoundStructure.CanLayerBeVariable Method

Identifies if the input layer can be designated as a variable thickness layer.

## Syntax (C#)
```csharp
public bool CanLayerBeVariable(
	int variableLayerIndex
)
```

## Parameters
- **variableLayerIndex** (`System.Int32`) - Index of a layer in the CompoundStructure.

## Returns
True if the input layer may be a variable thickness layer and false otherwise.

## Remarks
A layer whose layer function is StructuralDeck may not be designated as a variable layer.

