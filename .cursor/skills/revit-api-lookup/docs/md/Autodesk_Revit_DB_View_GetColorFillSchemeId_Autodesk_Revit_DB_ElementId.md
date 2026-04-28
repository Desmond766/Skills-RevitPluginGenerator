---
kind: method
id: M:Autodesk.Revit.DB.View.GetColorFillSchemeId(Autodesk.Revit.DB.ElementId)
zh: 视图
source: html/c504d70c-ab68-2db1-95be-73e821ee3587.htm
---
# Autodesk.Revit.DB.View.GetColorFillSchemeId Method

**中文**: 视图

Returns id of the color fill scheme element applied to the view.

## Syntax (C#)
```csharp
public ElementId GetColorFillSchemeId(
	ElementId categoryId
)
```

## Parameters
- **categoryId** (`Autodesk.Revit.DB.ElementId`) - The id of the category which the color fill scheme element belongs to.

## Returns
The id of the color fill scheme element.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

