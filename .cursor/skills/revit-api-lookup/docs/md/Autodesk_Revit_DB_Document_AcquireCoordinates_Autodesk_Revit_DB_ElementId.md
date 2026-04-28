---
kind: method
id: M:Autodesk.Revit.DB.Document.AcquireCoordinates(Autodesk.Revit.DB.ElementId)
zh: 文档、文件
source: html/ecc5f396-6aa4-ffbb-32df-b9a20e82b7d5.htm
---
# Autodesk.Revit.DB.Document.AcquireCoordinates Method

**中文**: 文档、文件

Acquires coordinates from the specified link instance.

## Syntax (C#)
```csharp
public void AcquireCoordinates(
	ElementId linkInstanceId
)
```

## Parameters
- **linkInstanceId** (`Autodesk.Revit.DB.ElementId`) - The ElementId of the link instance (such as
 RevitLinkInstance or ImportInstance )
 from which the coordinates would be acquired.

## Remarks
When you acquire coordinates from the linked model, the shared coordinates of the linked model become the
 shared coordinates of the host model, based on the position of the linked model instance in the host model.
 There is no change to the host model's internal coordinates. The host model also acquires True North from the linked model. The origin of the linked model's shared
 coordinates becomes the origin of the host model's shared coordinates. When a Revit model acquires coordinates from a linked DWG file, the World Coordinate System (WCS) of the
 selected linked DWG file becomes the shared coordinate system of the host Revit model, based on the position
 of the linked DWG instance. The Y axis of the DWG becomes True North, and the origin of the DWG becomes the
 origin of the shared coordinate system of the Revit model. On acquiring coordinates from a geo-referenced model, the geolocation information will be pulled from the linked
 model to the host model. Unlike UI operation Acquire Coordinates, calling the API would always overwrite the geolocation information in the
 host model even if it is different from the one in the linked model, or the linked model has empty geolocation information
 (in which case the geolocation information in the host model would be removed).

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The element linkInstanceId does not exist in the document
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This Document is not a project document.
 -or-
 This Document is in an edit mode.
 -or-
 The coordinate system of the selected model are the same as the host model.
 -or-
 Cannot acquire coordinates from a model placed multiple times.
 -or-
 Failed to acquire coordinates from the link instance.
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

