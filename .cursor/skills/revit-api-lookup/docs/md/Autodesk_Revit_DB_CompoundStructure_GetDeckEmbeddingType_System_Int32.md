---
kind: method
id: M:Autodesk.Revit.DB.CompoundStructure.GetDeckEmbeddingType(System.Int32)
source: html/bb52f22b-39b0-72ae-cb2f-4504eac02e9d.htm
---
# Autodesk.Revit.DB.CompoundStructure.GetDeckEmbeddingType Method

Retrieves the deck embedding type used for the specified structural deck.

## Syntax (C#)
```csharp
public StructDeckEmbeddingType GetDeckEmbeddingType(
	int layerIdx
)
```

## Parameters
- **layerIdx** (`System.Int32`) - Index of a layer in the CompoundStructure.

## Returns
The embedding type of the structural deck associated to the specified layer. Invalid if it is not a structural deck.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The layer index is out of range.

