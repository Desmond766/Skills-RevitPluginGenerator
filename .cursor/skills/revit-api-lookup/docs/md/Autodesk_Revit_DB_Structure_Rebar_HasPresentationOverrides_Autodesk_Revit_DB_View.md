---
kind: method
id: M:Autodesk.Revit.DB.Structure.Rebar.HasPresentationOverrides(Autodesk.Revit.DB.View)
zh: 钢筋、配筋
source: html/1e74f1a5-0906-c5f0-0cde-0d8b6a6d563d.htm
---
# Autodesk.Revit.DB.Structure.Rebar.HasPresentationOverrides Method

**中文**: 钢筋、配筋

Identifies if this Rebar has overridden default presentation settings for the given view.

## Syntax (C#)
```csharp
public bool HasPresentationOverrides(
	View dBView
)
```

## Parameters
- **dBView** (`Autodesk.Revit.DB.View`) - The view.

## Returns
True if this Rebar has overriden default presentation settings, false otherwise.

## Remarks
Default presentation settings can be overriden using SetBarHiddenStatus(View, Int32, Boolean) , SetPresentationMode(View, RebarPresentationMode) methods

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

