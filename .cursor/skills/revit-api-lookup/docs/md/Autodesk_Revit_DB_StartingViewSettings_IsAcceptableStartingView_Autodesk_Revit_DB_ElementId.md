---
kind: method
id: M:Autodesk.Revit.DB.StartingViewSettings.IsAcceptableStartingView(Autodesk.Revit.DB.ElementId)
source: html/7118b9ba-d29e-78d2-9293-705de4726980.htm
---
# Autodesk.Revit.DB.StartingViewSettings.IsAcceptableStartingView Method

Checks whether the given Id is an acceptable starting view. InvalidElementId corresponds to "Last Viewed" and is therefore also acceptable.

## Syntax (C#)
```csharp
public bool IsAcceptableStartingView(
	ElementId viewId
)
```

## Parameters
- **viewId** (`Autodesk.Revit.DB.ElementId`) - The Id of the element to check.

## Returns
True if the view is acceptable, False if it is not.

## Remarks
Model views (such as plans, ceiling plans, sections, elevations, and 3d views) are acceptable.
 In addition, drafting views, sheets, legends, schedules, and graphical column schedules are generally acceptable.
 Special views such as the project browser, system navigator, reports, revision schedules, internal schedules,
 sheets that are not actually in use, and views that belong to a family are not acceptable.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

