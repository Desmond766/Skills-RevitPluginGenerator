---
kind: property
id: P:Autodesk.Revit.DB.Category.AllowsVisibilityControl(Autodesk.Revit.DB.View)
source: html/796fd49b-4abb-4848-5e0a-11fcab29a901.htm
---
# Autodesk.Revit.DB.Category.AllowsVisibilityControl Property

Whether the visibility can be controlled by the user for this category in this view.

## Syntax (C#)
```csharp
public bool this[
	View view
] { get; }
```

## Parameters
- **view** (`Autodesk.Revit.DB.View`) - The view where visibility control might be allowed.

## Remarks
There are some categories in Revit that are hidden to users in the Object Styles and 
Visibility dialog. Their visibility cannot be controlled for a particular view. This property 
identifies if the category allows visibility control (and thus allows the Visible property to 
be set).

