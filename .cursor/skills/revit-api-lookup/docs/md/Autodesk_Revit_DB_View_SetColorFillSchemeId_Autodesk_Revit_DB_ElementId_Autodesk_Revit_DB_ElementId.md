---
kind: method
id: M:Autodesk.Revit.DB.View.SetColorFillSchemeId(Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
zh: 视图
source: html/11558424-7b34-ce05-f8e7-8f40ed64e3ff.htm
---
# Autodesk.Revit.DB.View.SetColorFillSchemeId Method

**中文**: 视图

Applies color fill scheme to this view.

## Syntax (C#)
```csharp
public void SetColorFillSchemeId(
	ElementId categoryId,
	ElementId schemeId
)
```

## Parameters
- **categoryId** (`Autodesk.Revit.DB.ElementId`) - The id of category to apply a color fill scheme element.
- **schemeId** (`Autodesk.Revit.DB.ElementId`) - The id of the color fill scheme element.

## Remarks
There could be at most three [!:Autodesk::Revit::DB::ColorFillScheme] applied in a view:
 one for spatial elements (rooms, zones, spaces and areas), one for pipes and one for ducts. Notes: There's at most one scheme activated for all spatial categories. For area plan view, the activated spatial scheme category must be OST_Areas and
 has the same [!:Autodesk::Revit::DB::AreaScheme] with this view if it is not used as a template. To clear one of the above three schemes, use InvalidElementId as the parameter of this function. To get list of element categories supportted to be colored in this view, use SupportedColorFillCategoryIds () () () . To check whether an specified ElementId could be applied to this view, use CanApplyColorFillScheme(ElementId, ElementId) .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The schemeId can not be applied as the scheme id of categoryId in this view.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

