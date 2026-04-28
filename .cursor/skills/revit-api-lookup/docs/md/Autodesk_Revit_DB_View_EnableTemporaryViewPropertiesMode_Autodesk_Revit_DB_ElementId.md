---
kind: method
id: M:Autodesk.Revit.DB.View.EnableTemporaryViewPropertiesMode(Autodesk.Revit.DB.ElementId)
zh: 视图
source: html/89d71e79-0770-b235-db89-80b80dd331af.htm
---
# Autodesk.Revit.DB.View.EnableTemporaryViewPropertiesMode Method

**中文**: 视图

Turns Temporary View Properties mode on or off. In this mode, any changes made to the view
 are temporary and will be discarded once the mode is disabled.

## Syntax (C#)
```csharp
public bool EnableTemporaryViewPropertiesMode(
	ElementId viewTemplateId
)
```

## Parameters
- **viewTemplateId** (`Autodesk.Revit.DB.ElementId`) - If the id of a view template is provided, Temporary View Properties mode
 is turned on and the settings from the template are applied to the view for the duration of the mode.
 If the id provided is not that of a template but the id of the view itself,
 Temporary View Properties mode is turned on without any changes to the view.
 If ElementId.InvalidElementId is provided, Temporary View Properties mode is turned off.

## Returns
Returns true when the view template provided by viewTemplateId was applied and Temporary View Properties was successfully turned on.
 Also returns true if ElementId.InvalidElementId was provided as input and Temporary View Properties was successfully turned off.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - View cannot use Temporary View Properties mode in current state.

