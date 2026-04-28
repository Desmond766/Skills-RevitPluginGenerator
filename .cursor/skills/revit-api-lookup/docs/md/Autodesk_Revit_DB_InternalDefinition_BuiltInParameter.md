---
kind: property
id: P:Autodesk.Revit.DB.InternalDefinition.BuiltInParameter
source: html/31c4b24f-c65a-8541-3fa8-c513563321cf.htm
---
# Autodesk.Revit.DB.InternalDefinition.BuiltInParameter Property

Tests whether this definition identifies a built-in parameter or not.

## Syntax (C#)
```csharp
public BuiltInParameter BuiltInParameter { get; }
```

## Remarks
For a build-in parameter this property equals one of the BuiltInParameter enumerated values.
For custom-defined parameters, such as shared, global, or family parameters the value is always BuiltInParameter.INVALID.

