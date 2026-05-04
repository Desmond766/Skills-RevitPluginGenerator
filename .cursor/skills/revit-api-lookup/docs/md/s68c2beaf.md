---
kind: method
id: M:Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateSharedParameterApplicableRule(System.String)
source: html/170b333d-c12b-cfe5-b0c3-7701b66fe8b1.htm
---
# Autodesk.Revit.DB.ParameterFilterRuleFactory.CreateSharedParameterApplicableRule Method

Creates a filter rule that tests elements for support of a shared parameter.

## Syntax (C#)
```csharp
public static FilterRule CreateSharedParameterApplicableRule(
	string parameterName
)
```

## Parameters
- **parameterName** (`System.String`) - The name of the parameter that elements must support to satisfy this rule.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

