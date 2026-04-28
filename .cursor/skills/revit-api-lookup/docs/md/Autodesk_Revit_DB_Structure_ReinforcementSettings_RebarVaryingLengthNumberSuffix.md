---
kind: property
id: P:Autodesk.Revit.DB.Structure.ReinforcementSettings.RebarVaryingLengthNumberSuffix
source: html/4fbbb672-5f0c-fc86-3fce-2b1a16127fff.htm
---
# Autodesk.Revit.DB.Structure.ReinforcementSettings.RebarVaryingLengthNumberSuffix Property

A unique identifier used for a bar within a variable length rebar set.

## Syntax (C#)
```csharp
public string RebarVaryingLengthNumberSuffix { get; set; }
```

## Remarks
This property affects only Rebar sets under the following conditions:
 1. The distribution type ( [!:Autodesk::Revit::DB::Rebar::distributionType] ) of the Rebar is DistributionType::Enum::VaryingLength. 2. There are at least two bars within the Rebar set that have different shape parameter values (i.e at least two bars vary in length). The shape parameters of a Rebar can be accessed via [!:Autodesk::Revit::DB::Structure::RebarShapeDefinition::getParameters] method. The parameters at a specific index in a Rebar set can be accessed via [!:Autodesk::Revit::DB::Structure::Rebar::getParameterValueAtIndex] method. This property is assigned to varying Rebar sets
 only if they are numbered as a whole (i.e. NumberVaryingLengthRebarsIndividually is set to false). 
The values for this property are valid if :
 Input contains at least one character. Input contains either alphabetical or numeric characters (not both). 
When this property is used, each bar in a varying set will be assigned an incremented value of the suffix.
 As an example, the suffix values for three bars in a varying set are:
 For alphabetic suffix : Aaz -> Aba -> Abb. For numeric suffix : 129 -> 130 -> 131. 
 These values are automatically incremented by the system.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The rebar number suffix is not valid if :
 Input is empty. Input contains non-alphanumeric characters. Input contains both numeric and alphabetic characters. Input is a value that exceeds the maximum integer representation. Input contains more than 6 alphabetic characters.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

