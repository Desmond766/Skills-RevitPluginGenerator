---
kind: method
id: M:Autodesk.Revit.DB.CompoundStructure.CreateSingleLayerCompoundStructure(System.Double,Autodesk.Revit.DB.MaterialFunctionAssignment,System.Double,Autodesk.Revit.DB.ElementId)
source: html/d1a7a3ba-717c-a939-2161-dc22a94b8824.htm
---
# Autodesk.Revit.DB.CompoundStructure.CreateSingleLayerCompoundStructure Method

Creates a vertically compound CompoundStructure with one layer.

## Syntax (C#)
```csharp
public static CompoundStructure CreateSingleLayerCompoundStructure(
	double sampleHeight,
	MaterialFunctionAssignment layerFunction,
	double width,
	ElementId materialId
)
```

## Parameters
- **sampleHeight** (`System.Double`) - The sample height of this vertically compound structure.
- **layerFunction** (`Autodesk.Revit.DB.MaterialFunctionAssignment`) - The function of the single layer.
- **width** (`System.Double`) - The width of the single layer.
- **materialId** (`Autodesk.Revit.DB.ElementId`) - The ElementId of the material for the single layer.

## Returns
The newly created compound structure.

## Remarks
It is not verified that materialId corresponds to a valid MaterialElem.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given value for sampleHeight must be greater than 0 and no more than 30000 feet.
 -or-
 The given value for width must be greater than 0 and no more than 30000 feet.
 -or-
 A value passed for an enumeration argument is not a member of that enumeration

