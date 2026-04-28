---
kind: method
id: M:Autodesk.Revit.Creation.ItemFactoryBase.NewDimension(Autodesk.Revit.DB.View,Autodesk.Revit.DB.Line,Autodesk.Revit.DB.ReferenceArray,Autodesk.Revit.DB.DimensionType)
source: html/475aab91-19d3-5884-d3eb-18dfc0d4004f.htm
---
# Autodesk.Revit.Creation.ItemFactoryBase.NewDimension Method

Creates a new linear dimension object using the specified dimension style.

## Syntax (C#)
```csharp
public Dimension NewDimension(
	View view,
	Line line,
	ReferenceArray references,
	DimensionType dimensionType
)
```

## Parameters
- **view** (`Autodesk.Revit.DB.View`) - The view in which the dimension is to be visible.
The view must be Nothing nullptr a null reference ( Nothing in Visual Basic) if the document is in [!:Autodesk::Revit::DB::SketchEditScope] .
- **line** (`Autodesk.Revit.DB.Line`) - The line drawn for the dimension.
- **references** (`Autodesk.Revit.DB.ReferenceArray`) - An array of geometric references to which the dimension is to be bound.
- **dimensionType** (`Autodesk.Revit.DB.DimensionType`) - The dimension style to be used for the dimension.

## Returns
If successful a new dimension object, otherwise Nothing nullptr a null reference ( Nothing in Visual Basic) .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when references are not geometric references.

