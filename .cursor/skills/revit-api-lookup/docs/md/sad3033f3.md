---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarContainerItem.FindMatchingPredefinedPresentationMode(Autodesk.Revit.DB.View)
source: html/c6425365-afc4-b069-d5f4-6e6c773a6a2b.htm
---
# Autodesk.Revit.DB.Structure.RebarContainerItem.FindMatchingPredefinedPresentationMode Method

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

