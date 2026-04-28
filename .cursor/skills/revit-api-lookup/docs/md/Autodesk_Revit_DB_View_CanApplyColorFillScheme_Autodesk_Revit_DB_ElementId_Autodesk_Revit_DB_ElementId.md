---
kind: method
id: M:Autodesk.Revit.DB.View.CanApplyColorFillScheme(Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
zh: 视图
source: html/79a38981-645b-919d-032e-bf36d47e11f1.htm
---
# Autodesk.Revit.DB.View.CanApplyColorFillScheme Method

**中文**: 视图

Checks if the id can be applied as the scheme id of specified category to this view.

## Syntax (C#)
```csharp
public bool CanApplyColorFillScheme(
	ElementId categoryId,
	ElementId schemeId
)
```

## Parameters
- **categoryId** (`Autodesk.Revit.DB.ElementId`) - The id of category.
- **schemeId** (`Autodesk.Revit.DB.ElementId`) - The id of color fill scheme.

## Returns
True if the id can be applied as the scheme id of specified category in this view, false otherwise.

## Remarks
The input scheme id could be InvalidElementId to clear the scheme for the specified category. Some examples of returnning false: The id is not a color fill scheme id. The specified category is not supported by this view. The category of scheme is not the same as the specified category. The view is area plan but the scheme category is not OST_Areas,
 or their [!:Autodesk::Revit::DB::AreaScheme] are not the same. Etc.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

