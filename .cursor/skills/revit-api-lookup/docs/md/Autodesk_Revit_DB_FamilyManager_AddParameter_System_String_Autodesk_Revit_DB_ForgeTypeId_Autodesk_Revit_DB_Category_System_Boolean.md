---
kind: method
id: M:Autodesk.Revit.DB.FamilyManager.AddParameter(System.String,Autodesk.Revit.DB.ForgeTypeId,Autodesk.Revit.DB.Category,System.Boolean)
source: html/8425ca9a-9db2-d06a-7540-bc8e686a7566.htm
---
# Autodesk.Revit.DB.FamilyManager.AddParameter Method

Add a new family type parameter to control the type of a nested family within another family.

## Syntax (C#)
```csharp
public FamilyParameter AddParameter(
	string parameterName,
	ForgeTypeId groupTypeId,
	Category familyCategory,
	bool isInstance
)
```

## Parameters
- **parameterName** (`System.String`) - The name of the new family parameter.
- **groupTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - The identifier of the group to which the family parameter belongs.
- **familyCategory** (`Autodesk.Revit.DB.Category`) - The category to which the new family parameter binds.
- **isInstance** (`System.Boolean`) - Indicates if the new family parameter is instance or type.

## Returns
If creation was successful the new parameter is returned, 
otherwise an exception with failure information will be thrown.

## Remarks
This method can work even without any family type, but it cannot be assigned the value via 
FamilyManager.Set methods when there is no current type.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input argument-"parameterName"-is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the input argument-"parameterName"-is already in use,
or the input parameter group cannot be assigned to the new parameter,
or the input argument-"familyCategory"-is illegal to bind with parameter.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the required family of familyCategory is not existing in current document,
, or when the creation failed.
Or trying to add an instance parameter of image type.

