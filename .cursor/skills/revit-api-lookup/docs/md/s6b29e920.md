---
kind: method
id: M:Autodesk.Revit.DB.GlobalParameter.GetAffectedElements
source: html/c1eb340d-471d-4810-92fe-a2bd6374fc1f.htm
---
# Autodesk.Revit.DB.GlobalParameter.GetAffectedElements Method

Returns all elements of which properties are driven by this global parameter.

## Syntax (C#)
```csharp
public ISet<ElementId> GetAffectedElements()
```

## Returns
Collection of Element Ids.

## Remarks
The returned collection does not include dimensions labeled by this global parameter.
 To get the labeled dimensions use the GetLabeledDimensions () () () method.
 Other global parameters that may be affected by this one (in their formulas)
 are also excluded from the returned collection. To get the set of affected global
 parameters use the GetAffectedGlobalParameters () () () method.

