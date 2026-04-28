---
kind: method
id: M:Autodesk.Revit.DB.Structure.Rebar.ClearPresentationMode(Autodesk.Revit.DB.View)
zh: 钢筋、配筋
source: html/61ffbfb6-628b-3f41-3cb0-c46406a41a5c.htm
---
# Autodesk.Revit.DB.Structure.Rebar.ClearPresentationMode Method

**中文**: 钢筋、配筋

Sets the presentation mode for this rebar set to the default (either for a single view, or for all views).

## Syntax (C#)
```csharp
public void ClearPresentationMode(
	View dBView
)
```

## Parameters
- **dBView** (`Autodesk.Revit.DB.View`) - The view where the presentation mode will be cleared. NULL for all views

## Exceptions
- **Autodesk.Revit.Exceptions.InapplicableDataException** - This rebar element represents a single bar (the layout rule is Single).

