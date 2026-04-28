---
kind: method
id: M:Autodesk.Revit.DB.RoutingConditions.AppendCondition(Autodesk.Revit.DB.RoutingCondition)
source: html/2105d8fb-9618-2b90-f983-de56b6397042.htm
---
# Autodesk.Revit.DB.RoutingConditions.AppendCondition Method

Appends a routing condition to the end of existing routing conditions. Note that the first item (indexed at 0) is the condition for the primary connector.

## Syntax (C#)
```csharp
public void AppendCondition(
	RoutingCondition condition
)
```

## Parameters
- **condition** (`Autodesk.Revit.DB.RoutingCondition`)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.DisabledDisciplineException** - None of the following disciplines is enabled: Mechanical Electrical Piping.

