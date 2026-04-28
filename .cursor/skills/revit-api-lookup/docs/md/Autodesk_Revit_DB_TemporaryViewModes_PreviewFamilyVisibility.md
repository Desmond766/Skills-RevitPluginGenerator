---
kind: property
id: P:Autodesk.Revit.DB.TemporaryViewModes.PreviewFamilyVisibility
source: html/24f8dd9e-c6e5-7c61-84c6-4556f345e7d4.htm
---
# Autodesk.Revit.DB.TemporaryViewModes.PreviewFamilyVisibility Property

The current state of the PreviewFamilyVisibility mode in the associated view.

## Syntax (C#)
```csharp
public PreviewFamilyVisibilityMode PreviewFamilyVisibility { get; set; }
```

## Remarks
The state of the PreviewFamilyVisibility mode can be set only if the mode
 is currently available and enabled in the view. Even in such a condition,
 however, not all states are valid in all views. To ensure that the state
 to be applied is valid in the view, call the IsValidState(PreviewFamilyVisibilityMode) method
 first. Even views which generally support temporary modes will have this particular
 mode available only when the document of the view is in the environment of the
 family editor. This property affect only the view associated with this instance of TemporaryViewModes.
 When a view is opened for the first time, its state of the PreviewFamilyVisibility mode
 is determined based on the default settings which is controlled through the properties
 PreviewFamilyVisibilityDefaultOnState and
 PreviewFamilyVisibilityDefaultUncutState .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The given PreviewFamilyVisibilityMode is not applicable in the associated view.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: The PreviewFamilyVisibility mode is either disabled or inapplicable in the associated view.

