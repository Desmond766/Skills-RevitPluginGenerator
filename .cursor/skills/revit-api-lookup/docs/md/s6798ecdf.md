---
kind: method
id: M:Autodesk.Revit.DB.ViewSheet.GetCurrentRevision
zh: 图纸
source: html/9184aa1a-1f29-2f1f-9557-bafb176a4aa0.htm
---
# Autodesk.Revit.DB.ViewSheet.GetCurrentRevision Method

**中文**: 图纸

Returns the most recent numbered Revision shown on this ViewSheet.

## Syntax (C#)
```csharp
public ElementId GetCurrentRevision()
```

## Returns
The Id of the most recent numbered Revision shown on this ViewSheet or InvalidElementId if none are shown.

## Remarks
If the most recent Revision is not issued, Revit will typically use it as the default Revision for
 RevisionClouds placed on this ViewSheet. InvalidElementId will be returned if no Revisions are present.
 Revisions with RevisionNumberType.None will not be returned.

