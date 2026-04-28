---
kind: property
id: P:Autodesk.Revit.DB.EvaluatedParameter.StorageType
source: html/1a28a2a2-6366-1ec1-45ec-1d2ca94db0f7.htm
---
# Autodesk.Revit.DB.EvaluatedParameter.StorageType Property

The storage type describes the type that is used internally within the parameter to store its value.

## Syntax (C#)
```csharp
public StorageType StorageType { get; }
```

## Remarks
The property will return one of the following possibilities: String, Integer, Double or ElementId.
 Based on the value of this property the correct access and set methods should be used to retrieve
 and set the parameter's data value.

