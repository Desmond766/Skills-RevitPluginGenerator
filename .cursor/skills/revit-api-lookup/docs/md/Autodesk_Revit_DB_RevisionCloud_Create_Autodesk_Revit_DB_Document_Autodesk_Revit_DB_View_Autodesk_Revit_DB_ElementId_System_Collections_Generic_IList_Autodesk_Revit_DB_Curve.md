---
kind: method
id: M:Autodesk.Revit.DB.RevisionCloud.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.View,Autodesk.Revit.DB.ElementId,System.Collections.Generic.IList{Autodesk.Revit.DB.Curve})
zh: 创建、新建、生成、建立、新增
source: html/090c0da6-db59-d1e6-5dcf-4335c531ee9f.htm
---
# Autodesk.Revit.DB.RevisionCloud.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new RevisionCloud in the model.

## Syntax (C#)
```csharp
public static RevisionCloud Create(
	Document document,
	View view,
	ElementId revisionId,
	IList<Curve> curves
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document in which the RevisionCloud should be created.
- **view** (`Autodesk.Revit.DB.View`) - The View in which the RevisionCloud should appear.
- **revisionId** (`Autodesk.Revit.DB.ElementId`) - The Revision to associate with the new RevisionCloud.
- **curves** (`System.Collections.Generic.IList < Curve >`) - The curves that will form the RevisionCloud's sketch.

## Returns
The newly created RevisionCloud.

## Remarks
Creates a new RevisionCloud in the specified View. The new RevisionCloud will be associated with the specified Revision.
 RevisionClouds can only be created if the Revision has not yet been issued.
RevisionClouds can be created in most graphical Views, excepting 3D views and graphical column schedules. Unlike
 most other Elements, RevisionClouds can be created directly on a ViewSheet. RevisionClouds are created based on a series of sketched curves. There is no requirement that the curves form
 closed loops and self-intersections are also permitted. The curves will be automatically projected onto the appropriate
 plane for the View. The list of curves cannot be empty and any lines cannot be perpendicular to the View's plane.
 If the View is a model View, the coordinates specified for the curves will be interpreted in model space. If the View
 is a non-model View (such as a ViewSheet) then the coordinates will be interpreted in the View's space. The cloud graphics will be attached to the curves under the assumption that each curve is oriented in a clockwise direction.
 For lines, this means that the outside of the cloud is in the direction of the line's normal vector within the View's plane. Any closed loops should
 therefore be oriented clockwise to create the typical cloud shape.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - document is not a project document.
 -or-
 revisionId is not a valid Revision.
 -or-
 This operation cannot be performed because revisionId is an issued Revision.
 -or-
 view is not a View that can support RevisionClouds.
 -or-
 The provided Curves curves cannot be used as the basis for a RevisionCloud. Either the list is empty or
 one or more of the Curves could not be projected onto the View's plane.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

