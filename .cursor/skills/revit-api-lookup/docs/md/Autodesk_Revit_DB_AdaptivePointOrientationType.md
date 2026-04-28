---
kind: type
id: T:Autodesk.Revit.DB.AdaptivePointOrientationType
source: html/95bf6f69-8714-5342-8a43-ad4f6c8b05a7.htm
---
# Autodesk.Revit.DB.AdaptivePointOrientationType

An enumerated type containing possible orientation types for Adaptive Points.

## Syntax (C#)
```csharp
public enum AdaptivePointOrientationType
```

## Remarks
The default orientation of adaptive points is AdaptivePointOrientationType.ToInstance. All the items of this enumerated type were renamed for Revit 2016
 to better align the names with the corresponding text in the Revit UI.
 The numeric values of the items weren't modified, allowing existing
 applications to work. However, to be able to rebuild an application,
 all point orientations need to be changed to their respective new names.

