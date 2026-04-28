---
kind: method
id: M:Autodesk.Revit.DB.View.GetNonControlledTemplateParameterIds
zh: 视图
source: html/a34bb9cf-9a1d-a3e7-b04e-78bca30ecf4e.htm
---
# Autodesk.Revit.DB.View.GetNonControlledTemplateParameterIds Method

**中文**: 视图

Returns a list of parameters that are not marked as included when this view is used as a template.

## Syntax (C#)
```csharp
public ICollection<ElementId> GetNonControlledTemplateParameterIds()
```

## Returns
The parameter ids that are not marked to be included.

## Remarks
This is a subset of the parameters returned by GetTemplateParameterIds () () () .

