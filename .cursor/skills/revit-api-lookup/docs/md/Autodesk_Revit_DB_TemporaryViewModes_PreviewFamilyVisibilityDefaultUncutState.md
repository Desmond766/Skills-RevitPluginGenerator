---
kind: property
id: P:Autodesk.Revit.DB.TemporaryViewModes.PreviewFamilyVisibilityDefaultUncutState
source: html/1787a21c-c908-637b-46e9-841ac843d840.htm
---
# Autodesk.Revit.DB.TemporaryViewModes.PreviewFamilyVisibilityDefaultUncutState Property

Controls the default type of the On state of the PreviewFamilyVisibility mode in cut-able views.

## Syntax (C#)
```csharp
public static bool PreviewFamilyVisibilityDefaultUncutState { get; set; }
```

## Remarks
Newly opened views which can have both Cut and Uncut preview will use
 this default cut/uncut state as long as the default On state is set to True.
 To control the default state of the PreviewFamilyVisibility in all views refer to
 the PreviewFamilyVisibilityDefaultOnState 
 property. The settings is applicable to the whole application rather than to
 individual family documents; the value persists between Revit sessions.
 Although the value is allowed to be set at any time, any changes made after
 the Revit application has been initialized will not have effect until the next
 session of Revit. After a view is opened with the default family preview state applied,
 its PreviewFamilyVisibility mode may be independently modified through the
 PreviewFamilyVisibility property. Once explicitly modified,
 the settings stays in effect for the respective view even after the view
 is closed and later reopened again.

