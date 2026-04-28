---
kind: method
id: M:Autodesk.Revit.DB.CompoundStructure.CreateSingleLayerCompoundStructure(Autodesk.Revit.DB.MaterialFunctionAssignment,System.Double,Autodesk.Revit.DB.ElementId)
source: html/daabdba6-a85c-aed1-927a-7ff9e519489f.htm
---
# Autodesk.Revit.DB.CompoundStructure.CreateSingleLayerCompoundStructure Method

Creates a CompoundStructure containing a single layer.

## Syntax (C#)
```csharp
public static CompoundStructure CreateSingleLayerCompoundStructure(
	MaterialFunctionAssignment layerFunction,
	double width,
	ElementId materialId
)
```

## Parameters
- **layerFunction** (`Autodesk.Revit.DB.MaterialFunctionAssignment`) - The function of the single layer.
- **width** (`System.Double`) - The width of the single layer.
- **materialId** (`Autodesk.Revit.DB.ElementId`) - The ElementId of the material for the single layer.

## Returns
The newly created compound structure.

## Remarks
It is not verified that materialId corresponds to a valid Material element.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given value for width must be greater than 0 and no more than 30000 feet.
 -or-
 A value passed for an enumeration argument is not a member of that enumeration

