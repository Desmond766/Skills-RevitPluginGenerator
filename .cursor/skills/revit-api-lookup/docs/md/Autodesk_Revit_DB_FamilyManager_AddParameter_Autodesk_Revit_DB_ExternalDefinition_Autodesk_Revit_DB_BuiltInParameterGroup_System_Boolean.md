---
kind: method
id: M:Autodesk.Revit.DB.FamilyManager.AddParameter(Autodesk.Revit.DB.ExternalDefinition,Autodesk.Revit.DB.BuiltInParameterGroup,System.Boolean)
source: html/bc46a62e-1b2d-d8ad-b90e-9ec7c64ae317.htm
---
# Autodesk.Revit.DB.FamilyManager.AddParameter Method

Add a new shared parameter to the family.

## Syntax (C#)
```csharp
[ObsoleteAttribute("This method is deprecated in Revit 2024 and may be removed in a future version of Revit. Please use the `AddParameter(ExternalDefinition, ForgeTypeId, bool)` method instead.")]
public FamilyParameter AddParameter(
	ExternalDefinition familyDefinition,
	BuiltInParameterGroup parameterGroup,
	bool isInstance
)
```

## Parameters
- **familyDefinition** (`Autodesk.Revit.DB.ExternalDefinition`) - The definition of the loaded shared parameter.
- **parameterGroup** (`Autodesk.Revit.DB.BuiltInParameterGroup`) - The group to which the family parameter belongs.
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

