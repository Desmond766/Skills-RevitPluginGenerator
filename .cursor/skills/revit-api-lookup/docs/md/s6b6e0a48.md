---
kind: property
id: P:Autodesk.Revit.DB.View.ViewTemplateId
zh: 视图
source: html/2559f20b-87d4-e879-3139-7f555b251b71.htm
---
# Autodesk.Revit.DB.View.ViewTemplateId Property

**中文**: 视图

The id of the template view that controls this view's parameters.

## Syntax (C#)
```csharp
public ElementId ViewTemplateId { get; set; }
```

## Remarks
Parameters controlled by the template cannot be changed directly in this view.
 Any change to controlled parameters in the template will cause change of the corresponding parameters in this view.
 Use GetTemplateParameterIds () () () on the template view to get a list of all template parameters.
 Use GetNonControlledTemplateParameterIds () () () on the template view to get parameters that are not controlled by the template.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: val is not valid as a view template id for this view.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

