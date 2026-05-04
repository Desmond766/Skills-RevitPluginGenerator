---
kind: property
id: P:Autodesk.Revit.DB.FamilyInstance.MEPModel
zh: 族实例
source: html/34173003-db39-bfa9-fa59-f7b5ac8da794.htm
---
# Autodesk.Revit.DB.FamilyInstance.MEPModel Property

**中文**: 族实例

Retrieves the MEP model for the family instance.

## Syntax (C#)
```csharp
public MEPModel MEPModel { get; }
```

## Remarks
If the family instance has a MEP model it is returned by this method, otherwise Nothing nullptr a null reference ( Nothing in Visual Basic) is 
returned. Different types of MEP model will be returned based on the type of the instance, for 
example - if the instance is a lighting device then a lighting device model will be returned. 
This property will only function with the Autodesk Revit MEP product.

