---
kind: method
id: M:Autodesk.Revit.DB.Analysis.RouteAnalysisSettings.SetIgnoredCategoryIds(System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId})
source: html/e7f826a1-97f9-5181-2ddf-aa7a71d8bab7.htm
---
# Autodesk.Revit.DB.Analysis.RouteAnalysisSettings.SetIgnoredCategoryIds Method

Sets the ElementIds for Category elements which are ignored by route calculation.

## Syntax (C#)
```csharp
public void SetIgnoredCategoryIds(
	ICollection<ElementId> categoryIds
)
```

## Parameters
- **categoryIds** (`System.Collections.Generic.ICollection < ElementId >`) - The ids of Categories to be ignored by route calculation.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - One or more ElementIds in categoryIds are not valid Category element ids.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

