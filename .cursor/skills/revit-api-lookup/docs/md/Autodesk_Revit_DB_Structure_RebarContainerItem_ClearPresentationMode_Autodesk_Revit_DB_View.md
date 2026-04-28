---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarContainerItem.ClearPresentationMode(Autodesk.Revit.DB.View)
source: html/b23d7436-582b-d552-4876-457a83b31640.htm
---
# Autodesk.Revit.DB.Structure.RebarContainerItem.ClearPresentationMode Method

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

