---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarContainer.CanApplyPresentationMode(Autodesk.Revit.DB.View)
source: html/4320a85e-3b48-719a-ec2e-ee74991c2dc2.htm
---
# Autodesk.Revit.DB.Structure.RebarContainer.CanApplyPresentationMode Method

Checks if a presentation mode can be applied for this RebarContainer in the given view.

## Syntax (C#)
```csharp
public bool CanApplyPresentationMode(
	View dBView
)
```

## Parameters
- **dBView** (`Autodesk.Revit.DB.View`) - The view in which presentation mode will be applied.

## Returns
True if presentation mode can be applied for this view, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

