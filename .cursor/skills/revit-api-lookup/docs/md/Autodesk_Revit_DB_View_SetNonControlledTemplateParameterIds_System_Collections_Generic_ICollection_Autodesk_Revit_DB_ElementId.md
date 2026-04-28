---
kind: method
id: M:Autodesk.Revit.DB.View.SetNonControlledTemplateParameterIds(System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId})
zh: 视图
source: html/15617b2e-89a4-ddbe-5f93-7855c2994d79.htm
---
# Autodesk.Revit.DB.View.SetNonControlledTemplateParameterIds Method

**中文**: 视图

Sets the parameters that will not be included when this view is used as a template.

## Syntax (C#)
```csharp
public void SetNonControlledTemplateParameterIds(
	ICollection<ElementId> newSet
)
```

## Parameters
- **newSet** (`System.Collections.Generic.ICollection < ElementId >`) - The parameter ids that should not be marked to be included.

## Remarks
This should be a subset of the parameters returned by GetTemplateParameterIds () () () (other parameters will be ignored).

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

