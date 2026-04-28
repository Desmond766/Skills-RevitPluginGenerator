---
kind: method
id: M:Autodesk.Revit.DB.RoutingConditions.GetConditionAt(System.Int32)
source: html/263b2107-de30-fbdf-2951-3aa4391fc64c.htm
---
# Autodesk.Revit.DB.RoutingConditions.GetConditionAt Method

Gets the routing condition at the specified index position.

## Syntax (C#)
```csharp
public RoutingCondition GetConditionAt(
	int index
)
```

## Parameters
- **index** (`System.Int32`) - The 0-based index to access the collection of available conditions. The method throws the exception ArgumentOutOfRangeException if the index is out of range.

## Returns
The found routing condition.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - index is not within the valid range of available conditions.
- **Autodesk.Revit.Exceptions.DisabledDisciplineException** - None of the following disciplines is enabled: Mechanical Electrical Piping.

