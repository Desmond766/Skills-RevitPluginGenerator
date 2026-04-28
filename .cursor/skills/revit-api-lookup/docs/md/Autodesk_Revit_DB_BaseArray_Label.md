---
kind: property
id: P:Autodesk.Revit.DB.BaseArray.Label
source: html/816d60e1-d4ea-cda1-4736-aa5f7d05594a.htm
---
# Autodesk.Revit.DB.BaseArray.Label Property

The family parameter label of the BaseArray.

## Syntax (C#)
```csharp
public FamilyParameter Label { get; set; }
```

## Remarks
The label associates the number of members of the array with a family parameter. 
A BaseArray only can be labeled in a family document and only can be labeled to a integer FamilyParameter. 
To unbind the family parameter, set this property to Nothing nullptr a null reference ( Nothing in Visual Basic) .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the family parameter's ParameterType is not ParameterType.Integer.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when trying to label the BaseArray out of family document.

