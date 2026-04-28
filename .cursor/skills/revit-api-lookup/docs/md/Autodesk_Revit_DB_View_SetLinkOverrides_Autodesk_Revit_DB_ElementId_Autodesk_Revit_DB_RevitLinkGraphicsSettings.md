---
kind: method
id: M:Autodesk.Revit.DB.View.SetLinkOverrides(Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.RevitLinkGraphicsSettings)
zh: 视图
source: html/3ecc27ef-b5f0-26e0-6584-7cb7668ed1f2.htm
---
# Autodesk.Revit.DB.View.SetLinkOverrides Method

**中文**: 视图

Sets the graphic overrides of a RevitLinkType or RevitLinkInstance in the view.

## Syntax (C#)
```csharp
public void SetLinkOverrides(
	ElementId linkId,
	RevitLinkGraphicsSettings linkDisplaySettings
)
```

## Parameters
- **linkId** (`Autodesk.Revit.DB.ElementId`) - The id of the RevitLinkType or RevitLinkInstance .
- **linkDisplaySettings** (`Autodesk.Revit.DB.RevitLinkGraphicsSettings`) - Settings representing all link graphic overrides in the view.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input id is not a valid RevitLinkInstance or RevitLinkType id.
 -or-
 Setting link overrides to type LinkVisibility.Custom is not supported via the API.
 -or-
 The LinkedViewId of linkDisplaySettings has incorrect value for the specified LinkVisibilityType.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The view type does not support Visibility/Graphics Overriddes.
 -or-
 The view does not support link graphical overrides.

