---
kind: method
id: M:Autodesk.Revit.DB.FamilyManager.AddParameter(Autodesk.Revit.DB.ExternalDefinition,Autodesk.Revit.DB.ForgeTypeId,System.Boolean)
source: html/bff507b1-caa3-bf4c-f7f1-c56cade391f8.htm
---
# Autodesk.Revit.DB.FamilyManager.AddParameter Method

Add a new shared parameter to the family.

## Syntax (C#)
```csharp
public FamilyParameter AddParameter(
	ExternalDefinition familyDefinition,
	ForgeTypeId groupTypeId,
	bool isInstance
)
```

## Parameters
- **familyDefinition** (`Autodesk.Revit.DB.ExternalDefinition`) - The definition of the loaded shared parameter.
- **groupTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - The identifier of the parameter group to which the family parameter belongs.
- **isInstance** (`System.Boolean`) - Indicates if the new parameter is instance or type.

## Returns
If creation was successful the new shared parameter is returned, 
otherwise an exception with failure information will be thrown.

## Remarks
This method can work even without any family type, but it cannot be assigned the value via 
FamilyManager.Set methods when there is no current type.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the input parameter group cannot be assigned to the new parameter.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the shared family parameter creation is not supported.
Or trying to add an instance parameter of image type.

