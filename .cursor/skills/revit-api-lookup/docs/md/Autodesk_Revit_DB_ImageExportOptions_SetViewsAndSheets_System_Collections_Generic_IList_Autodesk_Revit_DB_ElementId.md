---
kind: method
id: M:Autodesk.Revit.DB.ImageExportOptions.SetViewsAndSheets(System.Collections.Generic.IList{Autodesk.Revit.DB.ElementId})
source: html/f9ac839c-2722-2249-1be8-5033601b948f.htm
---
# Autodesk.Revit.DB.ImageExportOptions.SetViewsAndSheets Method

Sets a list of views and sheets to be exported. Used only when ExportRange is SetOfViews.

## Syntax (C#)
```csharp
public void SetViewsAndSheets(
	IList<ElementId> viewsAndSheets
)
```

## Parameters
- **viewsAndSheets** (`System.Collections.Generic.IList < ElementId >`) - The ids of the views and sheets.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

