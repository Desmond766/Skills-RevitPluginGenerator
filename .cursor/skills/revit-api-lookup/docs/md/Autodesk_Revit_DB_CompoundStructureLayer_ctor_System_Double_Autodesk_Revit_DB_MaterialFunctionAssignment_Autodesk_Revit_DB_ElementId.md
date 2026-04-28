---
kind: method
id: M:Autodesk.Revit.DB.CompoundStructureLayer.#ctor(System.Double,Autodesk.Revit.DB.MaterialFunctionAssignment,Autodesk.Revit.DB.ElementId)
source: html/90c2ea06-4e80-c8c0-dbde-1b3f831c2de5.htm
---
# Autodesk.Revit.DB.CompoundStructureLayer.#ctor Method

Creates a default compound structure layer based on the given width, function and material element id.

## Syntax (C#)
```csharp
public CompoundStructureLayer(
	double width,
	MaterialFunctionAssignment function,
	ElementId materialId
)
```

## Parameters
- **width** (`System.Double`) - The width of the layer.
- **function** (`Autodesk.Revit.DB.MaterialFunctionAssignment`) - The function of the layer.
- **materialId** (`Autodesk.Revit.DB.ElementId`) - The material element id of the layer.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

