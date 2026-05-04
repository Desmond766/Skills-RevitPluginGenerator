---
kind: method
id: M:Autodesk.Revit.Creation.FamilyItemFactory.NewLinearDimension(Autodesk.Revit.DB.View,Autodesk.Revit.DB.Line,Autodesk.Revit.DB.ReferenceArray)
source: html/903cf519-f35c-8af0-8918-68ab387db1e8.htm
---
# Autodesk.Revit.Creation.FamilyItemFactory.NewLinearDimension Method

Generate a new linear dimension object using the default dimension type.

## Syntax (C#)
```csharp
public Dimension NewLinearDimension(
	View view,
	Line line,
	ReferenceArray references
)
```

## Parameters
- **view** (`Autodesk.Revit.DB.View`) - The view in which the dimension is to be visible.
- **line** (`Autodesk.Revit.DB.Line`) - The extension line of the dimension.
- **references** (`Autodesk.Revit.DB.ReferenceArray`) - An array of geometric references to which the dimension is to be bound.
You must supply at least two references, and all references supplied must be parallel to each other 
and perpendicular to the extension line.

## Returns
If creation was successful the new linear dimension is returned, 
otherwise an exception with failure information will be thrown.

## Remarks
The currently user set default style is used for the created dimension.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when any input argument is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the argument "references" is invalid.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the creation failed.

