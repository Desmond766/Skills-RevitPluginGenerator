---
kind: method
id: M:Autodesk.Revit.DB.View.ApplyViewTemplateParameters(Autodesk.Revit.DB.View)
zh: 视图
source: html/2e27f324-a743-85d3-e232-13df5dbcf58e.htm
---
# Autodesk.Revit.DB.View.ApplyViewTemplateParameters Method

**中文**: 视图

Applies to this view the parameters of the input view that are not controlled by the current view template.

## Syntax (C#)
```csharp
public void ApplyViewTemplateParameters(
	View otherView
)
```

## Parameters
- **otherView** (`Autodesk.Revit.DB.View`) - The view whose parameters are to be applied to this view.
 It does not have to be a valid template (property IsTemplate can be true or false).

## Remarks
Apply the view template parameters is a one-time operation, the association between the views is not preserved.
 To get all template parameters call GetTemplateParameterIds () () () on the template.
 To get parameters that are not controlled by the template call GetNonControlledTemplateParameterIds () () () on the template.
 To get current view template of this view use property ViewTemplateId .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

