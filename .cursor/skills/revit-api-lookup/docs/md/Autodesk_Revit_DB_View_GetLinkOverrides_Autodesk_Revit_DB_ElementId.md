---
kind: method
id: M:Autodesk.Revit.DB.View.GetLinkOverrides(Autodesk.Revit.DB.ElementId)
zh: 视图
source: html/f31cba64-9778-a432-4856-fe597f3daf84.htm
---
# Autodesk.Revit.DB.View.GetLinkOverrides Method

**中文**: 视图

Gets the graphic overrides of a RevitLinkType or RevitLinkInstance in view.

## Syntax (C#)
```csharp
public RevitLinkGraphicsSettings GetLinkOverrides(
	ElementId linkId
)
```

## Parameters
- **linkId** (`Autodesk.Revit.DB.ElementId`) - The id of the RevitLinkType or RevitLinkInstance .

## Returns
Settings representing graphic overrides for the input element id in the view, or Nothing nullptr a null reference ( Nothing in Visual Basic) if the input id references RevitLinkInstance and it doesn't have overrides in the view.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input id is not a valid RevitLinkInstance or RevitLinkType id.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The view type does not support Visibility/Graphics Overriddes.
 -or-
 The view does not support link graphical overrides.

