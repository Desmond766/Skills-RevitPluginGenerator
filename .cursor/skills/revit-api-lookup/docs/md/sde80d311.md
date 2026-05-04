---
kind: method
id: M:Autodesk.Revit.DB.ElementTransformUtils.GetTransformFromViewToView(Autodesk.Revit.DB.View,Autodesk.Revit.DB.View)
source: html/d28d5afd-6784-90be-4f6b-7bc35b997e3a.htm
---
# Autodesk.Revit.DB.ElementTransformUtils.GetTransformFromViewToView Method

Returns a transformation that is applied to elements when copying from one view to another view.

## Syntax (C#)
```csharp
public static Transform GetTransformFromViewToView(
	View sourceView,
	View destinationView
)
```

## Parameters
- **sourceView** (`Autodesk.Revit.DB.View`) - The source view
- **destinationView** (`Autodesk.Revit.DB.View`) - The destination view

## Returns
The transformation from source view to destination view.

## Remarks
Both source and destination views must be 2D graphics views capable of drawing details and view-specific elements (floor and ceiling plans, elevations, sections, drafting views.)
 The result is a transformation needed to copy an element from drawing plane of the source view to the drawing plane of the destination view.
 The destination view can be in the same document as the source view.
 The destination view can be the same as the source view.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The specified view cannot be used as a source or destination for copying elements between two views.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

