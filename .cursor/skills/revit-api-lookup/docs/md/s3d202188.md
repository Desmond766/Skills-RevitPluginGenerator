---
kind: property
id: P:Autodesk.Revit.DB.ConnectorElement.SystemClassification
source: html/5c9a9f68-7521-94bc-3bc1-7a3f5aa6ac69.htm
---
# Autodesk.Revit.DB.ConnectorElement.SystemClassification Property

The system classification of the connector.

## Syntax (C#)
```csharp
public MEPSystemClassification SystemClassification { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.ArgumentsInconsistentException** - When setting this property: The MEPSystemType is not valid for the domain of this connector.

