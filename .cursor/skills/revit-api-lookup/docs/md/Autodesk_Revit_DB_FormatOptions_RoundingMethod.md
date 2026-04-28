---
kind: property
id: P:Autodesk.Revit.DB.FormatOptions.RoundingMethod
source: html/35d26d7d-fb06-5b54-8a62-8ef03256aae5.htm
---
# Autodesk.Revit.DB.FormatOptions.RoundingMethod Property

The method used to round values: round to nearest, round up, or round down.

## Syntax (C#)
```csharp
public RoundingMethod RoundingMethod { get; set; }
```

## Remarks
The RoundingMethod property is currently only supported for rebar parameters.
 A FormatOptions object containing any rounding method may be returned by Element.GetParameterFormatOptions() and may be passed to the formatting and parsing utilities in the UnitFormatUtils class.
 FormatOptions objects used in other contexts must contain the default rounding method (Nearest).

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - UseDefault is true in this FormatOptions.

