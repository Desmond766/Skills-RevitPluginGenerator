---
kind: property
id: P:Autodesk.Revit.DB.FamilyParameter.StorageType
source: html/5dbb2cc2-03fa-681e-5740-f1dba9d7da78.htm
---
# Autodesk.Revit.DB.FamilyParameter.StorageType Property

The storage type describes the type that is used internally within the parameter to store its value.

## Syntax (C#)
```csharp
public StorageType StorageType { get; }
```

## Remarks
The property will return one of the following possibilities: String, Integer, Double
or ElementId. Based on the value of this property the correct access and set methods should be used
to retrieve and set the parameter's data value.

