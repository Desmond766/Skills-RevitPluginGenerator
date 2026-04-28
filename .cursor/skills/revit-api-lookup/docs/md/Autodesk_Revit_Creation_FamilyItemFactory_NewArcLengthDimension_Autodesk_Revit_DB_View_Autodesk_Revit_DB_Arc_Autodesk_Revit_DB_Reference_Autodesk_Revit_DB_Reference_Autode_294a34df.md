---
kind: method
id: M:Autodesk.Revit.Creation.FamilyItemFactory.NewArcLengthDimension(Autodesk.Revit.DB.View,Autodesk.Revit.DB.Arc,Autodesk.Revit.DB.Reference,Autodesk.Revit.DB.Reference,Autodesk.Revit.DB.Reference,Autodesk.Revit.DB.DimensionType)
source: html/1126fc7c-46e1-b24e-3581-c88f51766a21.htm
---
# Autodesk.Revit.Creation.FamilyItemFactory.NewArcLengthDimension Method

Creates a new arc length dimension object using the specified dimension type.

## Syntax (C#)
```csharp
public Dimension NewArcLengthDimension(
	View view,
	Arc arc,
	Reference arcRef,
	Reference firstRef,
	Reference secondRef,
	DimensionType dimensionType
)
```

## Parameters
- **view** (`Autodesk.Revit.DB.View`) - The view in which the dimension is to be visible.
- **arc** (`Autodesk.Revit.DB.Arc`) - The extension arc of the dimension.
- **arcRef** (`Autodesk.Revit.DB.Reference`) - Geometric reference of the arc to which the dimension is to be bound.
This reference must be parallel to the extension arc.
- **firstRef** (`Autodesk.Revit.DB.Reference`) - The first geometric reference to which the dimension is to be bound.
This reference must intersect the arcRef reference.
- **secondRef** (`Autodesk.Revit.DB.Reference`) - The second geometric reference to which the dimension is to be bound.
This reference must intersect the arcRef reference.
- **dimensionType** (`Autodesk.Revit.DB.DimensionType`) - The dimension style to be used for the dimension.

## Returns
If creation was successful the new arc length dimension is returned, 
otherwise an exception with failure information will be thrown.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when any input argument is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the argument arcRef/ref1/ref2/dimensionType is invalid.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the creation failed.

