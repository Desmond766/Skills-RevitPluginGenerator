---
kind: method
id: M:Autodesk.Revit.DB.RoutingPreferenceRule.#ctor(Autodesk.Revit.DB.ElementId,System.String)
source: html/51df3abb-7b1a-d3cd-5ac7-3f785a53b7d2.htm
---
# Autodesk.Revit.DB.RoutingPreferenceRule.#ctor Method

Constructs a RoutingPreferenceRule containing a segment or fitting Id (MEPPartId) and description.

## Syntax (C#)
```csharp
public RoutingPreferenceRule(
	ElementId MEPPartId,
	string description
)
```

## Parameters
- **MEPPartId** (`Autodesk.Revit.DB.ElementId`) - The Id of the segment or fitting. InvalidElementId may be specified if no MEPPart will be allowed when the conditions satisfy the criteria in this rule.
- **description** (`System.String`) - The description of the rule.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

