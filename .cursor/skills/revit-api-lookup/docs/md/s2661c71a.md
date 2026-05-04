---
kind: method
id: M:Autodesk.Revit.DB.FamilyManager.ReorderParameters(System.Collections.Generic.IList{Autodesk.Revit.DB.FamilyParameter})
source: html/f3e5375b-28d7-d6c6-ea49-bf6f6289fd9a.htm
---
# Autodesk.Revit.DB.FamilyManager.ReorderParameters Method

Reorders the family parameters by the specified parameters order.

## Syntax (C#)
```csharp
public void ReorderParameters(
	IList<FamilyParameter> parameters
)
```

## Parameters
- **parameters** (`System.Collections.Generic.IList < FamilyParameter >`) - The new parameters order for the family.
The contents of this collection should consist of exactly the same parameters returned by the GetParameters() method. 
This will include invisible parameters; they can be reordered but this will have no effect when viewing the parameters in the Revit UI.

## Remarks
Reordering the parameters only affects visible parameters within the same parameter group. Parameters that belong to different groups will remain separated, and the groups' order will not be affected.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when argument is Nothing nullptr a null reference ( Nothing in Visual Basic) or empty.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the input parameters collection does not contain the same parameters as those returned by GetParameters().
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when this family is a Rebar Shape family which doesn't support parameters reorder.

