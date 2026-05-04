---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarContainerItem.HasPresentationOverrides(Autodesk.Revit.DB.View)
source: html/abc20bda-3702-2099-e137-7ce85fdf1676.htm
---
# Autodesk.Revit.DB.Structure.RebarContainerItem.HasPresentationOverrides Method

Identifies if this rebar set has overridden default presentation settings for the given view.

## Syntax (C#)
```csharp
public bool HasPresentationOverrides(
	View dBView
)
```

## Parameters
- **dBView** (`Autodesk.Revit.DB.View`) - The view.

## Returns
True if this rebar set has overriden default presentation settings, false otherwise.

## Remarks
Default presentation settings can be overriden using SetBarHiddenStatus(View, Int32, Boolean) , SetPresentationMode(View, RebarPresentationMode) methods

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

