---
kind: method
id: M:Autodesk.Revit.DB.ImageExportOptions.GetFileName(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/0f5a2275-9fcb-2d85-2ccc-0190dbb21b9b.htm
---
# Autodesk.Revit.DB.ImageExportOptions.GetFileName Method

Gets the file name that will be produced when exporting a view to an image.

## Syntax (C#)
```csharp
public static string GetFileName(
	Document aDoc,
	ElementId dbViewId
)
```

## Parameters
- **aDoc** (`Autodesk.Revit.DB.Document`) - The document that owns the view.
- **dbViewId** (`Autodesk.Revit.DB.ElementId`) - View which is to be exported as image.

## Returns
The generated exported image file name.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

