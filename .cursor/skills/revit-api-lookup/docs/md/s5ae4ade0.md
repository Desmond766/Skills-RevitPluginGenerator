---
kind: method
id: M:Autodesk.Revit.DB.View.IsValidViewTemplate(Autodesk.Revit.DB.ElementId)
zh: 视图
source: html/53cfc8e6-8004-4164-9b1c-79bbc187450f.htm
---
# Autodesk.Revit.DB.View.IsValidViewTemplate Method

**中文**: 视图

Verifies that the view represented by templateId can be set as the controlling view template for this view.

## Syntax (C#)
```csharp
public bool IsValidViewTemplate(
	ElementId templateId
)
```

## Parameters
- **templateId** (`Autodesk.Revit.DB.ElementId`) - The id to be validated as a view template for this view.

## Returns
True if the view is valid for us as a view template and compatible with this view, or if it is InvalidElementId, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

