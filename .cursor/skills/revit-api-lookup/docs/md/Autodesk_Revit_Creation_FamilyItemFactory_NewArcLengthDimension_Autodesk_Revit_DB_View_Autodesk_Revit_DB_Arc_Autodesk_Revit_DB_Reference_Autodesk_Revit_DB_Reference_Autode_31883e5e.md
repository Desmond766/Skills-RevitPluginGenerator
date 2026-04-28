---
kind: method
id: M:Autodesk.Revit.Creation.FamilyItemFactory.NewArcLengthDimension(Autodesk.Revit.DB.View,Autodesk.Revit.DB.Arc,Autodesk.Revit.DB.Reference,Autodesk.Revit.DB.Reference,Autodesk.Revit.DB.Reference)
source: html/a33279db-ba00-7cb7-1cea-9f4eac33b747.htm
---
# Autodesk.Revit.Creation.FamilyItemFactory.NewArcLengthDimension Method

Creates a new arc length dimension object using the default dimension type.

## Syntax (C#)
```csharp
public Dimension NewArcLengthDimension(
	View view,
	Arc arc,
	Reference arcRef,
	Reference firstRef,
	Reference secondRef
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

## Returns
If creation was successful the new arc length dimension is returned, 
otherwise an exception with failure information will be thrown.

## Remarks
The currently user set default style is used for the created dimension.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when any input argument is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the argument arcRef/ref1/ref2 is invalid.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the creation failed.

