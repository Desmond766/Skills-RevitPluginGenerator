---
kind: property
id: P:Autodesk.Revit.DB.DividedPath.SpacingRuleJustification
source: html/af3c645c-7d2f-2477-f650-7a49a043c2f6.htm
---
# Autodesk.Revit.DB.DividedPath.SpacingRuleJustification Property

When the layout is set to 'FixedDistance' the points may not cover the
 entire range of the path. The justification determines whether
 the points are centered on the range, or shifted towards the start or end of the range.

## Syntax (C#)
```csharp
public SpacingRuleJustification SpacingRuleJustification { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: Invalid justification
 -or-
 When setting this property: A value passed for an enumeration argument is not a member of that enumeration

