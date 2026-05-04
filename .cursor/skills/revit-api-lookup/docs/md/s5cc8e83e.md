---
kind: property
id: P:Autodesk.Revit.DB.Family.IsParametric
zh: 族
source: html/1d4166dd-057d-9d9b-e28f-7bd250bbe587.htm
---
# Autodesk.Revit.DB.Family.IsParametric Property

**中文**: 族

Identifies whether the family contains parametric relations
 between some of its elements.

## Syntax (C#)
```csharp
public bool IsParametric { get; }
```

## Remarks
A family is parametric if it contains parameter-driven relations between
 its elements, such as labeled dimensions or locked tangential joins. Parametric families containing large sketches may cause performance
 problems. Caution is therefore advised before adding any constraints to
 a yet non-parametric family that already contains large sketches.
 See [!:DoesContainLargeSketches()] .

