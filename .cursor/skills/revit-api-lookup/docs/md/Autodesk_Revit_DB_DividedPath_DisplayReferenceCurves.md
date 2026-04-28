---
kind: property
id: P:Autodesk.Revit.DB.DividedPath.DisplayReferenceCurves
source: html/4f6af99b-9911-ed7b-5ce2-620098726cc9.htm
---
# Autodesk.Revit.DB.DividedPath.DisplayReferenceCurves Property

Controls whether the curves in the path are visible

## Syntax (C#)
```csharp
public bool DisplayReferenceCurves { get; set; }
```

## Remarks
If true the references that represent the curves will not be hidden.
 If false the references that represent the curves may be hidden
 Only references that are curve elements can be hidden
 If multiple divided paths reference a curve element
 then the curve element is not hidden unless all divided paths request that it be hidden.

