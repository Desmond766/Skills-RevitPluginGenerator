---
kind: method
id: M:Autodesk.Revit.DB.CompoundStructure.SetLayers(System.Collections.Generic.IList{Autodesk.Revit.DB.CompoundStructureLayer})
source: html/0392b682-451d-5399-54b5-44373ce941c6.htm
---
# Autodesk.Revit.DB.CompoundStructure.SetLayers Method

Completely resets this CompoundStructure and applies a new set of layers.

## Syntax (C#)
```csharp
public void SetLayers(
	IList<CompoundStructureLayer> layers
)
```

## Parameters
- **layers** (`System.Collections.Generic.IList < CompoundStructureLayer >`) - The layers to be set.

## Remarks
This function will replace all existing layers with the contents of the input. This provides a full
 reset for the CompoundStructure. Therefore:
 All layers will be marked as Core layers, and any settings related to Shell layers (such as GetFirstCoreLayerIndex () () () ,
 GetLastCoreLayerIndex () () () or GetCoreBoundaryLayerIndex(ShellLayerType) ) will be modified accordingly. Because all layers will be set as Core layers, the value of LayerCapFlag will be ignored (and set to true) automatically. The VariableLayerIndex will be unset. The StructuralMaterialIndex will be unset. The compound structure will be set to be vertically homogeneous .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

