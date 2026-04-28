---
kind: method
id: M:Autodesk.Revit.DB.DatumPlane.CanBeVisibleInView(Autodesk.Revit.DB.View)
source: html/88545b41-8cd2-521a-748c-94967a66dc72.htm
---
# Autodesk.Revit.DB.DatumPlane.CanBeVisibleInView Method

Checks if the datum plane can be visible in the view.

## Syntax (C#)
```csharp
public bool CanBeVisibleInView(
	View view
)
```

## Parameters
- **view** (`Autodesk.Revit.DB.View`) - The view.

## Returns
True if visible, false otherwise.

## Remarks
This method determines if the orientation of the DatumPlane and View allows that the DatumPlane can be seen in the indicated view.
 It does not actually determine if the DatumPlane is visible, as many factors can affect the visibility of an element in a given view (for example, hiding the element).

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

