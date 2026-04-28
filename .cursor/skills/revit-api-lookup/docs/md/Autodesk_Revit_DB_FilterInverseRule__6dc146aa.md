---
kind: type
id: T:Autodesk.Revit.DB.FilterInverseRule
source: html/bd21b884-c026-5a16-4470-72172b71db4a.htm
---
# Autodesk.Revit.DB.FilterInverseRule

A filter rule that inverts the boolean values returned by the rule it contains.

## Syntax (C#)
```csharp
public class FilterInverseRule : FilterRule
```

## Remarks
FilterInverse rule performs a logical "not" operation on its inner rule's
 "elementPasses()" method.

