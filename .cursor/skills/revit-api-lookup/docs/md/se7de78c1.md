---
kind: method
id: M:Autodesk.Revit.DB.Structure.Rebar.SetPresentationMode(Autodesk.Revit.DB.View,Autodesk.Revit.DB.Structure.RebarPresentationMode)
zh: 钢筋、配筋
source: html/09b93605-4e24-3cfd-3931-c0f39ae1f6b9.htm
---
# Autodesk.Revit.DB.Structure.Rebar.SetPresentationMode Method

**中文**: 钢筋、配筋

Sets the presentation mode for this rebar set when displayed in the given view.

## Syntax (C#)
```csharp
public void SetPresentationMode(
	View dBView,
	RebarPresentationMode presentationMode
)
```

## Parameters
- **dBView** (`Autodesk.Revit.DB.View`) - The view.
- **presentationMode** (`Autodesk.Revit.DB.Structure.RebarPresentationMode`) - The presentation mode.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - This rebar cannot have a presentation mode applied for dBView, as the view is not valid for rebar presentation,
 or the orientation of the view matches the normal direction of the rebar element.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InapplicableDataException** - This rebar element represents a single bar (the layout rule is Single).

