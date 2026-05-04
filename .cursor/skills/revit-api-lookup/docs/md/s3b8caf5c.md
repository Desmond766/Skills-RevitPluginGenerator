---
kind: method
id: M:Autodesk.Revit.DB.MultiReferenceAnnotation.IsLinearFixedDimensionDirectionValid(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.MultiReferenceAnnotationOptions)
source: html/15ea4e06-bb36-6328-e456-6c4528766a23.htm
---
# Autodesk.Revit.DB.MultiReferenceAnnotation.IsLinearFixedDimensionDirectionValid Method

If the DimensionStyleType is LinearFixed, this function verifies that the dimension line direction
 matches either the view's vertical or horizontal direction.

## Syntax (C#)
```csharp
public static bool IsLinearFixedDimensionDirectionValid(
	Document document,
	ElementId viewId,
	MultiReferenceAnnotationOptions options
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document for the view.
- **viewId** (`Autodesk.Revit.DB.ElementId`) - The view in which the dimension line direction will be tested.
- **options** (`Autodesk.Revit.DB.MultiReferenceAnnotationOptions`) - Options containing the DimensionStyleType and dimension line direction to test.

## Returns
True if the DimensionStyleType is LinearFixed and the dimension line direction can be used in the view.
 True if the DimensionStyleType is not LinearFixed.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

