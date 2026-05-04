---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarInSystem.FindMatchingPredefinedPresentationMode(Autodesk.Revit.DB.View)
source: html/d479c5d6-532a-8f63-b2da-e51bb5239d64.htm
---
# Autodesk.Revit.DB.Structure.RebarInSystem.FindMatchingPredefinedPresentationMode Method

Determines if there is a matching RebarPresentationMode for the current set of selected hidden and unhidden bars assigned to the given view.

## Syntax (C#)
```csharp
public RebarPresentationMode FindMatchingPredefinedPresentationMode(
	View dBView
)
```

## Parameters
- **dBView** (`Autodesk.Revit.DB.View`) - The view.

## Returns
The presentation mode that matches the current set of selected hidden and unhidden bars.
 If there is no better match, this returns RebarPresentationMode.Select.

## Remarks
If the presentation mode is not PresentationMode.Select for the view, this function returns the current mode.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

