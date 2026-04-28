---
kind: method
id: M:Autodesk.Revit.DB.Document.PublishCoordinates(Autodesk.Revit.DB.LinkElementId)
zh: 文档、文件
source: html/04419593-f258-dc77-b18a-24a29733b75f.htm
---
# Autodesk.Revit.DB.Document.PublishCoordinates Method

**中文**: 文档、文件

Publish coordinates to the specified ProjectLocation of the link instance.

## Syntax (C#)
```csharp
public void PublishCoordinates(
	LinkElementId locationId
)
```

## Parameters
- **locationId** (`Autodesk.Revit.DB.LinkElementId`) - The ElementId of the ProjectLocation in the
 linked document, to which the transform would be published to.

## Remarks
The host project's True North and shared origin are recorded in the linked project, based on the current position of the linked instance.
 This location is now named in both the host project and the linked project. More than one position of the link can be recorded. When you publish shared coordinates from a host Revit project to a linked DWG, this changes the linked DWG. The origin of the host Revit
 project's shared coordinate system becomes the origin of a new User Coordinate System (UCS) in the DWG file. The Y axis of the new UCS corresponds
 to the host project's True North. You can name the UCS when you publish coordinates. It is not recommended that you change this name after
 publishing coordinates. Note: Currently, only RevitLinkInstance is supported. DWG link instance, which is
 ImportInstance is not supported now. Passing in an locationId that points to an ImportInstance
 would result an ArgumentException .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - locationId does not contain a valid linkInstanceId.
 -or-
 Only RevitLinkInstance is supported through API for publish coordinates.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This Document is not a project document.
 -or-
 This Document is in an edit mode.
 -or-
 Attempting to publish shared coordinates to a cloud based link which is treated as read-only.
 -or-
 Failed to publish coordinates to the specified ProjectLocation of the link instance.
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

