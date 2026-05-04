---
kind: method
id: M:Autodesk.Revit.Creation.ItemFactoryBase.NewDimension(Autodesk.Revit.DB.View,Autodesk.Revit.DB.Line,Autodesk.Revit.DB.ReferenceArray)
source: html/47b3977d-da93-e1a4-8bfa-f23a29e5c4c1.htm
---
# Autodesk.Revit.Creation.ItemFactoryBase.NewDimension Method

Creates a new linear dimension object using the default dimension style.

## Syntax (C#)
```csharp
public Dimension NewDimension(
	View view,
	Line line,
	ReferenceArray references
)
```

## Parameters
- **view** (`Autodesk.Revit.DB.View`) - The view in which the dimension is to be visible.
The view must be Nothing nullptr a null reference ( Nothing in Visual Basic) if the document is in [!:Autodesk::Revit::DB::SketchEditScope] .
- **line** (`Autodesk.Revit.DB.Line`) - The line drawn for the dimension.
- **references** (`Autodesk.Revit.DB.ReferenceArray`) - An array of geometric references to which the dimension is to be bound.

## Returns
If successful a new dimension object, otherwise Nothing nullptr a null reference ( Nothing in Visual Basic) .

## Remarks
The currently user set default style is used for the created dimension.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when references are not geometric references.

