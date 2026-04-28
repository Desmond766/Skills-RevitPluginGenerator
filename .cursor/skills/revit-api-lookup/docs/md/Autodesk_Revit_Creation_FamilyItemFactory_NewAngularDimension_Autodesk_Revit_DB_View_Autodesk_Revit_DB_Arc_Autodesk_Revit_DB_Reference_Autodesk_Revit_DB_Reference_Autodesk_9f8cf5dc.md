---
kind: method
id: M:Autodesk.Revit.Creation.FamilyItemFactory.NewAngularDimension(Autodesk.Revit.DB.View,Autodesk.Revit.DB.Arc,Autodesk.Revit.DB.Reference,Autodesk.Revit.DB.Reference,Autodesk.Revit.DB.DimensionType)
source: html/b96c1843-be6d-3908-2157-8cd430ca31f1.htm
---
# Autodesk.Revit.Creation.FamilyItemFactory.NewAngularDimension Method

Creates a new angular dimension object using the specified dimension type.

## Syntax (C#)
```csharp
public Dimension NewAngularDimension(
	View view,
	Arc arc,
	Reference firstRef,
	Reference secondRef,
	DimensionType dimensionType
)
```

## Parameters
- **view** (`Autodesk.Revit.DB.View`) - The view in which the dimension is to be visible.
- **arc** (`Autodesk.Revit.DB.Arc`) - The extension arc of the dimension.
- **firstRef** (`Autodesk.Revit.DB.Reference`) - The first geometric reference to which the dimension is to be bound.
The reference must be perpendicular to the extension arc.
- **secondRef** (`Autodesk.Revit.DB.Reference`) - The second geometric reference to which the dimension is to be bound.
The reference must be perpendicular to the extension arc.
- **dimensionType** (`Autodesk.Revit.DB.DimensionType`) - The dimension style to be used for the dimension.

## Returns
If creation was successful the new angular dimension is returned, 
otherwise an exception with failure information will be thrown.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when any input argument is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the argument firstRef/secondRef/dimensionType is invalid.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the creation failed.

