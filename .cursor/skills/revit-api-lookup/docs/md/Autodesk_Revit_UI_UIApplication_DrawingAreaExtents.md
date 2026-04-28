---
kind: property
id: P:Autodesk.Revit.UI.UIApplication.DrawingAreaExtents
source: html/f7d3b688-17bf-3652-360b-9443d23ff1c1.htm
---
# Autodesk.Revit.UI.UIApplication.DrawingAreaExtents Property

Get the rectangle that represents the screen pixel coordinates of drawing area.

## Syntax (C#)
```csharp
public virtual Rectangle DrawingAreaExtents { get; }
```

## Remarks
The drawing area of the Revit window displays views (and sheets and schedules) of projects. 
The size of drawing area restricts the max size of the view titles and windows, the value may be empty if modal browser is opened.
If there is no project opened, null will be returned.

