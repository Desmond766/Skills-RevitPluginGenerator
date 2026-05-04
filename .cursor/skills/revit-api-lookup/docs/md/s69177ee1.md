---
kind: method
id: M:Autodesk.Revit.DB.CompoundStructure.GetLayerFunction(System.Int32)
source: html/7c681a04-b21d-99f2-76c1-d3415aa06576.htm
---
# Autodesk.Revit.DB.CompoundStructure.GetLayerFunction Method

Retrieves the function of the specified layer.

## Syntax (C#)
```csharp
public MaterialFunctionAssignment GetLayerFunction(
	int layerIdx
)
```

## Parameters
- **layerIdx** (`System.Int32`) - Index of a layer in the CompoundStructure.

## Returns
The function of the layer.

## Remarks
The function determines how this layer interacts with the layers of other elements to which it is joined.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The layer index is out of range.

