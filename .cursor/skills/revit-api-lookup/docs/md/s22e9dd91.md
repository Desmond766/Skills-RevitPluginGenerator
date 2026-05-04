---
kind: method
id: M:Autodesk.Revit.Creation.FamilyItemFactory.NewDiameterDimension(Autodesk.Revit.DB.View,Autodesk.Revit.DB.Reference,Autodesk.Revit.DB.XYZ)
source: html/ca8e0ebd-1287-33a6-b2f0-2e9180ccf208.htm
---
# Autodesk.Revit.Creation.FamilyItemFactory.NewDiameterDimension Method

Creates a new diameter dimension object using the default dimension type.

## Syntax (C#)
```csharp
public Dimension NewDiameterDimension(
	View view,
	Reference arcRef,
	XYZ origin
)
```

## Parameters
- **view** (`Autodesk.Revit.DB.View`) - The view in which the dimension is to be visible.
- **arcRef** (`Autodesk.Revit.DB.Reference`) - Geometric reference of the arc to which the dimension is to be bound.
- **origin** (`Autodesk.Revit.DB.XYZ`) - The point where the witness line of the diameter dimension will lie.

## Returns
If creation was successful the new diameter dimension is returned, 
otherwise an exception with failure information will be thrown.

## Remarks
The currently user set default style is used for the created dimension.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when any input argument is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the argument arcRef is invalid.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the creation failed.

