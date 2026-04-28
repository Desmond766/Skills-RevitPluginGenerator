---
kind: method
id: M:Autodesk.Revit.DB.ImageInstance.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.View,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ImagePlacementOptions)
zh: 创建、新建、生成、建立、新增
source: html/0f4cd250-7925-6714-3e08-2bd7c0266252.htm
---
# Autodesk.Revit.DB.ImageInstance.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new ImageInstance element placed in a view.

## Syntax (C#)
```csharp
public static ImageInstance Create(
	Document document,
	View view,
	ElementId imageTypeId,
	ImagePlacementOptions placementOptions
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **view** (`Autodesk.Revit.DB.View`) - The view in which the image will be placed.
- **imageTypeId** (`Autodesk.Revit.DB.ElementId`) - The id of the ImageType element for this ImageInstance.
- **placementOptions** (`Autodesk.Revit.DB.ImagePlacementOptions`) - Options that specify where the ImageInstance should be placed.

## Returns
The new ImageInstance.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given view cannot contain ImageInstance elements
 -or-
 The given imageTypeId can not be used as a ImageType for ImageInstance elements
 -or-
 The given placementOptions specify a location that is more than 10 miles from the origin of the model.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

