---
kind: method
id: M:Autodesk.Revit.Creation.FamilyItemFactory.NewAngularDimension(Autodesk.Revit.DB.View,Autodesk.Revit.DB.Arc,Autodesk.Revit.DB.Reference,Autodesk.Revit.DB.Reference)
source: html/4f50396a-b9aa-7cfd-2c6f-70b7354ea4a9.htm
---
# Autodesk.Revit.Creation.FamilyItemFactory.NewAngularDimension Method

Creates a new angular dimension object using the default dimension type.

## Syntax (C#)
```csharp
public Dimension NewAngularDimension(
	View view,
	Arc arc,
	Reference firstRef,
	Reference secondRef
)
```

## Parameters
- **view** (`Autodesk.Revit.DB.View`) - The view in which the dimension is to be visible.
- **arc** (`Autodesk.Revit.DB.Arc`) - The extension arc of the dimension.
- **firstRef** (`Autodesk.Revit.DB.Reference`) - The first geometric reference to which the dimension is to be bound.
The reference must be perpendicular to the extension arc.
- **secondRef** (`Autodesk.Revit.DB.Reference`) - The second geometric reference to which the dimension is to be bound.
The reference must be perpendicular to the extension arc.

## Returns
If creation was successful the new angular dimension is returned, 
otherwise an exception with failure information will be thrown.

## Remarks
The currently user set default style is used for the created dimension.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when any input argument is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the argument is invalid.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the creation failed.

