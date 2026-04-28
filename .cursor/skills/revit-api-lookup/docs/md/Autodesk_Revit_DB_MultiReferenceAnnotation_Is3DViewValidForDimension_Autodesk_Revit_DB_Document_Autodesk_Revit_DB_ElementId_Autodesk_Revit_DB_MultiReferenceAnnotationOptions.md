---
kind: method
id: M:Autodesk.Revit.DB.MultiReferenceAnnotation.Is3DViewValidForDimension(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.MultiReferenceAnnotationOptions)
source: html/4674a228-8bcd-1851-60af-65e91b221bad.htm
---
# Autodesk.Revit.DB.MultiReferenceAnnotation.Is3DViewValidForDimension Method

If the DimensionStyle is LinearFixed, it cannot be created in a 3D View.
 If the DimensionStyle is Linear, it cannot be created in a 3D View if the view direction is perpendicular to the current work plane normal.
 Returns true if the ownerViewId is not a 3D view.

## Syntax (C#)
```csharp
public static bool Is3DViewValidForDimension(
	Document document,
	ElementId ownerViewId,
	MultiReferenceAnnotationOptions options
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document for the multi-reference annotation.
- **ownerViewId** (`Autodesk.Revit.DB.ElementId`) - The view in which the multi-reference annotation will appear.
- **options** (`Autodesk.Revit.DB.MultiReferenceAnnotationOptions`) - Options containing the references which the dimension will witness.

## Returns
True if the view is suitable for placing the MultiReferenceAnnotation.
 False otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

