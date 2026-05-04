---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarInSystem.ClearPresentationMode(Autodesk.Revit.DB.View)
source: html/7a085528-57ea-ea2a-7e30-0f699745758f.htm
---
# Autodesk.Revit.DB.Structure.RebarInSystem.ClearPresentationMode Method

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

