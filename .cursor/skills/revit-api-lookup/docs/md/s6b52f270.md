---
kind: method
id: M:Autodesk.Revit.DB.CompoundStructure.IsLayerValid(System.Int32,Autodesk.Revit.DB.CompoundStructureLayer)
source: html/820dfece-50bc-df1c-4078-7ae07bdc35ca.htm
---
# Autodesk.Revit.DB.CompoundStructure.IsLayerValid Method

Verifies that the data in this layer is internally consistent.

## Syntax (C#)
```csharp
public bool IsLayerValid(
	int layerIdx,
	CompoundStructureLayer layer
)
```

## Parameters
- **layerIdx** (`System.Int32`) - The index of the layer in the compound structure to be set.
- **layer** (`Autodesk.Revit.DB.CompoundStructureLayer`) - The layer to be set.

## Returns
True if the layer is internally consistent, false if the layer is not internally consistent.

## Remarks
If the layer function is not Membrane or StructuralDeck, the width must be greater than zero.
 If the layer function is not StructuralDeck, then the deck embedding type must be Invalid, and the deck profile id must be InvalidElementId.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

