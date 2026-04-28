---
kind: method
id: M:Autodesk.Revit.DB.View.RemoveLinkOverrides(Autodesk.Revit.DB.ElementId)
zh: 视图
source: html/68769be1-3ba0-b77c-4926-bf85de9c1b8d.htm
---
# Autodesk.Revit.DB.View.RemoveLinkOverrides Method

**中文**: 视图

Deletes the graphical link overrides in the current view.

## Syntax (C#)
```csharp
public void RemoveLinkOverrides(
	ElementId linkId
)
```

## Parameters
- **linkId** (`Autodesk.Revit.DB.ElementId`) - The id of the RevitLinkType or RevitLinkInstance .

## Remarks
If the input linkId references RevitLinkType , then the link overrides will be set to default.
 If the input linkId references RevitLinkInstance , then the link overrides will be removed and the settings of RevitLinkType will be used for this instance.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input id is not a valid RevitLinkInstance or RevitLinkType id.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The view type does not support Visibility/Graphics Overriddes.
 -or-
 The view does not support link graphical overrides.

