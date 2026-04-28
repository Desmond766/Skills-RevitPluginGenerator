---
kind: method
id: M:Autodesk.Revit.DB.ConnectorElement.IsSystemClassificationValid(Autodesk.Revit.DB.MEPSystemClassification)
source: html/fbb9b3ea-b312-de08-006c-916e85663f62.htm
---
# Autodesk.Revit.DB.ConnectorElement.IsSystemClassificationValid Method

Checks that the MEPSystemType is valid for the domain of connector.

## Syntax (C#)
```csharp
public bool IsSystemClassificationValid(
	MEPSystemClassification systemClassification
)
```

## Parameters
- **systemClassification** (`Autodesk.Revit.DB.MEPSystemClassification`) - The MEPSystemType to be validated.

## Returns
True if the MEPSystemType is valid for the domain of the connector, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

