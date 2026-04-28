---
kind: type
id: T:Autodesk.Revit.DB.ColorFillLegend
source: html/81cbdc7c-9f7f-b454-5669-77ca0514eda7.htm
---
# Autodesk.Revit.DB.ColorFillLegend

Represents color fill legend.

## Syntax (C#)
```csharp
public class ColorFillLegend : Element
```

## Remarks
Color fill legend is a 2D annotation element, it can be created through Create(Document, ElementId, ElementId, XYZ) with specified category of color fill scheme,
 if there exists a valid color fill scheme activated for the category in the view. After a legend is created, its content and layout will
 keep consistent with the active color fill scheme of the view. You can adjust its position through Origin property,
 or manually maintain its layout through Height property and GetColumnWidths () () () / [M:Autodesk.Revit.DB.ColorFillLegend.SetColumnWidths(System.Collections.Generic.IList`1{System.Double})] methods. Notes: GetColorFillSchemeId(ElementId) could be used to retrieve the corresponding color fill scheme of this legend, through the
 [!:Autodesk::Revit::DB::View::ColorFillCategoryId] and OwnerViewId properties. Note that there could only exist one active scheme for all spatial categories
 (rooms, areas, and zones) in one view. Once the height and column widths are explicitly set, they will be fixed even if the contents of the legend change. To retrieve correct height and column widths, it's better to manually retrieve the geometry of legend for nonvisible views.
 (Because color fill legend is a view specific element.) The value of Height property does not contain the line that displays "Calculating...".

