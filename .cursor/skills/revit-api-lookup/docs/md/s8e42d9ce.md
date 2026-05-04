---
kind: property
id: P:Autodesk.Revit.DB.Structure.Rebar.DistributionType
zh: 钢筋、配筋
source: html/d5518e91-ce1f-7a3f-01bf-e3e3727ed42d.htm
---
# Autodesk.Revit.DB.Structure.Rebar.DistributionType Property

**中文**: 钢筋、配筋

The type of rebar distribution(also known as Rebar Set Type).

## Syntax (C#)
```csharp
public DistributionType DistributionType { get; set; }
```

## Remarks
The possible values of this property are:
 Uniform VaryingLength 
 For a uniform distribution type: all bars parameters are the same as the first bar in set.
 For a varying length distribution type: bars parameters can vary(primarly in length)
 taking in consideration the constraints of the first bar in set.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration

