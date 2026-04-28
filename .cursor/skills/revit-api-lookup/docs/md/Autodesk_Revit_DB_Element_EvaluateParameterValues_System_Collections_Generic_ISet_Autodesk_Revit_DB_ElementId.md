---
kind: method
id: M:Autodesk.Revit.DB.Element.EvaluateParameterValues(System.Collections.Generic.ISet{Autodesk.Revit.DB.ElementId})
zh: 构件、图元、元素
source: html/1a6ca65f-09d9-a4e6-9365-3ed64e3097fc.htm
---
# Autodesk.Revit.DB.Element.EvaluateParameterValues Method

**中文**: 构件、图元、元素

Evaluate the parameters' values of the element on the given parameter ID set.

## Syntax (C#)
```csharp
public IList<EvaluatedParameter> EvaluateParameterValues(
	ISet<ElementId> parameterIds
)
```

## Parameters
- **parameterIds** (`System.Collections.Generic.ISet < ElementId >`) - Parameter IDs with which the ParameterValue to be retrieved.

## Returns
List of EvaluatedParameter of the element, which does not include those that cannot be retrieved but are passed in through parameterIds .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

