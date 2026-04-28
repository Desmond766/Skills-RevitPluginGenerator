---
kind: property
id: P:Autodesk.Revit.DB.Architecture.HandRailType.SupportJustification
source: html/45d136e8-c4de-da06-d9f8-a6cd5aa41ed7.htm
---
# Autodesk.Revit.DB.Architecture.HandRailType.SupportJustification Property

The support justification method of the handrail.

## Syntax (C#)
```csharp
public RailSupportJustification SupportJustification { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: The rail has no support or the support layout is not fixed distance so the data being set is not applicable.

