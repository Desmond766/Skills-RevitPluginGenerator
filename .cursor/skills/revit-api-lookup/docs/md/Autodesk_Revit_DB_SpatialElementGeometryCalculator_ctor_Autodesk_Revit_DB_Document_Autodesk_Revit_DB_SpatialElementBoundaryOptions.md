---
kind: method
id: M:Autodesk.Revit.DB.SpatialElementGeometryCalculator.#ctor(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.SpatialElementBoundaryOptions)
source: html/f5c1f93b-7f1f-fa8e-2051-e67a361b0025.htm
---
# Autodesk.Revit.DB.SpatialElementGeometryCalculator.#ctor Method

Constructs a new calculator for the geometry of spatial elements.

## Syntax (C#)
```csharp
public SpatialElementGeometryCalculator(
	Document aDoc,
	SpatialElementBoundaryOptions options
)
```

## Parameters
- **aDoc** (`Autodesk.Revit.DB.Document`) - The document that contains the spatial elements.
- **options** (`Autodesk.Revit.DB.SpatialElementBoundaryOptions`) - The options to control the calculation rules.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - options is not valid. Only Finish and Center of SpatialElementBoundaryLocation are allowed.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

