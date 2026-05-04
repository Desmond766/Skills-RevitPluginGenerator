---
kind: property
id: P:Autodesk.Revit.DB.TemporaryViewModes.PreviewFamilyVisibilityDefaultOnState
source: html/295a6ae9-e3c0-795c-d025-fa52b47eea63.htm
---
# Autodesk.Revit.DB.TemporaryViewModes.PreviewFamilyVisibilityDefaultOnState Property

Controls the default state of the PreviewFamilyVisibility mode in all views.

## Syntax (C#)
```csharp
public static bool PreviewFamilyVisibilityDefaultOnState { get; set; }
```

## Remarks
This flag controls whether each newly opened view is to have the
 PreviewFamilyVisibility mode turned On by default or not. This property is applicable to all
 types of views. Views that support both Cut and Non-cut preview (such as floor plans) can be
 controlled further via the PreviewFamilyVisibilityDefaultUncutState 
 property. The settings is applicable to the whole application rather than to
 individual family documents; the value persists between Revit sessions.
 Although the value is allowed to be set at any time, any changes made after
 the Revit application has been initialized will not have effect until the next
 session of Revit. After a view is opened with the default family preview state applied,
 its PreviewFamilyVisibility mode may be independently modified through the
 PreviewFamilyVisibility property. Once explicitly modified,
 the settings stays in effect for the respective view even after the view
 is closed and later reopened again.

