---
kind: property
id: P:Autodesk.Revit.DB.FilterDoubleRule.RuleValue
source: html/60384a1a-07d8-bffd-45d9-dec370320f81.htm
---
# Autodesk.Revit.DB.FilterDoubleRule.RuleValue Property

The user-supplied value against which values from a Revit document will be tested.

## Syntax (C#)
```csharp
public double RuleValue { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The given value for ruleValue is not finite
 -or-
 When setting this property: The given value for ruleValue is not a number

