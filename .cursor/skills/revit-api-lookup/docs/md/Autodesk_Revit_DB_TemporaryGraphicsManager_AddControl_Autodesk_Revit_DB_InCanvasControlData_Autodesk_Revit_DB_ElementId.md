---
kind: method
id: M:Autodesk.Revit.DB.TemporaryGraphicsManager.AddControl(Autodesk.Revit.DB.InCanvasControlData,Autodesk.Revit.DB.ElementId)
source: html/dbe10b60-8a28-50b9-c7d5-91628e8fe630.htm
---
# Autodesk.Revit.DB.TemporaryGraphicsManager.AddControl Method

Creates an in-canvas control.

## Syntax (C#)
```csharp
public int AddControl(
	InCanvasControlData data,
	ElementId ownerViewId
)
```

## Parameters
- **data** (`Autodesk.Revit.DB.InCanvasControlData`) - Data to generate in-canvas control appearance.
- **ownerViewId** (`Autodesk.Revit.DB.ElementId`) - The view in which the control appears. It will show in all views if the id is invalidElementId.

## Returns
Unique index of control for future references.

## Remarks
This method can perform drawing an image (supplied by the caller) as an in-canvas control in the view(s). The control can react on click
 by invoking a callback defined in [!:Autodesk::Revit::UI::ITemporaryGraphicsHandler::OnClick(TemporaryGraphicsCommandData)] .
 The caller can use the returned index to update the control (changing image/location), delete and change visibility (hide/unhide) in
 response to any events later.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The ownerViewId provided is not an id of a view.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Failed to load the image from specified path.

