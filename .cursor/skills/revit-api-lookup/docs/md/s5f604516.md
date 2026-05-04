---
kind: type
id: T:Autodesk.Revit.DB.RevisionCloud
source: html/43bdb2c4-2b9c-e3fa-4d6a-8c9970a9f7b6.htm
---
# Autodesk.Revit.DB.RevisionCloud

A RevisionCloud is a graphical "cloud" that can be displayed on a view or sheet to indicate where revisions in the model have occurred.

## Syntax (C#)
```csharp
public class RevisionCloud : Element
```

## Remarks
RevisionClouds are view specific and can be created in most graphical views, except 3D. Unlike most Elements, RevisionClouds may be added
 directly to a ViewSheet. Each RevisionCloud is associated with one Revision.
When a RevisionCloud is visible on a
 ViewSheet (either because it is directly placed on that ViewSheet or because it is visible in a View placed on the ViewSheet),
 any revision schedules displayed on the ViewSheet will automatically include the Revision associated with the RevisionCloud. Note also that when a RevisionCloud is created in a ViewLegend, it is treated as a legend representation of what a RevisionCloud
 looks like rather than as an actual indication of a change to the model. As a result, RevisionClouds in ViewLegends will not affect the contents
 of revision schedules. RevisionClouds are created from a collection of sketched curves. Each curve will have a series of "cloud bumps" drawn
 along it to form the appearance of a cloud. There is no requirement that the curves form closed loops.

