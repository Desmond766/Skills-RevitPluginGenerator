---
kind: method
id: M:Autodesk.Revit.DB.CompoundStructure.SetLayerFunction(System.Int32,Autodesk.Revit.DB.MaterialFunctionAssignment)
source: html/afd19099-cc37-1cd3-80c8-e89df914e5e5.htm
---
# Autodesk.Revit.DB.CompoundStructure.SetLayerFunction Method

Sets the function of the specified layer.

## Syntax (C#)
```csharp
public void SetLayerFunction(
	int layerIdx,
	MaterialFunctionAssignment function
)
```

## Parameters
- **layerIdx** (`System.Int32`) - Index of a layer in the CompoundStructure.
- **function** (`Autodesk.Revit.DB.MaterialFunctionAssignment`) - The function of the layer.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The layer index is out of range.
 -or-
 A value passed for an enumeration argument is not a member of that enumeration

