---
kind: method
id: M:Autodesk.Revit.DB.RoutingPreferenceRule.RemoveCriteron(System.Int32)
source: html/5526f37d-73a0-5cdf-f72c-5df6012fd9a8.htm
---
# Autodesk.Revit.DB.RoutingPreferenceRule.RemoveCriteron Method

Removes an existing criterion.

## Syntax (C#)
```csharp
public void RemoveCriteron(
	int index
)
```

## Parameters
- **index** (`System.Int32`) - The index position of removed routing preference rule in the group.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - index is not a valid zero-based index.
 -or-
 Thrown if the index is out of bounds.
- **Autodesk.Revit.Exceptions.DisabledDisciplineException** - None of the following disciplines is enabled: Mechanical Electrical Piping.

