---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarInSystem.CanApplyPresentationMode(Autodesk.Revit.DB.View)
source: html/2507e69f-fa82-b92e-f15f-8e841dbf7345.htm
---
# Autodesk.Revit.DB.Structure.RebarInSystem.CanApplyPresentationMode Method

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
True if a presentation mode can be applied for the given view, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

