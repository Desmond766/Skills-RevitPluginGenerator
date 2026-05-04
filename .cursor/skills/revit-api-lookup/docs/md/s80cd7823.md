---
kind: method
id: M:Autodesk.Revit.DB.TemporaryGraphicsManager.UpdateControl(System.Int32,Autodesk.Revit.DB.InCanvasControlData)
source: html/eaf9c597-4b7f-7f92-c43c-0adebc5ef068.htm
---
# Autodesk.Revit.DB.TemporaryGraphicsManager.UpdateControl Method

Updates the in-canvas control identified by the unique index.

## Syntax (C#)
```csharp
public void UpdateControl(
	int index,
	InCanvasControlData data
)
```

## Parameters
- **index** (`System.Int32`) - Unique index of the control to be updated.
- **data** (`Autodesk.Revit.DB.InCanvasControlData`) - data to generate in-canvas control appearance.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - index is out of range of TemporaryGraphicsManager managed objects, or the indexed object has been removed from the document.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Failed to load the image from specified path.

