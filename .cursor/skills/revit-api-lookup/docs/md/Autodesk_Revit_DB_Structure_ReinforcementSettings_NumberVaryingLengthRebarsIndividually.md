---
kind: property
id: P:Autodesk.Revit.DB.Structure.ReinforcementSettings.NumberVaryingLengthRebarsIndividually
source: html/7b74062d-8c65-4145-1d8c-23302ebc5b61.htm
---
# Autodesk.Revit.DB.Structure.ReinforcementSettings.NumberVaryingLengthRebarsIndividually Property

Use this option to modify the way varying length bars are numbered (individually or as a whole).

## Syntax (C#)
```csharp
public bool NumberVaryingLengthRebarsIndividually { get; set; }
```

## Remarks
This property affects only Rebar sets under the following conditions:
 1. The distribution type ( [!:Autodesk::Revit::DB::Rebar::distributionType] ) of the Rebar is DistributionType::Enum::VaryingLength. 2. There are at least two bars within the Rebar set that have different shape parameter values (i.e at least two bars vary in length). The shape parameters of a Rebar can be accessed via [!:Autodesk::Revit::DB::Structure::RebarShapeDefinition::getParameters] method. The parameters at a specific index in a Rebar set can be accessed via [!:Autodesk::Revit::DB::Structure::Rebar::getParameterValueAtIndex] method. If this property is true, then the Revit numbering mechanism ( [!:Autodesk::Revit::DB::NumberingSchema] )
 will assign each bar, in a varying set, a number.
 The number is assigned based on the Revit numbering logic. (For example if two bars are identical, they will receive the same number).
 The numbering mechanism will compare varying bars with other varying or uniform bars within the project. (i.e each bar in a varying set is interpreted as an individual Rebar). 
If this property is false, the following happens:
 1. The Revit numbering mechanism ( [!:Autodesk::Revit::DB::NumberingSchema] )
 will assign a unique number for each varying Rebar set.
 Each bar within the varying set will have(share) the same number that was assigned for the entire set.
 Even if two varying Rebar sets are identical, they will be assigned different numbers. 2. Each bar within a varying set will also be assigned a suffix parameter (REBAR_NUMBER_SUFFIX).
 This suffix parameter will receive values based on the RebarVaryingLengthNumberSuffix property.

