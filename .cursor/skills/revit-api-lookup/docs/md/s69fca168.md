---
kind: property
id: P:Autodesk.Revit.DB.Category.Visible(Autodesk.Revit.DB.View)
source: html/863e37ff-4415-5d39-d371-36c3284812d7.htm
---
# Autodesk.Revit.DB.Category.Visible Property

Retrieves or changes the visibility of the category in the active view.

## Syntax (C#)
```csharp
public bool this[
	View view
] { get; set; }
```

## Parameters
- **view** (`Autodesk.Revit.DB.View`)

## Remarks
This affects only if the category is set visible or invisible individually. Other Revit mechanisms
may also affect the visibility of elements of this category, including:
 the category classes settings for 
model categories, annotation categories, import categories or analytical model categories. view filters 
Thus setting this value may not affect the actual visibility of elements of this category in the view.

