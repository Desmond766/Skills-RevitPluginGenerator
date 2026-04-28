---
kind: method
id: M:Autodesk.Revit.Creation.FamilyItemFactory.NewModelText(System.String,Autodesk.Revit.DB.ModelTextType,Autodesk.Revit.DB.SketchPlane,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.HorizontalAlign,System.Double)
source: html/f7a49b85-9b18-8546-6935-d76b784c9cfa.htm
---
# Autodesk.Revit.Creation.FamilyItemFactory.NewModelText Method

Create a model text in the Autodesk Revit family document.

## Syntax (C#)
```csharp
public ModelText NewModelText(
	string text,
	ModelTextType modelTextType,
	SketchPlane sketchPlane,
	XYZ position,
	HorizontalAlign horizontalAlign,
	double depth
)
```

## Parameters
- **text** (`System.String`) - The text to be displayed.
- **modelTextType** (`Autodesk.Revit.DB.ModelTextType`) - The type of model text. If this parameter is Nothing nullptr a null reference ( Nothing in Visual Basic) , the default type will be used.
- **sketchPlane** (`Autodesk.Revit.DB.SketchPlane`) - The sketch plane of the model text. The direction of model text is determined by the normal of the sketch plane.
To extrude in the other direction set the depth value to negative.
- **position** (`Autodesk.Revit.DB.XYZ`) - The position of the model text. The position must lie in the sketch plane.
- **horizontalAlign** (`Autodesk.Revit.DB.HorizontalAlign`) - The horizontal alignment.
- **depth** (`System.Double`) - The depth of the model text.

## Returns
If successful, the newly created model text is returned, otherwise an
exception with error information will be thrown.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input argument text, sketchPlane or XYZ is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when input argument text is an empty string.
Thrown when input argument horizontalAlign or depth is invalid.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when model text creation failed.

