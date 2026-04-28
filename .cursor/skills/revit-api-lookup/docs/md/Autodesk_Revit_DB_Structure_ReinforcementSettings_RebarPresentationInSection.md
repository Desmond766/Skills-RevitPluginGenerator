---
kind: property
id: P:Autodesk.Revit.DB.Structure.ReinforcementSettings.RebarPresentationInSection
source: html/511b0bb9-155f-3397-9a13-d41100fc8d72.htm
---
# Autodesk.Revit.DB.Structure.ReinforcementSettings.RebarPresentationInSection Property

The default presentation mode for rebar sets, when:
 The view direction is perpendicular to the rebar normal and the rebar set is cut. The view direction is not perpendicular to the rebar normal and the view direction is not parallel to the rebar normal.

## Syntax (C#)
```csharp
public RebarPresentationMode RebarPresentationInSection { get; set; }
```

## Remarks
All bars in a given rebar set will be visible if:
 The view is a 3D view. The view direction is not parallel to the rebar normal. 
 For this case there are no defaults and no overrides in instances.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration

