---
kind: property
id: P:Autodesk.Revit.DB.StartingViewSettings.ViewId
source: html/dd5cd741-e211-9bb3-666c-ee056520c2d9.htm
---
# Autodesk.Revit.DB.StartingViewSettings.ViewId Property

Indicates the specific view that will be opened when the model is loaded. InvalidElementId indicates
 that no view has been specified. In that case, Revit will open the last views that were open at the
 time the file was saved.

## Syntax (C#)
```csharp
public ElementId ViewId { get; set; }
```

## Remarks
Note that InvalidElementId will cause Revit to open the same view it would have used
 in Revit 2011 and prior releases.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: viewId is not an acceptable starting view for this model.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

