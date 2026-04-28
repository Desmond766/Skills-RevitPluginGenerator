---
kind: method
id: M:Autodesk.Revit.DB.FamilyManager.MakeInstance(Autodesk.Revit.DB.FamilyParameter)
source: html/4223e8a2-4032-4fb9-b583-43f65dcba53d.htm
---
# Autodesk.Revit.DB.FamilyManager.MakeInstance Method

Set the family parameter as an instance parameter.

## Syntax (C#)
```csharp
public void MakeInstance(
	FamilyParameter familyParameter
)
```

## Parameters
- **familyParameter** (`Autodesk.Revit.DB.FamilyParameter`)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input argument-"familyParameter"-is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the input argument-"familyParameter"-is an invalid parameter or a builtIn parameter.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when there is Type family parameter driven by this parameter.
Or trying to make a parameter of image type to instance.

