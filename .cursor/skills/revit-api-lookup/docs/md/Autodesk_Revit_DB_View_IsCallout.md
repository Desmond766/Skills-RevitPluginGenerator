---
kind: property
id: P:Autodesk.Revit.DB.View.IsCallout
zh: 视图
source: html/153c2d69-0e32-a408-1a4f-bc886cb0d94f.htm
---
# Autodesk.Revit.DB.View.IsCallout Property

**中文**: 视图

Indicates if the view is a callout view.

## Syntax (C#)
```csharp
public bool IsCallout { get; }
```

## Remarks
Reference callouts are not treated as callout views.
 The view was created as a callout in its parent view but it may show as a section in orthogonal views.

