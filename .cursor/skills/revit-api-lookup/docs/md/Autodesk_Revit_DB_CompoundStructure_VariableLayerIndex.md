---
kind: property
id: P:Autodesk.Revit.DB.CompoundStructure.VariableLayerIndex
source: html/e93ce781-df22-cc64-7ad8-70a0d6bc7707.htm
---
# Autodesk.Revit.DB.CompoundStructure.VariableLayerIndex Property

Indicates the index of the layer which is designated as variable.

## Syntax (C#)
```csharp
public int VariableLayerIndex { get; set; }
```

## Remarks
If the host object to which it is applied
 has an actual width that exceeds the total width of all layers, then all layers except the variable layer
 will be created with their specified width, and the variable layer will expand to take up the slack.
 Generally this is applicable for floors and roofs with shape edits applied. There can be only one variable layer.
 In the wall compound structure UI, when a layer is labeled 'variable' in the thickness column,
 that means it is assigned either to a non-rectangular region, or it means the layer is assigned to two different layers.
 Neither of those situations is what this method refers to.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The specified layer cannot be set to a variable layer.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The layer index is out of range.
 -or-
 When setting this property: The layer index is invalid.

