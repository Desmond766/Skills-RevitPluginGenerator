---
kind: method
id: M:Autodesk.Revit.DB.FamilyManager.RenameCurrentType(System.String)
source: html/ddd98706-5a07-feac-4b1f-49d52471a8c8.htm
---
# Autodesk.Revit.DB.FamilyManager.RenameCurrentType Method

Rename the current family type.

## Syntax (C#)
```csharp
public void RenameCurrentType(
	string typeName
)
```

## Parameters
- **typeName** (`System.String`) - The new name of the current family type.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input argument-"typeName"-is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the input argument-"typeName"-is already in use.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the family type rename failed.

