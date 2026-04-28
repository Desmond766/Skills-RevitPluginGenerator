---
kind: method
id: M:Autodesk.Revit.Creation.FamilyItemFactory.NewLinearDimension(Autodesk.Revit.DB.View,Autodesk.Revit.DB.Line,Autodesk.Revit.DB.ReferenceArray,Autodesk.Revit.DB.DimensionType)
source: html/df445b5a-99bb-8603-3107-4bddd36a1c0f.htm
---
# Autodesk.Revit.Creation.FamilyItemFactory.NewLinearDimension Method

Creates a new linear dimension object using the specified dimension type.

## Syntax (C#)
```csharp
public Dimension NewLinearDimension(
	View view,
	Line line,
	ReferenceArray references,
	DimensionType dimensionType
)
```

## Parameters
- **view** (`Autodesk.Revit.DB.View`) - The view in which the dimension is to be visible.
- **line** (`Autodesk.Revit.DB.Line`) - The extension line of the dimension.
- **references** (`Autodesk.Revit.DB.ReferenceArray`) - An array of geometric references to which the dimension is to be bound.
You must supply at least two references, and all references supplied must be parallel to each other 
and perpendicular to the extension line.
- **dimensionType** (`Autodesk.Revit.DB.DimensionType`) - The dimension style to be used for the dimension.

## Returns
If creation was successful the new linear dimension is returned, 
otherwise an exception with failure information will be thrown.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when any input argument is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the argument is invalid.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the creation failed.

