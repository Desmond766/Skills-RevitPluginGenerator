---
kind: type
id: T:Autodesk.Revit.DB.FilterElementIdRule
source: html/4675442b-8c75-4e20-ba18-71df13b86896.htm
---
# Autodesk.Revit.DB.FilterElementIdRule

A filter rule that operates on ElementId values in a Revit project.

## Syntax (C#)
```csharp
public class FilterElementIdRule : FilterNumericValueRule
```

## Remarks
When GetRuleParameter () () () returns a parameter
 that UsesLevelFiltering(Document, ElementId) ,
 then the comparisons will first compare the values of the levels' elevations, then compare
 the levels' names, and finally the levels' element ids to rank and sort the levels.

