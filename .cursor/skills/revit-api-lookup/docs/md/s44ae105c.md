---
kind: property
id: P:Autodesk.Revit.DB.BaseArray.Name
source: html/4eecb0d1-7633-86b7-d95c-42a4362f0b2c.htm
---
# Autodesk.Revit.DB.BaseArray.Name Property

Get and Set the Name property

## Syntax (C#)
```csharp
public override string Name { set; }
```

## Remarks
The method set is override to forbid the user to change the Name. When the user tries
to call the method set for BaseArray object, an InvalidOperationException will be thrown.

