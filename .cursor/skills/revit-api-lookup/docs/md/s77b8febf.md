---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarContainerItem.CanApplyPresentationMode(Autodesk.Revit.DB.View)
source: html/b5e087e1-791d-2410-5c71-39a231e5bb32.htm
---
# Autodesk.Revit.DB.Structure.RebarContainerItem.CanApplyPresentationMode Method

Checks if a presentation mode can be applied for this rebar in the given view.

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

