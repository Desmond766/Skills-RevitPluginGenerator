---
kind: property
id: P:Autodesk.Revit.DB.RoutingConditions.ErrorLevel
source: html/cc96a880-9f3b-08cf-7a31-e8301a817035.htm
---
# Autodesk.Revit.DB.RoutingConditions.ErrorLevel Property

The error level that the routing preference manager should post errors if the routing conditions do not meet any routing preference rule, could be None, Warning, or Error

## Syntax (C#)
```csharp
public RoutingPreferenceErrorLevel ErrorLevel { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.DisabledDisciplineException** - When setting this property: None of the following disciplines is enabled: Mechanical Electrical Piping.

