---
kind: property
id: P:Autodesk.Revit.DB.Revision.Visibility
source: html/472863b6-960a-a26a-546e-a011c7c873a9.htm
---
# Autodesk.Revit.DB.Revision.Visibility Property

Controls the visibility of revision clouds and revision tags related to this Revision.

## Syntax (C#)
```csharp
public RevisionVisibility Visibility { get; set; }
```

## Remarks
This property provides project-wide control over the visibility of revision clouds and tags associated with this
 Revision. If clouds or tags are hidden by this property they will not be visible in any views regardless of the
 view's settings. If clouds or tags are visible according to this property they may still be hidden on a particular
 view or sheet.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration

