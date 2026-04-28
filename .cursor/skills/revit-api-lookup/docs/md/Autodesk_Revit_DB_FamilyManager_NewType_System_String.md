---
kind: method
id: M:Autodesk.Revit.DB.FamilyManager.NewType(System.String)
source: html/b46e98b1-54a1-7e04-66b7-a35efe5bc3f8.htm
---
# Autodesk.Revit.DB.FamilyManager.NewType Method

Add a new family type with a given name and makes it be the current type.

## Syntax (C#)
```csharp
public FamilyType NewType(
	string typeName
)
```

## Parameters
- **typeName** (`System.String`) - The name of new family type.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input argument-"typeName"-is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the input argument-"typeName"-is already in use.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the family type creation failed.

