---
kind: method
id: M:Autodesk.Revit.DB.FamilyManager.AddParameter(System.String,Autodesk.Revit.DB.ForgeTypeId,Autodesk.Revit.DB.ForgeTypeId,System.Boolean)
source: html/3ac89d60-4b71-694f-002f-125d2e6565fc.htm
---
# Autodesk.Revit.DB.FamilyManager.AddParameter Method

Add a new family parameter with a given name.

## Syntax (C#)
```csharp
public FamilyParameter AddParameter(
	string parameterName,
	ForgeTypeId groupTypeId,
	ForgeTypeId specTypeId,
	bool isInstance
)
```

## Parameters
- **parameterName** (`System.String`) - The name of the new family parameter.
- **groupTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - The identifier of the new family parameter's parameter group.
- **specTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - The type of new family parameter.
- **isInstance** (`System.Boolean`) - Indicates if the new family parameter is instance or type.

## Returns
If creation was successful the new parameter is returned, 
otherwise an exception with failure information will be thrown.

## Remarks
This method can work even without any family type, but it cannot be assigned the value via 
FamilyManager.Set methods when there is no current type.
To add a parameter of family type use the AddParameter overload that accepts a category instead.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input argument-"parameterName"-is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the input argument-"parameterName"-is already in use, 
or when the input argument -"specTypeId" is an invalid type,
or the input parameter group cannot be assigned to the new parameter.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the family parameter creation failed.
Or trying to add an instance parameter of image type.

