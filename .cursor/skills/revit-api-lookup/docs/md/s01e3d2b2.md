---
kind: method
id: M:Autodesk.Revit.DB.Structure.Rebar.CanApplyPresentationMode(Autodesk.Revit.DB.View)
zh: 钢筋、配筋
source: html/103b0f74-75ed-3db4-4ae0-645621296d9e.htm
---
# Autodesk.Revit.DB.Structure.Rebar.CanApplyPresentationMode Method

**中文**: 钢筋、配筋

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

