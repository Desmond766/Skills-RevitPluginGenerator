---
kind: property
id: P:Autodesk.Revit.DB.RevisionSettings.RevisionCloudSpacing
source: html/ddf2f5bd-ce26-be0d-acf6-ed64798de965.htm
---
# Autodesk.Revit.DB.RevisionSettings.RevisionCloudSpacing Property

Determines the size in paper space of revision clouds drawn in a project.

## Syntax (C#)
```csharp
public double RevisionCloudSpacing { get; set; }
```

## Remarks
Revision clouds in Revit are created based on a collection of sketched lines. Revit then
 generates a series of "cloud bumps" along those lines to create a cloud shape. This setting
 determines the minimum length between the start and end each "cloud bump" (measured along the line).
 For example, if this setting were 2" and the sketched line were 3" long, Revit would
 create only one 3" bump. If the line length was increased to 4", Revit would add two 2" ones.
 Note that a single "cloud bump" consists of two arcs of slightly different size. Revit will always
 draw at least one "cloud bump" for each sketched line.
This value will be interpreted by Revit in paper space rather than in model space so
 that all of the clouds are shown in a uniform way on a sheet. This value will be rounded to a length that can be displayed according to the
 current project settings. The value may not be zero after rounding. This value may not
 exceed the maximum distance that can be represented as a length in Revit.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: desiredCloudSpacing is not a valid value for the cloud spacing.

