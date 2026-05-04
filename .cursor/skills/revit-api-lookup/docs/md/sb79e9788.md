---
kind: property
id: P:Autodesk.Revit.DB.FamilyInstance.Space
zh: 族实例
source: html/3c81b4e4-de4b-44df-8f80-d90c60976dec.htm
---
# Autodesk.Revit.DB.FamilyInstance.Space Property

**中文**: 族实例

The space in which the instance is located (during the last phase of the project).

## Syntax (C#)
```csharp
public Space Space { get; }
```

## Remarks
This property will be the first space encountered that contains the instance. If more than 
one space includes this point in its volume only the first one is returned.
If no space is found that contains the instance, or if phase does not apply to this FaimlyInstance, 
this property is Nothing nullptr a null reference ( Nothing in Visual Basic) .

