---
kind: method
id: M:Autodesk.Revit.DB.Element.IsHidden(Autodesk.Revit.DB.View)
zh: 构件、图元、元素
source: html/2c3d4123-fded-cd5f-ed0d-12b1e1a3ce42.htm
---
# Autodesk.Revit.DB.Element.IsHidden Method

**中文**: 构件、图元、元素

Identifies if the element has been permanently hidden in the view.

## Syntax (C#)
```csharp
public bool IsHidden(
	View pView
)
```

## Parameters
- **pView** (`Autodesk.Revit.DB.View`)

## Remarks
This does not determine if the element is hidden as a result of temporary hide/isolate, 
view sectioning, view crop box, or other operations that can cause elements not to be visible.
To hide or unhide an element, use the Hide() and Unhide() method of View .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when argument is Nothing nullptr a null reference ( Nothing in Visual Basic) .

