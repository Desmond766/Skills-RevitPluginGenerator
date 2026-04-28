---
kind: method
id: M:Autodesk.Revit.DB.CompoundStructure.SetMaterialId(System.Int32,Autodesk.Revit.DB.ElementId)
source: html/19cb546b-1c9b-f658-7a66-4206af0b4b80.htm
---
# Autodesk.Revit.DB.CompoundStructure.SetMaterialId Method

Sets a material element for a specified layer.

## Syntax (C#)
```csharp
public void SetMaterialId(
	int layerIdx,
	ElementId materialId
)
```

## Parameters
- **layerIdx** (`System.Int32`) - Index of a layer in the CompoundStructure.
- **materialId** (`Autodesk.Revit.DB.ElementId`) - The ElementId of a Material element.

## Remarks
It is not verified that materialId corresponds to a valid Material element.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The layer index is out of range.

