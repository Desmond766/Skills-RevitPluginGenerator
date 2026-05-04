---
kind: property
id: P:Autodesk.Revit.DB.Structure.ReinforcementSettings.RebarPresentationInView
source: html/8a1b166e-3bea-5862-3fa4-996419581c5a.htm
---
# Autodesk.Revit.DB.Structure.ReinforcementSettings.RebarPresentationInView Property

The default presentation mode for rebar sets, when the view direction is perpendicular to the rebar normal and the rebar set is not cut.

## Syntax (C#)
```csharp
public RebarPresentationMode RebarPresentationInView { get; set; }
```

## Remarks
All bars in a given rebar set will be visible if:
 The view is a 3D view. The view direction is not parallel to the rebar normal. 
 For this case there are no defaults and no overrides in instances.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration

