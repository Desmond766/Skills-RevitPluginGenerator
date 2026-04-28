---
kind: method
id: M:Autodesk.Revit.Creation.Document.NewAreaBoundaryConditions(Autodesk.Revit.DB.Reference,Autodesk.Revit.DB.Structure.TranslationRotationValue,System.Double,Autodesk.Revit.DB.Structure.TranslationRotationValue,System.Double,Autodesk.Revit.DB.Structure.TranslationRotationValue,System.Double)
zh: 文档、文件
source: html/070c2d73-9a6d-3840-b149-b82bb87d4ed3.htm
---
# Autodesk.Revit.Creation.Document.NewAreaBoundaryConditions Method

**中文**: 文档、文件

Creates a new Area BoundaryConditions element on a reference.

## Syntax (C#)
```csharp
public BoundaryConditions NewAreaBoundaryConditions(
	Reference reference,
	TranslationRotationValue X_Translation,
	double X_TranslationSpringModulus,
	TranslationRotationValue Y_Translation,
	double Y_TranslationSpringModulus,
	TranslationRotationValue Z_Translation,
	double Z_TranslationSpringModulus
)
```

## Parameters
- **reference** (`Autodesk.Revit.DB.Reference`) - The Geometry reference obtained from a Wall, Slab or 
Slab Foundation.
- **X_Translation** (`Autodesk.Revit.DB.Structure.TranslationRotationValue`) - A value indicating the X axis translation option.
- **X_TranslationSpringModulus** (`System.Double`) - Translation Spring Modulus for X axis. Ignored if X_Translation is not "Spring".
- **Y_Translation** (`Autodesk.Revit.DB.Structure.TranslationRotationValue`) - A value indicating the Y axis translation option.
- **Y_TranslationSpringModulus** (`System.Double`) - Translation Spring Modulus for Y axis. Ignored if Y_Translation is not "Spring".
- **Z_Translation** (`Autodesk.Revit.DB.Structure.TranslationRotationValue`) - A value indicating the Z axis translation option.
- **Z_TranslationSpringModulus** (`System.Double`) - Translation Spring Modulus for Z axis. Ignored if Z_Translation is not "Spring".

## Returns
If successful, NewAreaBoundaryConditions returns an object for the newly created BoundaryConditions
with the BoundaryType = 2 - "Area". Nothing nullptr a null reference ( Nothing in Visual Basic) is returned if the operation fails.

## Remarks
This method will only function with the Autodesk Revit Structure application.

