---
kind: method
id: M:Autodesk.Revit.Creation.FamilyItemFactory.NewRadialDimension(Autodesk.Revit.DB.View,Autodesk.Revit.DB.Reference,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.DimensionType)
source: html/1c180a55-fc93-fd5d-7551-337bcd45689a.htm
---
# Autodesk.Revit.Creation.FamilyItemFactory.NewRadialDimension Method

Generate a new radial dimension object using a specified dimension type.

## Syntax (C#)
```csharp
public Dimension NewRadialDimension(
	View view,
	Reference arcRef,
	XYZ origin,
	DimensionType dimensionType
)
```

## Parameters
- **view** (`Autodesk.Revit.DB.View`) - The view in which the dimension is to be visible.
- **arcRef** (`Autodesk.Revit.DB.Reference`) - Geometric reference of the arc to which the dimension is to be bound.
- **origin** (`Autodesk.Revit.DB.XYZ`) - The point where the witness line of the radial dimension will lie.
- **dimensionType** (`Autodesk.Revit.DB.DimensionType`) - The dimension style to be used for the dimension.

## Returns
If creation was successful the new arc length dimension is returned, 
otherwise an exception with failure information will be thrown.

## Remarks
The dimension will be created on default place.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when any input argument is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the argument arcRef/dimensionType is invalid.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the creation failed.

