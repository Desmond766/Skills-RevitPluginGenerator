---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarInSystem.HasPresentationOverrides(Autodesk.Revit.DB.View)
source: html/0bd7f298-e69a-1179-820f-47fd589a2269.htm
---
# Autodesk.Revit.DB.Structure.RebarInSystem.HasPresentationOverrides Method

Identifies if this RebarInSystem has overridden default presentation settings for the given view.

## Syntax (C#)
```csharp
public bool HasPresentationOverrides(
	View dBView
)
```

## Parameters
- **dBView** (`Autodesk.Revit.DB.View`) - The view.

## Returns
True if this RebarInSystem has overriden default presentation settings, false otherwise.

## Remarks
Default presentation settings can be overriden using SetBarHiddenStatus(View, Int32, Boolean) , SetPresentationMode(View, RebarPresentationMode) methods

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

